# DDD解码 - 有界上下文解释

## SapiensWorks.com作品, LC95自译

[DDD Decoded - Application Services Explained](https://blog.sapiensworks.com/post/2016/08/19/DDD-Application-Services-Explained)

我们拥有的所有这些**领域模型**，**聚合**和**领域服务**，但它们只是四处漂浮的业务案例的一部分。我们需要把事情放在一起，以协调特定商业案例的实现。我们需要各种各样的经理，在DDD中，这个角色由应用服务执行。

## 应用服务做什么

最简单的方法是将其视为业务用例的“宿主环境”。它负责调用正确的域模型和服务，在域和基础设施之间进行协调，并从外部保护任何域模型。基本上，在DDD应用程序中，**只有应用程序服务与域模型直接交互**。**应用程序的其余部分只看到应用程序服务(有趣的命名)**。

业务功能被表达为业务案例，应用服务充当外壳，封装了一个业务案例(不管怎样，实际上我们可以托管一个简单的流程，即不止一个业务案例，但这更是一种务实的妥协)。这意味着UI/API或更高层与负责该请求的应用服务对话，应用服务开始工作。最多，调用层会收到一些不应该包含域模型的结果，即实体或值对象。

## 一个例子

让我们继续资金转移的例子。但是现在，我们有了业务规则，只有账户余额有足够的钱，才能进行转账。因此，我们引入了两个域服务:计算帐户余额和帐户是否可以作为`IDomainServices`抽象的功能来实现。但是我们还需要一个AccountBalance值对象。

```CSharp
public class AccountBalance{

}

 /* 领域服务接口 */
public interface IDomainServices
{
    AccountBalance CalculateAccountBalance(AccountNumber acc);
    bool CanAccountBeDebitted(AccountBalance balance,Debit debit);
}

 /* 抽象表示查询模型，实现驻留在基础设施中 */
public interface IDomainQueries
{
    AccountNumber GetAccountNumber(string number);
}
/* 事件存储抽象，基本上是我们的“存储库” */
public interface IEventStore{

}
/* 命令对象, 数据结构 */
public class TransferMoney
{
    public Guid Id { get; set; }
    public string AccountFrom { get; set; }
    public string AccountTo { get; set; }
    public decimal Amount { get; set; }
}
/* 应用服务! */
public class TransferManager
{
    private readonly IEventStore _store;
    private readonly IDomainServices _svc;
    private readonly IDomainQueries _query;
    private readonly ICommandResultMediator _result;
    public TransferManager(IEventStore store, IDomainServices svc,IDomainQueries query,ICommandResultMediator result)
    {
        _store = store;
        _svc = svc;
        _query = query;
        _result = result;
    }
    public void Execute(TransferMoney cmd)
    {
        //与基础设施交互
        var accFrom = _query.GetAccountNumber(cmd.AccountFrom);
        //初始化值对象
        var debit=new Debit(cmd.Amount,accFrom);
        //触发领域服务
        var balance = _svc.CalculateAccountBalance(accFrom);
        if (!_svc.CanAccountBeDebitted(balance, debit))
        {
            //使用中介返回一些错误信息
            //这种方法在单片内部运行良好，所有事情都发生在同一个过程中
            _result.AddResult(cmd.Id, new CommandResult());
            return;
        }
        //使用聚合, 将业务状态更改表示成一个事件
        var evnt = Transfer.Create(/* args */);
        //保存事件
        _store.Append(evnt);

        //发布事件
    }
}
```

这种特殊方法使用消息驱动架构以及事件源。 我们看到应用服务如何协调业务案例; 领域模型不知道命令对象，事件存储或结果中介。 可能令人困惑的一件事是分支，看起来好像应用服务需要知道当帐户余额太低时会发生什么的域规则，但它不会:)。 **这是“告诉我是否可以继续处理业务案例”类型的情况之一**，应用服务使用领域服务来获得答案。 同样，**这是一个知道是谁对某事负责的问题**，而不是怎么做这个事。 应用服务从不进行微观管理。

## 结论

应用程序服务是业务用例的宿主，充当应用程序和领域模型之间的中介。只要您将域行为保持在专有模式中，没有泄漏到As中就行。实现各不相同，也没有“好”的诀窍。只要记住它的角色并尊重域模型，实际的代码取决于您。
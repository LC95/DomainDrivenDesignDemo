namespace Arch.UseCase.Port {
    public interface IRepository<TKey, TEntity> {
        TEntity Get(string id);
        void Save(TEntity house);
    }
}
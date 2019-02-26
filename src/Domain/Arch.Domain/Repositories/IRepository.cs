namespace Arch.Domain.Repositories {
    public interface IRepository<TKey, TEntity> {
        TEntity Get(string id);
        void Save(TEntity house);
    }
}
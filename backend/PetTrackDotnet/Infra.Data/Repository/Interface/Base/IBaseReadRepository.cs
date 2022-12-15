namespace Infra.Data.Repository.Interface.Base;

public interface IBaseReadRepository <T> : IDisposable where T : class
{
    T GetById(int id);
    IQueryable<T> GetAll();
}
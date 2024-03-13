namespace CLINICA.Application.Interfaces.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storeProcedure);
        Task<T> GetByIdAsync(string storeProcedure,object parameters);

        Task<bool> ExecAsync(string storeProcedure, object parameters);

    }
}

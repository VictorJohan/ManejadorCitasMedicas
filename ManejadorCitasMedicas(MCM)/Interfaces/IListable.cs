using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.Interfaces
{
    public interface IListable<T>
    {
        Task<List<T>> GetAll();
        Task<List<T>> ListWhere(Expression<Func<T, bool>> criterio);
    }
}

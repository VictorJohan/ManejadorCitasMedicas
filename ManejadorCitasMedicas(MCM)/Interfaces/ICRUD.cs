namespace ManejadorCitasMedicas_MCM_.Interfaces
{
    public interface ICRUD<T>
    {
        Task<bool> Save(T entity);
        Task<T> Get(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}

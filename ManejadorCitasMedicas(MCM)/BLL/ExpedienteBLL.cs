using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class ExpedienteBLL : ICRUD<Expediente>, IListable<Expediente>
    {
        private readonly SanVicentePaulDBContext _contexto;

        public ExpedienteBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Expediente> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Expediente>> GetAll()
        {
            try
            {
                var lista = await _contexto.Expedientes.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(Expediente).Name}-GetAll");
                return new List<Expediente>();
            }
        }

        public Task<List<Expediente>> ListWhere(Expression<Func<Expediente, bool>> criterio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Expediente entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Expediente entity)
        {
            throw new NotImplementedException();
        }
    }
}

using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class ProvinciaBLL : IListable<Provincias>
    {
        private SanVicentePaulDBContext _contexto { get; set; }
        public ProvinciaBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Provincias>> GetAll()
        {

            try
            {
                var lista = await _contexto.Provincias.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(ProvinciaBLL).Name}-GetAll");
                return new List<Provincias>();
            }

        }

        public async Task<List<Provincias>> ListWhere(Expression<Func<Provincias, bool>> criterio)
        {

            try
            {
                var lista = await _contexto.Provincias.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(ProvinciaBLL).Name}-ListWhere");
                return new List<Provincias>();
            }
        }
    }
}

using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class DistritoBLL : IListable<DistritosMunicipales>
    {
        private SanVicentePaulDBContext _contexto { get; set; }

        public DistritoBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<DistritosMunicipales>> GetAll()
        {
            try
            {
                var lista = await _contexto.DistritosMunicipales.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(DistritoBLL).Name}-GetAll");
                return new List<DistritosMunicipales>();
            }
        }

        public async Task<List<DistritosMunicipales>> ListWhere(Expression<Func<DistritosMunicipales, bool>> criterio)
        {
            try
            {
                var lista = await _contexto.DistritosMunicipales.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(DistritoBLL).Name}-ListWhere");
                return new List<DistritosMunicipales>();
            }
        }
    }
}

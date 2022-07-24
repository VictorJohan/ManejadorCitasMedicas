using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class SectorBLL : IListable<Sectore>
    {
        private SanVicentePaulDBContext _contexto { get; set; }
        public SectorBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Sectore>> GetAll()
        {
            try
            {
                var lista = await _contexto.Sectores.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(SectorBLL).Name}-GetAll");
                return new List<Sectore>();
            }
        }

        public async Task<List<Sectore>> ListWhere(Expression<Func<Sectore, bool>> criterio)
        {
            try
            {
                var lista = await _contexto.Sectores.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(SectorBLL).Name}-ListWhere");
                return new List<Sectore>();
            }
        }
    }
}

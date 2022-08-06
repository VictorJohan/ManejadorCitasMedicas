using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class SectorBLL : IListable<Sectores>
    {
        private SanVicentePaulDBContext _contexto { get; set; }
        public SectorBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Sectores>> GetAll()
        {
            try
            {
                var lista = await _contexto.Sectores.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(SectorBLL).Name}-GetAll");
                return new List<Sectores>();
            }
        }

        public async Task<List<Sectores>> ListWhere(Expression<Func<Sectores, bool>> criterio)
        {
            try
            {
                var lista = await _contexto.Sectores.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(SectorBLL).Name}-ListWhere");
                return new List<Sectores>();
            }
        }
    }
}

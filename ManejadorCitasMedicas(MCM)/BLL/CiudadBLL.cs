using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class CiudadBLL : IListable<Ciudad>
    {
        private SanVicentePaulDBContext _contexto { get; set; }

        public CiudadBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Ciudad>> GetAll()
        {

            try
            {
                var lista = await _contexto.Ciudades.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(CiudadBLL).Name}-GetAll");
                return new List<Ciudad>();
            }

        }

        public async Task<List<Ciudad>> ListWhere(Expression<Func<Ciudad, bool>> criterio)
        {

            try
            {
                var lista = await _contexto.Ciudades.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(CiudadBLL).Name}-ListWhere");
                return new List<Ciudad>();
            }
        }
    }
}

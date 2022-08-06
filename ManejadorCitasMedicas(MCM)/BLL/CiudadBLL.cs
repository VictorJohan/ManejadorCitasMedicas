using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class CiudadBLL : IListable<Ciudades>
    {
        private SanVicentePaulDBContext _contexto { get; set; }

        public CiudadBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Ciudades>> GetAll()
        {

            try
            {
                var lista = await _contexto.Ciudades.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(CiudadBLL).Name}-GetAll");
                return new List<Ciudades>();
            }

        }

        public async Task<List<Ciudades>> ListWhere(Expression<Func<Ciudades, bool>> criterio)
        {

            try
            {
                var lista = await _contexto.Ciudades.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(CiudadBLL).Name}-ListWhere");
                return new List<Ciudades>();
            }
        }
    }
}

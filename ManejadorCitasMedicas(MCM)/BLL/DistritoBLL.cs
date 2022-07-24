using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class DistritoBLL : IListable<DistritoMunicipal>
    {
        private SanVicentePaulDBContext _contexto { get; set; }

        public DistritoBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<DistritoMunicipal>> GetAll()
        {
            try
            {
                var lista = await _contexto.DistritoMunicipals.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(DistritoBLL).Name}-GetAll");
                return new List<DistritoMunicipal>();
            }
        }

        public async Task<List<DistritoMunicipal>> ListWhere(Expression<Func<DistritoMunicipal, bool>> criterio)
        {
            try
            {
                var lista = await _contexto.DistritoMunicipals.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(DistritoBLL).Name}-ListWhere");
                return new List<DistritoMunicipal>();
            }
        }
    }
}

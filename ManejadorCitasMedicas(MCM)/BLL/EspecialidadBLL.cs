using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class EspecialidadBLL : IListable<Especialidades>
    {
        private SanVicentePaulDBContext _contexto { get; set; }

        public EspecialidadBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Especialidades>> GetAll()
        {
            try
            {
                var list = await _contexto.Especialidades.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(EspecialidadBLL).Name}-GetAll");
                return new();
            }
        }

        public async Task<List<Especialidades>> ListWhere(Expression<Func<Especialidades, bool>> criterio)
        {
            try
            {
                var list = await _contexto.Especialidades.Where(criterio).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(EspecialidadBLL).Name}-ListWhere");
                return new();
            }
        }
    }
}

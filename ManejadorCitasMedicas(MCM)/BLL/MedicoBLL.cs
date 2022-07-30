using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class MedicoBLL : ICRUD<Medico>, IListable<Medico>
    {
        private readonly SanVicentePaulDBContext _contexto;

        public MedicoBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Medico> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Medico>> GetAll()
        {
            try
            {
                var lista = await (from m in _contexto.Medicos
                                   join e in _contexto.Especialidades on m.EspecialidadId equals e.EspecialidadId
                                   select new Medico
                                   {
                                       MedicoId = m.MedicoId,
                                       Nombres = m.Nombres,
                                       Apellidos = m.Apellidos,
                                       Cedula = m.Cedula,
                                       Oficio = m.Oficio,
                                       Email = m.Email,
                                       Telefono = m.Telefono,
                                       Cargo = m.Cargo,
                                       EspecialidadId = m.EspecialidadId,
                                       NombreEspecialidad = e.Nombre,
                                       Activo = m.Activo
                                   }).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-GetAll");
                return new List<Medico>();
            }
        }

        public Task<List<Medico>> ListWhere(Expression<Func<Medico, bool>> criterio)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Medico entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Medico entity)
        {
            throw new NotImplementedException();
        }
    }
}

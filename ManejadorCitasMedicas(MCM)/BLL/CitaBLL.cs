using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class CitaBLL : ICRUD<Citas>, IListable<Citas>
    {
        private readonly SanVicentePaulDBContext _contexto;

        public CitaBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var cita = await Get(id);
                cita.Activo = false;
                return await Update(cita);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(CitaBLL).Name}-Delete");
                return false;
            }
        }

        public async Task<Citas> Get(int id)
        {
            try
            {
                var cita = await _contexto.Citas.FindAsync(id);
                if (cita != null)
                    return cita;
                else
                    return new();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(CitaBLL).Name}-Get");
                return new();
            }
        }

        public async Task<List<Citas>> GetAll()
        {
            try
            {
                var list = await (from c in _contexto.Citas
                                  join p in _contexto.Pacientes on c.PacienteId equals p.PacienteId
                                  join m in _contexto.Medicos on c.MedicoId equals m.MedicoId
                                  where c.Activo == true
                                  select new Citas
                                  {
                                      CitaId = c.CitaId,
                                      PacienteId = c.PacienteId,
                                      MedicoId = c.MedicoId,
                                      Inicia = c.Inicia,
                                      Termina = c.Termina,
                                      Activo = c.Activo,
                                      Descripcion = c.Descripcion,
                                      NombrePaciente = $"{p.Nombre} {p.PrimerApellido}",
                                      NombreMedico = $"{m.Nombres} {m.Apellidos}"
                                  }).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(CitaBLL).Name}-GetAll");
                return new List<Citas>();
            }
        }

        public async Task<List<Citas>> ListWhere(Expression<Func<Citas, bool>> criterio)
        {
            try
            {
                var listaAux = await _contexto.Citas.Where(criterio).ToListAsync();
                var lista = (from c in listaAux
                             join u in _contexto.Usuarios on c.UsuarioCreacion equals u.UsuarioId
                             join p in _contexto.Pacientes on c.PacienteId equals p.PacienteId
                             select new Citas
                             {
                                 CitaId = c.CitaId,
                                 PacienteId = c.PacienteId,
                                 MedicoId = c.MedicoId,
                                 Inicia = c.Inicia,
                                 Termina = c.Termina,
                                 Activo = c.Activo,
                                 Descripcion = c.Descripcion,
                                 NombrePaciente = $"{p.Nombre} {p.PrimerApellido}",
                                 NombreUsuarioCreacion = $"{u.Nombre} {u.Apellido}"
                             }).ToList();

                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(CitaBLL).Name}-ListWhere");
                return new List<Citas>();
            }
        }

        public async Task<bool> Save(Citas cita)
        {
            if (cita.CitaId == 0)
                return await Insert(cita);
            else
                return await Update(cita);
        }

        public async Task<bool> Insert(Citas entity)
        {
            try
            {
                _contexto.Citas.Add(entity);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(CitaBLL).Name}-Insert");
                return false;
            }
        }

        public async Task<bool> Update(Citas entity)
        {
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(CitaBLL).Name}-Update");
                return false;
            }
        }


    }
}

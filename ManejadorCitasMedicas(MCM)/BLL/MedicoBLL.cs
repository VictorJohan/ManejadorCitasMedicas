using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class MedicoBLL : ICRUD<Medicos>, IListable<Medicos>
    {
        private readonly SanVicentePaulDBContext _contexto;

        public Medicos Medico { get; set; } = null;

        public MedicoBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var m = await Get(id);
                if (m.MedicoId > 0)
                {
                    m.Activo = false;
                    return await Update(m);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-Delete");
                return false;
            }
        }

        public async Task<Medicos> Get(int id)
        {
            try
            {
                var medico = await (from m in _contexto.Medicos
                                    join e in _contexto.Especialidades on m.EspecialidadId equals e.EspecialidadId
                                    where m.MedicoId == id
                                    select new Medicos
                                    {
                                        MedicoId = m.MedicoId,
                                        Nombres = m.Nombres,
                                        Apellidos = m.Apellidos,
                                        Cedula = m.Cedula,
                                        Oficio = m.Oficio,
                                        Email = m.Email,
                                        Telefono = m.Telefono,
                                        Cargo = m.Cargo,
                                        Contrasena = m.Contrasena,
                                        EspecialidadId = m.EspecialidadId,
                                        NombreEspecialidad = e.Nombre,
                                        Activo = m.Activo
                                    }).SingleOrDefaultAsync();
                if (medico != null)
                    return medico;
                else
                    return new();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-Get");
                return new();
            }
        }

        public async Task<bool> SaveFromExcel(Medicos medico)
        {
            try
            {
                if (!_contexto.Especialidades.Any(s => s.Nombre == medico.NombreEspecialidad))
                {
                    _contexto.Especialidades.Add(new Especialidades { Nombre = medico.NombreEspecialidad });
                    _contexto.SaveChanges();
                }

                if(!_contexto.Medicos.Any(m => m.Cedula == medico.Cedula))
                {
                    var especialidadId = _contexto.Especialidades.First(s => s.Nombre == medico.NombreEspecialidad).EspecialidadId;
                    medico.EspecialidadId = especialidadId;
                    _contexto.Add(medico);
                    await _contexto.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-SaveFromExcel");
                return false;
            }
        }


        public async Task<List<Medicos>> GetAll()
        {
            try
            {
                var lista = await (from m in _contexto.Medicos
                                   join e in _contexto.Especialidades on m.EspecialidadId equals e.EspecialidadId where m.Activo == true
                                   select new Medicos
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
                return new List<Medicos>();
            }
        }

        public async Task<List<Medicos>> ListWhere(Expression<Func<Medicos, bool>> criterio)
        {
            try
            {
                var lista = await _contexto.Medicos.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-ListWhere");
                return new List<Medicos>();
            }
        }

        public async Task<bool> Save(Medicos m)
        {
            if (m.MedicoId == 0)
                return await Insert(m);
            else
                return await Update(m);
        }

        public async Task<bool> Insert(Medicos entity)
        {
            try
            {
                _contexto.Medicos.Add(entity);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-Insert");
                return false;
            }
        }

        public async Task<bool> Update(Medicos entity)
        {
            try
            {
                Detach(entity);
                _contexto.Entry(entity).State = EntityState.Modified;
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-Update");
                return false;
            }
        }

        private void Detach(Medicos medico)
        {
            var aux = _contexto
                   .Set<Medicos>()
                   .Local.FirstOrDefault(m => m.MedicoId == medico.MedicoId);

            if (aux != null)
            {
                _contexto.Entry(aux).State = EntityState.Detached;
            }
        }

        public async Task<Medicos> LoginMedico(string email, string contrasena)
        {
            try
            {
                var medico = await _contexto.Medicos
                    .Where(m => m.Email == email && m.Contrasena == contrasena)
                    .SingleOrDefaultAsync();

                if (medico != null)
                {
                    Medico = medico;
                }

                return medico;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(MedicoBLL).Name}-LoginMedico");
                return null;
            }
        }
    }
}

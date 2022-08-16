using ManejadorCitasMedicas_MCM_.Interfaces;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace ManejadorCitasMedicas_MCM_.BLL
{
    public class PacienteBLL : ICRUD<Pacientes>, IListable<Pacientes>
    {
        private readonly SanVicentePaulDBContext _contexto;

        public PacienteBLL(SanVicentePaulDBContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var exp = await Get(id);
                if (exp.PacienteId > 0)
                {
                    exp.Activo = false;
                    return await Update(exp);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(PacienteBLL).Name}-Delete");
                return false;
            }
        }

        public async Task<Pacientes> Get(int id)
        {
            try
            {
                var exp = await _contexto.Pacientes.FindAsync(id);
                if (exp != null)
                    return exp;
                else
                    return new();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(PacienteBLL).Name}-Get");
                return new();
            }
        }

        public async Task<List<Pacientes>> GetAll()
        {
            try
            {
                var lista = await _contexto.Pacientes.Where(p => p.Activo == true).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"{typeof(Pacientes).Name}-GetAll");
                return new List<Pacientes>();
            }
        }

        public async Task<List<Pacientes>> ListWhere(Expression<Func<Pacientes, bool>> criterio)
        {
            try
            {
                var lista = await _contexto.Pacientes.Where(criterio).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(Pacientes).Name}-ListWhere");
                return new List<Pacientes>();
            }
        }

        public async Task<bool> Save(Pacientes exp)
        {
            if (exp.PacienteId == 0)
                return await Insert(exp);
            else
                return await Update(exp);
        }
        public async Task<bool> Insert(Pacientes entity)
        {
            try
            {
                entity.NumeroExpendiente = await GetNoExpediente();
                _contexto.Pacientes.Add(entity);
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(Pacientes).Name}-Insert");
                return false;
            }
        }

        public async Task<bool> Update(Pacientes entity)
        {
            try
            {
                Detach(entity);
                _contexto.Entry(entity).State = EntityState.Modified;
                return await _contexto.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(Pacientes).Name}-Update");
                return false;
            }
        }

        private void Detach(Pacientes paciente)
        {
            var aux = _contexto
                   .Set<Pacientes>()
                   .Local.FirstOrDefault(c => c.PacienteId == paciente.PacienteId);

            if (aux != null)
            {
                _contexto.Entry(aux).State = EntityState.Detached;
            }
        }
        public async Task<string> GetNoExpediente()
        {
            try
            {
                if (_contexto.Pacientes.Count() == 0)
                    return "0000-000000";

                var noExpediente = await _contexto.Pacientes.MaxAsync(x => x.NumeroExpendiente);
                Int64 numero = Int64.Parse(noExpediente.Replace("-", ""));

                return (numero + 1).ToString("0000-000000");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"{typeof(Pacientes).Name}-GetNoExpediente");
                return "";
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using migracio_api.Data;
using migracio_api.Repository.IRepository;
using SharedModels;

namespace migracio_api.Repository
{
    public class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
        private readonly NominaContext _context;

        public EmpleadoRepository(NominaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Empleado> UpdateAsync(Empleado entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

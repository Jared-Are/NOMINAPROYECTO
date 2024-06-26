using SharedModels;

namespace migracio_api.Repository.IRepository
{
    public interface IEmpleadoRepository : IRepository<Empleado>
    {
        Task<Empleado> UpdateAsync(Empleado entity);
    }
}

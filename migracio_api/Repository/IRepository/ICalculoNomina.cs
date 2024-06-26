namespace migracio_api.Repository.IRepository
{ 
    public interface ICalculoNomina
    {
        Task<decimal> CalcularHorasExtras(decimal Salario, decimal HoraExtra);
        Task<decimal> CalcularRiesgoLabNocturnidad(decimal Salario, string RiesgoNocturnidad););
        Task<decimal> CalcularComision(decimal TotalProdVent, decimal PorcenComision);
        Task<decimal> CalcularAntiguedad(decimal Salario, DateTime Antiguedad);
        Task<decimal> CalculoiR(string Periodo, decimal remuneracionbruta);
        Task<decimal> CalculoInssLaboral(decimal remuneracionbruta);
        Task<decimal> CalculoInssPatronal(decimal remuneracionbruta);
        Task<decimal> CalculoInatec(decimal remuneracionbruta);
    }
}

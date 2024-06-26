using Microsoft.EntityFrameworkCore;
using migracio_api.Data;
using migracio_api.Repository.IRepository;
using SharedModels;

namespace migracio_api.Repository
{
    public class CalculoNomina : ICalculoNomina
    {

        public async Task<decimal> CalcularHorasExtras(decimal Salario, decimal HoraExtra)
        {
            decimal PrecioHora = Salario / 240;
            decimal HorasExtras = PrecioHora * HoraExtra * 2;
            return HorasExtras; 
        }

        public async Task<decimal> CalcularRiesgoLabNocturnidad(decimal Salario, string RiesgoNocturnidad)
        {
            if (RiesgoNocturnidad == "Riesgo Laboral" || RiesgoNocturnidad == "Nocturnidad")
            {
                decimal riesgo = (Salario * 2) / 10;
                return riesgo;
            }
            else if (RiesgoNocturnidad == "Ambas")
            {
                decimal nocturnidad = (Salario * 4) / 10;
                return nocturnidad;
            }
            else
            {
                return 0;
            }
        }

        public async Task<decimal> CalcularComision(decimal TotalProdVent, decimal PorcenComision)
        {
            if (TotalProdVent > 0)
            {
                decimal comision = (PorcenComision * TotalProdVent) / 100;
                return comision;
            }
            if (TotalProdVent < 0)
            {
                decimal noNegativos = 0M;
                return noNegativos;
            }
            return 0;
        }

        public async Task<decimal> CalcularAntiguedad(decimal Salario, DateTime Antiguedad)
        {
            TimeSpan antiguedad = DateTime.Now - Antiguedad;
            decimal antiguedadEnAnos = (decimal)(antiguedad.Days / 365.25);
            if (antiguedadEnAnos >= 2 && antiguedadEnAnos <= 4)
            {
                decimal ValorAPagar = (Salario * 5) / 100;
                return ValorAPagar;
            }
            if (antiguedadEnAnos >= 5 && antiguedadEnAnos <= 7)
            {
                decimal ValorAPagar = (Salario * 11) / 100;
                return ValorAPagar;
            }
            if (antiguedadEnAnos >= 8 && antiguedadEnAnos <= 10)
            {
                decimal ValorAPagar = (Salario * 18) / 100;
                return ValorAPagar;
            }
            if (antiguedadEnAnos >= 11 && antiguedadEnAnos <= 14)
            {
                decimal ValorAPagar = (Salario * 5) / 100;
                return ValorAPagar;
            }
            if (antiguedadEnAnos >= 15 && antiguedadEnAnos <= 19)
            {
                decimal ValorAPagar = (Salario * 34) / 100;
                return ValorAPagar;
            }
            if (antiguedadEnAnos >= 20 && antiguedadEnAnos <= 24)
            {
                decimal ValorAPagar = (Salario * 42) / 100;
                return ValorAPagar;
            }
            if (antiguedadEnAnos >= 25)
            {
                decimal ValorAPagar = (Salario * 50) / 100;
                return ValorAPagar;
            }
            return 0;
        }
        public async Task<decimal> CalculoiR(string Periodo, decimal remuneracionbruta)
        {
            decimal plazo = 0;
            if (Periodo == "Mensual")
            {
                plazo = 12;
            }
            else if (Periodo == "Quincenal")
            {
                plazo = 24;
            }
            else if (Periodo == "Semanal")
            {
                plazo = 48;
            }
            var CalculoInssLaboral = (remuneracionbruta * 7) / 100;
            decimal ir = (remuneracionbruta - CalculoInssLaboral) * plazo;
            if (ir > 100000 && ir <= 200000)
            {
                decimal IR = (((ir - 100000) * 15) / 100) / plazo;
                return IR;
            }
            else if (ir <= 350000 && ir > 200000)
            {
                decimal IR = ((((ir - 200000) * 20) / 100) + 15000) / plazo;
                return IR;
            }
            else if (ir <= 500000 && ir > 350000)
            {
                decimal IR = ((((ir - 350000) * 25) / 100) + 45000) / plazo;
                return IR;
            }
            else if (ir > 500000)
            {
                decimal IR = ((((ir - 500000) * 30) / 100) + 82500) / plazo;
                return IR;
            }
            else return 0;
        }
        public async Task<decimal> CalculoInssLaboral(decimal remuneracionbruta)
        {
            decimal Inss = (remuneracionbruta * 7) / 100;
            return Inss;
        }
        public async Task<decimal> CalculoInssPatronal(decimal remuneracionbruta)
        {
            decimal Inss = (remuneracionbruta * 225) / 1000;
            return Inss;
        }
  
        public async Task<decimal> CalculoInatec(decimal remuneracionbruta)
        {
            decimal Inatec = (remuneracionbruta * 2) / 100;
            return Inatec;
        }
    }
}

using System;

namespace Entity
{
    [Serializable]
    public class LiquidacionContributiva : Liquidacion
    {
        public LiquidacionContributiva()
        {
        }

        public LiquidacionContributiva(string id, DateTime fecha, double costoServicio, Paciente paciente,
            bool maximoAplicado, double costoOriginal) : base(id, fecha, costoServicio, paciente, maximoAplicado,
            costoOriginal)
        {
            Tipo = "Contributiva";
        }

        private const double _SalarioMinimo = 908526;
        private const double _PorcentajeMinimo = 0.15;
        private const double _PorcentajeMedio = 0.20;
        private const double _PorcentajeMaximo = 0.25;
        private const double _TopeMinimo = 250000;
        private const double _TopeMedio = 900000;
        private const double _TopeMaximo = 1500000;

        public override double CalcularTarifa()
        {
            if (Paciente.Salario < (_SalarioMinimo * 2))
            {
                return _PorcentajeMinimo;
            }
            else if (Paciente.Salario >= (_SalarioMinimo * 2) && Paciente.Salario <= (_SalarioMinimo * 5))
            {
                return _PorcentajeMedio;
            }
            else if (Paciente.Salario > (_SalarioMinimo * 5))
            {
                return _PorcentajeMaximo;
            }

            return 0;
        }


        protected override double ObtenerMaximo()
        {
            if (Paciente.Salario < (_SalarioMinimo * 2))
            {
                return _TopeMinimo;
            }
            else if (Paciente.Salario >= (_SalarioMinimo * 2) && Paciente.Salario <= (_SalarioMinimo * 5))
            {
                return _TopeMedio;
            }
            else if (Paciente.Salario > (_SalarioMinimo * 5))
            {
                return _TopeMaximo;
            }

            return 0;
        }
    }
}
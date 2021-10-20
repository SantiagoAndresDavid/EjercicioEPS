using System;

namespace Entity
{
    [Serializable]
    public class LiquidacionSubcidiada : Liquidacion
    {
        public LiquidacionSubcidiada()
        {
        }

        public LiquidacionSubcidiada(string id, DateTime fecha, double costoServicio, Paciente paciente,
            bool maximoAplicado, double costoOriginal) : base(id, fecha, costoServicio, paciente, maximoAplicado,
            costoOriginal)
        {
            Tipo = "Subcidado";
        }

        private const double _Tarifa = 0.5;
        private const double _Tope = 200000;

        public override double CalcularTarifa()
        {
            return _Tarifa;
        }


        protected override double ObtenerMaximo()
        {
            return _Tope;
        }
    }
}
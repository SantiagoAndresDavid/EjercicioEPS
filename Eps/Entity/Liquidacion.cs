using System;

namespace Entity
{
    [Serializable]
    public abstract class Liquidacion
    {
        public string Tipo { get; set; }
        public string Id { get; set; }
        public DateTime Fecha { get; set; }
        public double CostoServicio { get; set; }
        public Paciente Paciente { get; set; }

        public bool MaximoAplicado { get; private set; }


        public double CostoOriginal { get; private set; }

        protected Liquidacion(string id, DateTime fecha, double costoServicio, Paciente paciente, bool maximoAplicado, double costoOriginal)
        {
            Id = id;
            Fecha = fecha;
            CostoServicio = costoServicio;
            Paciente = paciente;
            MaximoAplicado = maximoAplicado;
            CostoOriginal = costoOriginal;
        }

        protected Liquidacion()
        {
        }

        public abstract double CalcularTarifa();
        protected abstract double ObtenerMaximo();

        private double AplicarMaximo(double Costo)
        {
            double CostoMaximo = ObtenerMaximo();
            if (Costo < CostoMaximo)
            {
                return Costo;
            }
            CostoOriginal = Costo;
            MaximoAplicado = true;
            return CostoMaximo;
        }

        public double CalcularCosto() => AplicarMaximo(CostoServicio * CalcularTarifa());

        public override string ToString()
        {
            return $"{{ Id: {Id}, Fecha: {Fecha}, Precio: {CostoServicio}, Paciente: {Paciente} }}";
        }
    }
}
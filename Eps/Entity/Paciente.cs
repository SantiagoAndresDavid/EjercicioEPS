using System;

namespace Entity
{
    [Serializable]
    public class Paciente
    {
        public int Id { get; set; }

        public double Salario { get; set; }

        public Paciente(int id, double salario)
        {
            Id = id;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"{{ Id: {Id}, Salario: {Salario} }}";
        }
    }
}
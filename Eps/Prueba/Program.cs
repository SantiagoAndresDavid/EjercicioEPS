using System;
using Data;
using Entity;

namespace Prueba
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Repository repository = new Repository();
            DateTime start = DateTime.Now;
            Paciente paciente = new Paciente(1234, 20_000_000);
            LiquidacionContributiva liquidacion =
                new LiquidacionContributiva("1234", start, 20_000_000, paciente, false, 20_000_000);
            

            foreach (var Item in repository.leer())
            {
                Console.Write(Item.Id);
            }
           
        }
    }
}
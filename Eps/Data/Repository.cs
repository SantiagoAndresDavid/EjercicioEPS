using System.Collections.Generic;
using Entity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Data
{
    public class Repository :IRepository
    {
        private BinaryFormatter Formatter = new BinaryFormatter();
        public static string fileName = "Liquidaciones.aut";
        public FileStream _archivoEscritor = new FileStream("Liquidaciones.aut",FileMode.OpenOrCreate,FileAccess.Write);
        BinaryWriter _escritor = new BinaryWriter(_archivoEscritor);

        static FileStream _archivoLector = new FileStream("Liquidaciones.aut",FileMode.OpenOrCreate,FileAccess.Read);
        BinaryReader _lector = new BinaryReader(File.Open(fileName, FileMode.Open));
        
        public void guardar(Liquidacion a)
        {
            Formatter.Serialize(_archivoEscritor,a);
            _escritor.Close();
            _archivoEscritor.Close();
        }

        public List<Liquidacion> leer()
        {
            List<Liquidacion> liquidaciones = new List<Liquidacion>();
            _archivoLector.Close();
            while (_archivoLector.Position != _archivoLector.Length)
            {
                
                Liquidacion liquidacion;
                string tipo = _lector.ReadString();
                if (tipo == "Contributiva")
                {
                    liquidacion = new LiquidacionContributiva();
                    liquidacion.Id= _lector.ReadString();
                }
                else
                {
                    liquidacion = new LiquidacionSubcidiada();
                    liquidaciones.Add(liquidacion);
                }
                liquidaciones.Add(liquidacion);
                
            }
            _archivoLector.Close();
            _lector.Close();
            return liquidaciones;
        }
    }
}
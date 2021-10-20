using System.Collections.Generic;
using Entity;

namespace Data
{
    public interface IRepository
    {
        void guardar(Liquidacion a);
        List<Liquidacion> leer();

    }
}
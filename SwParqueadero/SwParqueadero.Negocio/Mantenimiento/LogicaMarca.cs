using System.Collections.Generic;
using System.Linq;
using SwParqueadero.AccesoDatos;


namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaMarca
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public List<TBL_MARCA> Lista()
        {
            //jola
            return dc.TBL_MARCA.ToList();
        }
    }
}

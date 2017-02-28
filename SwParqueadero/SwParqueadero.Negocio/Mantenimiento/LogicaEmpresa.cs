using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaEmpresa
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public TBL_EMPRESA ItemDefault()
        {
            try
            {
                return dc.TBL_EMPRESA.First();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}

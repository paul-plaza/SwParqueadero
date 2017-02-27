using System;
using System.Collections.Generic;
using System.Linq;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaDimensiones
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        /// <summary>
        /// Obtiene una lista de marcas 
        /// </summary>
        /// <returns>List<TBL_DIMENSION></returns>
        public List<TBL_DIMENSION> Lista()
        {
            return dc.TBL_DIMENSION.ToList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaModelo
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        /// <summary>
        /// Obtiene una lista de MODELOs 
        /// </summary>
        /// <returns>List<TBL_MODELO></returns>
        public List<TBL_MODELO> Lista()
        {
            return dc.TBL_MODELO.ToList();
        }

        public List<TBL_MODELO> ListaPorDescripcion(string texto)
        {
            return dc.TBL_MODELO.Where(aux => aux.MOD_DESCRIPCION.Contains(texto)).ToList();
        }

        private int secuencial()
        {
            try
            {
                return dc.TBL_MODELO.Max(aux => aux.MAR_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public TBL_MODELO ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_MODELO.FirstOrDefault(aux => aux.MAR_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Guardar(TBL_MODELO item)
        {
            try
            {
                item.MAR_CODIGO = secuencial();
                dc.TBL_MODELO.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_MODELO item)
        {
            try
            {
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Eliminar(int codigo)
        {
            try
            {

                dc.TBL_MODELO.Remove(dc.TBL_MODELO.First(aux => aux.MAR_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using SwParqueadero.AccesoDatos;
using System;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaMarca
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        /// <summary>
        /// Obtiene una lista de marcas 
        /// </summary>
        /// <returns>List<TBL_MARCA></returns>
        public List<TBL_MARCA> Lista()
        {
            return dc.TBL_MARCA.ToList();
        }

        public List<TBL_MARCA> ListaPorDescripcion(string texto)
        {
            return dc.TBL_MARCA.Where(aux=>aux.MAR_DESCRIPCION.Contains(texto)).ToList();
        }

        private int secuencial()
        {
            try
            {
                return dc.TBL_MARCA.Max(aux => aux.MAR_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public TBL_MARCA ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_MARCA.FirstOrDefault(aux => aux.MAR_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Guardar(TBL_MARCA item)
        {
            try
            {
                item.MAR_CODIGO = secuencial();
                dc.TBL_MARCA.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_MARCA item)
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

                dc.TBL_MARCA.Remove(dc.TBL_MARCA.First(aux => aux.MAR_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


    }
}

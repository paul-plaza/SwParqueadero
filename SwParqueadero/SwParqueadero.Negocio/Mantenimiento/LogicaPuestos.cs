using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaPuestos
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public List<TBL_PUESTOS> ListaPorCodigoParqueadero(int codigoParqueadero)
        {
            return dc.TBL_PUESTOS.Where(aux=>aux.PAR_CODIGO.Equals(codigoParqueadero)).ToList();
        }

        public List<TBL_PUESTOS> ListaPorNombreParqueadero(int codigoParqueadero,string texto)
        {
            return dc.TBL_PUESTOS.Where(aux => aux.PAR_CODIGO.Equals(codigoParqueadero) & aux.PUE_NOMBRE.Contains(texto)).ToList();
        }

        private int secuencial()
        {
            try
            {
                return dc.TBL_PUESTOS.Max(aux => aux.PUE_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public TBL_PUESTOS ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_PUESTOS.FirstOrDefault(aux => aux.PUE_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Guardar(TBL_PUESTOS item)
        {
            try
            {
                item.PUE_CODIGO = secuencial();
                dc.TBL_PUESTOS.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_PUESTOS item)
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

                dc.TBL_PUESTOS.Remove(dc.TBL_PUESTOS.First(aux => aux.PUE_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

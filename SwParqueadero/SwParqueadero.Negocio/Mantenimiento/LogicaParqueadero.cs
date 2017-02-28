using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaParqueadero
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public List<TBL_PARQUEADERO> Lista()
        {
            return dc.TBL_PARQUEADERO.ToList();
        }

        private int secuencial()
        {
            try
            {
                return dc.TBL_PARQUEADERO.Max(aux => aux.PAR_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public void Guardar(TBL_PARQUEADERO item)
        {
            try
            {
                item.PAR_CODIGO = secuencial();
                dc.TBL_PARQUEADERO.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_PARQUEADERO item)
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

                dc.TBL_PARQUEADERO.Remove(dc.TBL_PARQUEADERO.First(aux => aux.PAR_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public TBL_PARQUEADERO ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_PARQUEADERO.FirstOrDefault(aux => aux.PAR_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

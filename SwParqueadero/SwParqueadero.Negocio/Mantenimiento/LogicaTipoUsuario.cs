using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    
    public class LogicaTipoUsuario
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public List<TBL_TIPO_USUARIO> ListaTipoUsuario()
        {
            return dc.TBL_TIPO_USUARIO.ToList();
        }

        private int secuencial()
        {
            try
            {
                return dc.TBL_TIPO_USUARIO.Max(aux => aux.TIPU_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public void Guardar(TBL_TIPO_USUARIO item)
        {
            try
            {
                item.TIPU_CODIGO = secuencial();
                dc.TBL_TIPO_USUARIO.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_TIPO_USUARIO item)
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

                dc.TBL_TIPO_USUARIO.Remove(dc.TBL_TIPO_USUARIO.First(aux => aux.TIPU_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public TBL_TIPO_USUARIO ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_TIPO_USUARIO.FirstOrDefault(aux => aux.TIPU_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

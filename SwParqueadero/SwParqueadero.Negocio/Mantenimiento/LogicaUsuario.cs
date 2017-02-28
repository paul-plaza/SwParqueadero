using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaUsuario
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public List<TBL_USUARIO> Lista()
        {
            return dc.TBL_USUARIO.ToList();
        }

        public List<TBL_USUARIO> ListaPorUsuario(int codigo)
        {
            try
            {
                return dc.TBL_USUARIO.Where(aux => aux.USU_CODIGO.Equals(codigo)).ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message); ;
            }
        }
        public List<TBL_USUARIO> ListaUsuarioPorCedula(string cedula)
        {
            try
            {
                return dc.TBL_USUARIO.Where(aux => aux.USU_CEDULA.Equals(cedula)).ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message); ;
            }
        }
        private int secuencial()
        {
            try
            {
                return dc.TBL_USUARIO.Max(aux => aux.USU_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public void Guardar(TBL_USUARIO item)
        {
            try
            {
                item.USU_CODIGO = secuencial();
                dc.TBL_USUARIO.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_USUARIO item)
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

                dc.TBL_USUARIO.Remove(dc.TBL_USUARIO.First(aux => aux.USU_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public TBL_USUARIO ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_USUARIO.FirstOrDefault(aux => aux.USU_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public TBL_USUARIO ItemPorCedula(string cedula)
        {
            try
            {
                return dc.TBL_USUARIO.FirstOrDefault(aux => aux.USU_CEDULA.Equals(cedula));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

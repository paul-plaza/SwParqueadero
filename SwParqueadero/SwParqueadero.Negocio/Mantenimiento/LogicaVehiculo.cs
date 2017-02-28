using System;
using System.Collections.Generic;
using System.Linq;
using SwParqueadero.AccesoDatos;

namespace SwParqueadero.Negocio.Mantenimiento
{
    public class LogicaVehiculo
    {
        private DbParqueoEntities dc = new DbParqueoEntities();

        public List<TBL_VEHICULO> Lista()
        {
            return dc.TBL_VEHICULO.ToList();
        }

        public List<TBL_VEHICULO> ListaPorUsuario(int codigo)
        {
            return dc.TBL_VEHICULO.Where(aux => aux.USU_CODIGO.Equals(codigo)).ToList();
        }

        public List<TBL_VEHICULO> ListaPorPlaca(string texto)
        {
            return dc.TBL_VEHICULO.Where(aux => aux.VEH_PLACA.Contains(texto)).ToList();
        }

        private int secuencial()
        {
            try
            {
                return dc.TBL_VEHICULO.Max(aux => aux.VEH_CODIGO + 1);
            }
            catch
            {
                return 1;
            }
        }

        public TBL_VEHICULO ItemPorCodigo(int codigo)
        {
            try
            {
                return dc.TBL_VEHICULO.FirstOrDefault(aux => aux.VEH_CODIGO.Equals(codigo));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Guardar(TBL_VEHICULO item)
        {
            try
            {
                item.VEH_CODIGO = secuencial();
                dc.TBL_VEHICULO.Add(item);
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void Modificar(TBL_VEHICULO item)
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
                dc.TBL_VEHICULO.Remove(dc.TBL_VEHICULO.First(aux => aux.VEH_CODIGO.Equals(codigo)));
                dc.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

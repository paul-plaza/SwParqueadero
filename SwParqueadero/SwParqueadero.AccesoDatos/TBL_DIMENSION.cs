//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwParqueadero.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_DIMENSION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_DIMENSION()
        {
            this.TBL_PUESTOS = new HashSet<TBL_PUESTOS>();
        }
    
        public int DIM_CODIGO { get; set; }
        public string DIM_DESCRIPCION { get; set; }
        public decimal DIM_LARGO { get; set; }
        public decimal DIM_ANCHO { get; set; }
    
        public virtual TBL_VEHICULO TBL_VEHICULO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PUESTOS> TBL_PUESTOS { get; set; }
    }
}

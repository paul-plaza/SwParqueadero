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
    
    public partial class TBL_OBSERVACION_SOLICITUD
    {
        public int OBDOL_CODIGI { get; set; }
        public int OBS_CODIGO { get; set; }
        public int SOL_CODIGO { get; set; }
    
        public virtual TBL_OBSERVACIONES TBL_OBSERVACIONES { get; set; }
        public virtual TBL_SOLICITUD TBL_SOLICITUD { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwParqueadero.Comun
{
    public class CConstantes
    {

        public class Constantes
        {
            /// <summary>
            /// <c>Valor: M</c>
            /// </summary>
            public static string MODIFICAR = "M";

            /// <summary>
            /// <c>Valor: E</c>
            /// </summary>
            public static string ELIMINAR = "E";

            /// <summary>
            /// <c>Valor:C</c>
            /// </summary>
            public static string ENVIAR_CORREO = "C";

            /// <summary>
            /// <c>Valor:A</c>
            /// </summary>
            public static string ASIGNACION_VEHICULO = "A";

            /// <summary>
            /// <c>Valor: 0</c>
            /// </summary>
            public static string VER_ITEM = "V";

            /// <summary>
            /// <c>Valor: 0</c>
            /// </summary>
            public static string VALOR_POR_DEFECTO = "0";

            public static string MENSAJE_CORREO_NO_ENVIADO = "MENSAJE CORREO NO ENVIADO";

            public static string PLANTILLA_MAIL = "~/Plantillas/Plantilla_Mail.html";
        }

        public class ConstantesMensajesValidaciones
        {
            public static string MENSAJE_ARCHIVO_SUBIDO = "Archivo subido con éxito";

            public static string MENSAJE_ARCHIVO_NO_SUBIDO = "Archivo no fue subido";

            public static string MENSAJE_ARCHIVO_NO_VALIDO = "Archivo con extension no valida";

            public static string MENSAJE_SELECCIONAR_ITEM = "Debe seleccionar un resgistro para subir el archivo!";

            public static string MENSAJE_REGISTRO_NO_EXISTE = "Registro no existe!";

            public static string MENSAJE_NUMERO_MAXIMO = "Ha sobrepasado el número de items permitidos";
        }

        public class ConstantesSesion
        {
            public static string VEHICULO = "VEHICULO";
        }

    }
}

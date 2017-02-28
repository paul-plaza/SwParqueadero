using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using SwParqueadero.AccesoDatos;


namespace SwParqueadero.Comun
{
    public class CUtilitarios
    {
        private const string KEY = "mikey";
        public string Encriptar(string texto)
        {
            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KEY));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();

            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }

        public static string leerArchivo(string rutaArchivo)
        {
            StringBuilder archivoLinea = new StringBuilder();
            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                String line = String.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    archivoLinea.Append(line);
                }
            }
            return archivoLinea.ToString();
        }

        /// <summary>
        /// Carga Imagen en servidor
        /// </summary>
        /// <param name="FileUpload1">Control FileUpload</param>
        /// <param name="Directorio">String Ruta en donde se cargara la imagen</param>
        public static string cargarArchivos(FileUpload FileUpload1, string path, string nombreArchivo = null)
        {
            Boolean fileOK = false;
            if (FileUpload1.HasFile)
            {
                String fileExtension = Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    string texto = path + (nombreArchivo != null ? nombreArchivo : FileUpload1.FileName);
                    FileUpload1.PostedFile.SaveAs(texto);
                    return CConstantes.ConstantesMensajesValidaciones.MENSAJE_ARCHIVO_SUBIDO;
                }
                catch (Exception)
                {
                    throw new ArgumentException(CConstantes.ConstantesMensajesValidaciones.MENSAJE_ARCHIVO_NO_SUBIDO);
                }
            }
            else
            {
                throw new ArgumentException(CConstantes.ConstantesMensajesValidaciones.MENSAJE_ARCHIVO_NO_VALIDO);
            }

        }

        public bool EnviarCorreoGenerico(TBL_EMPRESA _InfoCompania, List<string> correoDestinatario, EEmail Mail, string Ruta)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_InfoCompania.EMP_CORREO, _InfoCompania.EMP_NOMBRE, System.Text.Encoding.UTF8);
            msg.Subject = "Credenciales";//_infoMail.TIPT_SUBJET;
            msg.SubjectEncoding = Encoding.UTF8;
            foreach (string item in correoDestinatario)
            {
                msg.To.Add(item);
            }
            string mail = leerArchivo(Ruta);

            mail = mail.Replace("@INTROCABECERA", Mail.IntroCabecera);
            mail = mail.Replace("@SUBTITULO", Mail.Subtitulo);
            mail = mail.Replace("@RESUMEN", Mail.Resumen);
            mail = mail.Replace("@TITULO_MENSAJE", Mail.TituloMensjae);
            mail = mail.Replace("@MENSAJE_MOSTRAR", Mail.Mensaje);
            msg.Body = mail;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_InfoCompania.EMP_CORREO, _InfoCompania.EMP_PASSWORD);
            client.Port = Convert.ToInt32(_InfoCompania.EMP_PUERTO);
            client.Host = _InfoCompania.EMP_SMTP;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                throw new ArgumentException(CConstantes.Constantes.MENSAJE_CORREO_NO_ENVIADO + ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SwParqueadero.AccesoDatos;


namespace SwParqueadero.Comun
{
    public class CUtilitarios
    {
        string key = "mikey";
        public string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(key));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
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

        public  bool EnviarCorreoGenerico(TBL_EMPRESA _InfoCompania, List<string> correoDestinatario,EEmail Mail, string Ruta)//, Tbl_Tipo_Transaccion _infoMail)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_InfoCompania.EMP_CORREO,_InfoCompania.EMP_NOMBRE, System.Text.Encoding.UTF8);
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
            client.Credentials = new System.Net.NetworkCredential(_InfoCompania.EMP_CORREO,_InfoCompania.EMP_PASSWORD);
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

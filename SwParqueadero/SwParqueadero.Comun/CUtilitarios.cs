using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

        public  bool EnviarCorreoGenerico(string _InfoCompania, List<string> correoDestinatario, string ruta)//, Tbl_Tipo_Transaccion _infoMail)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("dgranizo.c@gmail.com", "UNIVERSIDAD TECNOLOGICA ISRAEL", System.Text.Encoding.UTF8);
            msg.Subject = "Saludos";//_infoMail.TIPT_SUBJET;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            foreach (string item in correoDestinatario)
            {
               // if (ComprobarFormatoEmail(item))
                //{
                    msg.To.Add(item);
                //}
            }
            string mail = leerArchivo(ruta + CConstantes.Constantes.PLANTILLA_MAIL);
            //foreach (Tbl_Detalle_Mail item in _infoMail.Tbl_Detalle_Mail)
            //{
            //    if (item.Tbl_Catalogo_Datos.TCD_DESCRIPCION.Equals(CTransaccionesMail.MENSAJE_MOSTRAR))
            //    {
            //        mail = mail.Replace(CTransaccionesMail.MENSAJE_MOSTRAR, item.TMA_DESCRIPCION + " " + _infoMail.TIPT_OTRO);
            //    }
            //    else
            //    {
            //        mail = mail.Replace(item.Tbl_Catalogo_Datos.TCD_DESCRIPCION, item.TMA_DESCRIPCION);
            //    }
            //}
            //mail = mail.Replace(CTransaccionesMail.INTRODUCCION, string.Empty);
            mail = mail.Replace("@INTROCABECERA", string.Empty);
            mail = mail.Replace("@SUBTITULO", string.Empty);
            mail = mail.Replace("@RESUMEN", string.Empty);
            //mail = mail.Replace(CTransaccionesMail.LINKEXPERTUS, string.Empty);
            mail = mail.Replace("@TITULO_MENSAJE", string.Empty);
            msg.Body = mail;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("bsdevelopers4@gmail.com","paul123plaza");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
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

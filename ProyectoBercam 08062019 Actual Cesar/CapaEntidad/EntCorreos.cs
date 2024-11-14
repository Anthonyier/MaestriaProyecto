using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading;
namespace CapaEntidad
{
    public class EntCorreos
    {
        public MailMessage msj { get; set; }
        public SmtpClient smtp { get; set; }
        public string From { get; set; }
        public string Add { get; set; }
        public string Body { get; set; }
        public string Mensaje { get; set; }
        public string Subject { get; set; }
       public string Host { get; set; }
       public int Port { get; set; }
       public string fr { get; set; }
       public string pass { get; set; }


    }
}
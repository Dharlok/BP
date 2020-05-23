using System;
using System.Net;
using System.Net.Mail;


namespace Pochta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свой Email");
            string email = Console.ReadLine();
            Console.WriteLine("Введите свое имя");
            string name = Console.ReadLine();
            MailAddress from = new MailAddress(email, name);


            Console.WriteLine("Введите почту получателя");
            string email_2 = Console.ReadLine();
            MailAddress to = new MailAddress(email_2);

            using (MailMessage k = new MailMessage(from, to))
            using (SmtpClient smtp = new SmtpClient())
            {
                Console.WriteLine("Введите тему сообщения");
                k.Subject = Console.ReadLine();
                Console.WriteLine("Введите текст сообщения");
                k.Body = Console.ReadLine();
                k.IsBodyHtml = true;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                Console.WriteLine("пароль от вашей почты");
                string text = Console.ReadLine();
                smtp.Credentials = new NetworkCredential(email, text);
                smtp.Send(k);
            }
                
        }
    }
}

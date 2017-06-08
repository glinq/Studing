using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommonLq
{
    public class MailUtility
    {
        public static void SendNotificationMail(string mailTo, string title, string content)
        {
            try
            {
                string mailUser = "";
                string mailPwd = "";
                string mailServer = "";
                if (!string.IsNullOrEmpty(mailTo))
                {
                    if (!mailTo.Contains("@"))
                    {
                        return;
                    }
                    for (int i = 0; i < mailTo.TrimEnd(';').Split(';').Length; i++)
                    {
                        var from = new MailAddress(mailUser);
                        var to = new MailAddress(mailTo.TrimEnd(';').Split(';')[i]);
                        var msg = new MailMessage(from, to)
                        {
                            Subject = title,
                            SubjectEncoding = Encoding.UTF8,
                            Body = content,
                            BodyEncoding = Encoding.UTF8,
                            IsBodyHtml = true,
                            Priority = MailPriority.High
                        };
                        var smtp = new SmtpClient
                        {
                            Credentials = new System.Net.NetworkCredential(mailUser, mailPwd),
                            Host = mailServer
                        }; //允许应用程序使用SMTP发邮件
                           //smtp.EnableSsl = true; //是否使用SSL加密连接（有的服务器不支持此链接）
                        smtp.Send(msg);//发信 
                        msg.Dispose(); //释放有MailMessage使用的所有资源
                    }
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}

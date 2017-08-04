using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class BlastMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    	    string[] arr = new string[2];
                arr[0]="affiq.rashid@tm.com.my";
                arr[1]="zaiman.azman@tm.com.my";
                arr[2]="azrin.othman@tm.com.my";           
			
			string FileName = HttpContext.Current.Server.MapPath("./templates/templateMoM.html");
			StreamReader FileReader = File.OpenText(FileName);
			string MailTemplate = FileReader.ReadToEnd();
			FileReader.Close();

			int tableWidth = 540;			
			
			MailTemplate = MailTemplate.Replace("##TABLE_WIDTH##", tableWidth.ToString());

            foreach (string email in arr)
            {
			try {
				MailMessage mail = new MailMessage();
				mail.To.Add(email);
				mail.Subject = "Reminder For Meeting";
				mail.SubjectEncoding = System.Text.Encoding.UTF8;
				mail.BodyEncoding = System.Text.Encoding.UTF8;
				mail.IsBodyHtml = true;
				mail.Priority = MailPriority.High;
				
				
				SmtpClient client = new SmtpClient();
				client.Send(mail);

				Response.Write("Re-send edm to " + email + "<br />");
			}
			catch (Exception ex)
			{
				// return "{\"Status\":\"-1\",\"Message\":\"" + ex.Message + "\"}";
				Response.Write("Error! " + ex.Message + "<br />");
			}
		}
    }
}
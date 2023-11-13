using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4GroupProject.Logon
{
    public partial class Logon : System.Web.UI.Page
    {

        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\grifw\\source\\repos\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string password = Login1.Password;

            try
            {
                dbcon = new KarateDataContext(conn);

                var names = from name in dbcon.NetUsers
                            where name.UserName == userName

                            select new
                            {
                                name.UserName
                            };

                var pswds = from pswd in dbcon.NetUsers
                            where pswd.UserPassword == password

                            select new
                            {
                                pswd.UserPassword
                            };

                string username1 = names.First().UserName;
                string password1 = pswds.First().UserPassword;

                var userType = from x in dbcon.NetUsers
                         where x.UserName == userName
                         select new
                         {
                             x.UserType
                         };

                string uType = userType.First().UserType;


                if (userName.Equals(username1) && password.Equals(password1))
                {
                    if(uType == "Member")
                    {
                        Response.Redirect("~/Members/Members.aspx");
                    }
                    if (uType == "Instructor")
                    {
                        Response.Redirect("~/Instructors/Instructors.aspx");
                    }


                    FormsAuthentication.RedirectFromLoginPage(userName, true);
                    
                }
                else
                {
                    Response.Redirect("Logon.aspx", true);
                    TextBox1.Text = "ahsdahsdas";
                    Label1.Text = "apsofihadf";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
    }
}
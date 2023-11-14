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

        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ehofm\\Desktop\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Initialize Connection String
            dbcon = new KarateDataContext(conn);
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = Login1.UserName;
            string password = Login1.Password;

            HttpContext.Current.Session["userName"] = userName;
            HttpContext.Current.Session["password"] = password;

            try
            {
                //search and validate the user
                NetUser myUser = (from x in dbcon.NetUsers
                                  where x.UserName == HttpContext.Current.Session["userName"].ToString()
                                  &&
                                  x.UserPassword == HttpContext.Current.Session["password"].ToString()
                                  select x).First();

                if(myUser != null )
                {
                    //get the user's ID and user's Type and add to the session
                    HttpContext.Current.Session["userID"] = myUser.UserID;
                    HttpContext.Current.Session["userType"] = myUser.UserType;
                }
               

                //send users to correct pages based on userType
                //if user is member
                if(myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
                {
                    FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["userName"].ToString(), true);
                    Response.Redirect("~/Members/Members.aspx");
                }
                //if user is instructor
                if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
                {
                    FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["userName"].ToString(), true);
                    Response.Redirect("~/Instructors/Instructors.aspx");
                }
                //if user is admin
                if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["userName"].ToString(), true);
                    Response.Redirect("~/Admins/Admins.aspx");
                }
                //if usertype is not recognized/null
                else
                {
                    Response.Redirect("Logon.aspx", true);
                    
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
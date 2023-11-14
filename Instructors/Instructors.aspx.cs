using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Assignment4GroupProject.Instructors
{
    public partial class Instructors : System.Web.UI.Page
    {
        //connection string to the database
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ehofm\\Desktop\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if the session count is not equal to zero checks to see if the wrong usertype is in the session
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member" || HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
                {
                    //deletes session and reverts back to logon page
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }

            }
            dbcon = new KarateDataContext(conn);

            //collects the instructors username
            string myInstruct = User.Identity.Name;

            try
            {
                //query to collect user id from database
                NetUser instructUserID = (from x in dbcon.NetUsers
                                          where x.UserName == myInstruct
                                          select x).First();

                //assigns user id to id
                int id = instructUserID.UserID;

                //query to display first and last name of logged in user
                Instructor instructName = (from x in dbcon.Instructors
                                            where x.InstructorID == id
                                            select x).First();

                lblNameDisplay.Text = instructName.InstructorFirstName + " " + instructName.InstructorLastName;


                //query to collect respective data from datatables to display to user
                var result = from karMember in dbcon.Members
                             from sectionInfo in dbcon.Sections
                             from instructor in dbcon.Instructors
                             where instructor.InstructorID == id && karMember.Member_UserID == sectionInfo.Member_ID && sectionInfo.Instructor_ID == instructor.InstructorID
                             select new
                             {
                                 sectionInfo.SectionName,
                                 karMember.MemberLastName,
                                 karMember.MemberFirstName,
                             };
                //displays data to user
                GridView1.DataSource = result;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
 
    }
}
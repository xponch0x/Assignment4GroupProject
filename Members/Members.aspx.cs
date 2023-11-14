using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4GroupProject.Members
{
    public partial class Members : System.Web.UI.Page
    {

        //connection string to the database
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ehofm\\Desktop\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if the session count is not equal to zero checks to see if the wrong usertype is in the session
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor" || HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
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

            //collects the members username
            string myMember = User.Identity.Name;


            try
            {

                


                //query to collect user id from database
                NetUser memberUserID = (from x in dbcon.NetUsers
                                        where x.UserName == myMember
                                        select x).First();

                //assigns user id to id
                int id = memberUserID.UserID;

                //query to display fisrt and last name of logged in user
                Member memName = (from x in dbcon.Members
                                  where x.Member_UserID == id
                                  select x).First();

                lblNameDisplay.Text = memName.MemberFirstName + " " + memName.MemberLastName;

                //query to collect respective data from datatables to display to user
                var result = from karMember in dbcon.Members
                             from sectionInfo in dbcon.Sections
                             from instructor in dbcon.Instructors
                             where karMember.Member_UserID == id && karMember.Member_UserID == sectionInfo.Member_ID && sectionInfo.Instructor_ID == instructor.InstructorID
                             select new
                             {
                                 sectionInfo.SectionName,
                                 instructor.InstructorLastName,
                                 instructor.InstructorFirstName,
                                 karMember.MemberDateJoined,
                                 sectionInfo.SectionFee
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
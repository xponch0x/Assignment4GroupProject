using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4GroupProject.Admins
{
    public partial class Admins : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\grifw\\source\\repos\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //make sure a user is logged in and is an admin
            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor" || HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }

            }

            dbcon = new KarateDataContext(conn);

            //search for all instructors
            var resultInstruct = from instructor in dbcon.Instructors
                         select new
                         {
                             instructor.InstructorLastName,
                             instructor.InstructorFirstName,
                         };
            //show instructors grid view
            adminGridViewInstructor.DataSource = resultInstruct;
            adminGridViewInstructor.DataBind();

            //search for all members
            var resultMember = from karMember in dbcon.Members
                         select new
                         {
                             karMember.MemberLastName,
                             karMember.MemberFirstName,
                             karMember.MemberPhoneNumber,
                             karMember.MemberDateJoined
                         };
            //show members grid view and refresh
            adminGridViewMember.DataSource = resultMember;
            adminGridViewMember.DataBind();
            Refresh();
        }

        //method to refresh the gridviews showing the updated database
        public void Refresh() 
        {
            dbcon = new KarateDataContext(conn);

            //search for all instructor
            var resultInstruct = from instructor in dbcon.Instructors
                                 select new
                                 {
                                     instructor.InstructorLastName,
                                     instructor.InstructorFirstName,
                                 };
            //show the instructor's gridview
            adminGridViewInstructor.DataSource = resultInstruct;
            adminGridViewInstructor.DataBind();
            //search for all member
            var resultMember = from karMember in dbcon.Members
                               select new
                               {
                                   karMember.MemberLastName,
                                   karMember.MemberFirstName,
                                   karMember.MemberPhoneNumber,
                                   karMember.MemberDateJoined
                               };
            //show the members grid view
            adminGridViewMember.DataSource = resultMember;
            adminGridViewMember.DataBind();
        }

        //method to add a new member entry to the database
        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);



            //create and add new user
            NetUser netuser = new NetUser 
            {
                UserName = txtMemberUserName.Text,
                UserPassword = txtMemberPassword.Text,
                UserType = "Member"
            };
            db.NetUsers.InsertOnSubmit(netuser);
            db.SubmitChanges();

            //create new member
            Member member = new Member 
            {
                MemberFirstName = txtMemberFirstName.Text,
                MemberPhoneNumber = txtMemberPhoneNumber.Text,
                MemberLastName = txtMemberLastName.Text,
                MemberEmail = txtMemberEmail.Text,
                Member_UserID = netuser.UserID,
                MemberDateJoined = DateTime.Now
            };

            //add new member to database
            db.Members.InsertOnSubmit(member);
            db.SubmitChanges();
            //refresh gridview
            Refresh();

            //reset the text boxes
            txtMemberEmail.Text = string.Empty;
            txtMemberFirstName.Text = string.Empty;
            txtMemberLastName.Text = string.Empty;
            txtMemberPassword.Text = string.Empty;
            txtMemberUserName.Text = string.Empty;
            txtMemberPhoneNumber.Text = string.Empty;
            
          
        }

        //button to add a new instructor entry to the database
        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);

            
            //create new user
            var netuser = new NetUser();
            
            netuser.UserName = txtInstructorUserName.Text;
            netuser.UserPassword = txtInstructorPassword.Text;
            netuser.UserType = "Instructor";

            //add user to database
            db.NetUsers.InsertOnSubmit(netuser);
            db.SubmitChanges();

            //create new instructor
            var instructor = new Instructor();
            instructor.InstructorFirstName = txtInstructorFirstName.Text;
            instructor.InstructorPhoneNumber = txtInstructorPhone.Text;
            instructor.InstructorLastName = txtInstructorLastName.Text;
            instructor.InstructorID = netuser.UserID;
            //add instructor to database
            db.Instructors.InsertOnSubmit(instructor);
            db.SubmitChanges();

            //reset text boxes/gridview
            Refresh();
            txtInstructorFirstName.Text = string.Empty;
            txtInstructorLastName.Text = string.Empty;
            txtInstructorPassword.Text = string.Empty;
            txtInstructorUserName.Text = string.Empty;
            txtInstructorPhone.Text = string.Empty;
        }

        //button to assign a member to a new section in the database
        protected void btnAssignMemberToSection_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);


            //find the section you are searching for
            Section section = db.Sections.FirstOrDefault(item => item.SectionID == Convert.ToInt32(txtSectionId.Text));
            //add the member to the section
            if (section != null) 
            { 
                section.Member_ID = Convert.ToInt32(txtMemberId.Text);
                db.SubmitChanges();
            }
            //refresh text boxes
            txtMemberId.Text = string.Empty;
            txtSectionId.Text = string.Empty;
        }

        //button to delete a member from the database
        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            
            var db = new KarateDataContext(conn);

            
            //find the member you want to delete
            var memberUserID = (from x in dbcon.Members
                                    where x.Member_UserID == Convert.ToInt32(txtDeleteMemberId.Text)
                                    select x).First();
            //delete the member
            if (memberUserID != null)
            {
                dbcon.Members.DeleteOnSubmit(memberUserID);
                dbcon.SubmitChanges();
            }
            //find the user you want to delete
            var netUserID = (from x in dbcon.NetUsers
                                where x.UserID == Convert.ToInt32(txtDeleteMemberId.Text)
                                select x).First();
            //delete the user
            if (netUserID != null)
            {
                dbcon.NetUsers.DeleteOnSubmit(netUserID);
                dbcon.SubmitChanges();
            }
            //update gridview and text box
            Refresh();
            txtDeleteMemberId.Text = string.Empty;

        }

        //button to delete an instructor from the database
        protected void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            
            var db = new KarateDataContext(conn);


            //find the instructor you want to delete
            var instructorUserID = (from x in dbcon.Instructors
                                    where x.InstructorID == Convert.ToInt32(txtDeleteInstructorId.Text)
                                    select x).First();
            //delete the instructor
            if (instructorUserID != null)
            {
                dbcon.Instructors.DeleteOnSubmit(instructorUserID);
                dbcon.SubmitChanges();
            }
            //find the user you want to delete
            var netUserID = (from x in dbcon.NetUsers
                            where x.UserID == Convert.ToInt32(txtDeleteInstructorId.Text)
                            select x).First();
            //delete the user
            if(netUserID != null)
            {
                dbcon.NetUsers.DeleteOnSubmit(netUserID);
                dbcon.SubmitChanges();
            }
            //update gridview and text box
            Refresh();
            txtDeleteInstructorId.Text = string.Empty; 
        }
    }
}
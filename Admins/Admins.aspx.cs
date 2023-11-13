using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            dbcon = new KarateDataContext(conn);

            
            var resultInstruct = from instructor in dbcon.Instructors
                         select new
                         {
                             instructor.InstructorLastName,
                             instructor.InstructorFirstName,
                         };

            adminGridViewInstructor.DataSource = resultInstruct;
            adminGridViewInstructor.DataBind();

            var resultMember = from karMember in dbcon.Members
                         select new
                         {
                             karMember.MemberLastName,
                             karMember.MemberFirstName,
                             karMember.MemberPhoneNumber,
                             karMember.MemberDateJoined
                         };

            adminGridViewMember.DataSource = resultMember;
            adminGridViewMember.DataBind();
            Refresh();
        }

        public void Refresh() 
        {
            dbcon = new KarateDataContext(conn);


            var resultInstruct = from instructor in dbcon.Instructors
                                 select new
                                 {
                                     instructor.InstructorLastName,
                                     instructor.InstructorFirstName,
                                 };

            adminGridViewInstructor.DataSource = resultInstruct;
            adminGridViewInstructor.DataBind();

            var resultMember = from karMember in dbcon.Members
                               select new
                               {
                                   karMember.MemberLastName,
                                   karMember.MemberFirstName,
                                   karMember.MemberPhoneNumber,
                                   karMember.MemberDateJoined
                               };

            adminGridViewMember.DataSource = resultMember;
            adminGridViewMember.DataBind();
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);




            NetUser netuser = new NetUser 
            {
                UserName = txtMemberUserName.Text,
                UserPassword = txtMemberPassword.Text,
                UserType = "Member"
            };
            db.NetUsers.InsertOnSubmit(netuser);
            db.SubmitChanges();

            Member member = new Member 
            {
                MemberFirstName = txtMemberFirstName.Text,
                MemberPhoneNumber = txtMemberPhoneNumber.Text,
                MemberLastName = txtMemberLastName.Text,
                MemberEmail = txtMemberEmail.Text,
                Member_UserID = netuser.UserID,
                MemberDateJoined = DateTime.Now
            };

            
            db.Members.InsertOnSubmit(member);
            db.SubmitChanges();
            Refresh();

            txtMemberEmail.Text = string.Empty;
            txtMemberFirstName.Text = string.Empty;
            txtMemberLastName.Text = string.Empty;
            txtMemberPassword.Text = string.Empty;
            txtMemberUserName.Text = string.Empty;
            txtMemberPhoneNumber.Text = string.Empty;
            
          
        }

        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);

            

            var netuser = new NetUser();
            
            netuser.UserName = txtInstructorUserName.Text;
            netuser.UserPassword = txtInstructorPassword.Text;
            netuser.UserType = "Instructor";

            db.NetUsers.InsertOnSubmit(netuser);
            db.SubmitChanges();

            var instructor = new Instructor();
            instructor.InstructorFirstName = txtInstructorFirstName.Text;
            instructor.InstructorPhoneNumber = txtInstructorPhone.Text;
            instructor.InstructorLastName = txtInstructorLastName.Text;
            instructor.InstructorID = netuser.UserID;

            db.Instructors.InsertOnSubmit(instructor);
            db.SubmitChanges();


            Refresh();
            txtInstructorFirstName.Text = string.Empty;
            txtInstructorLastName.Text = string.Empty;
            txtInstructorPassword.Text = string.Empty;
            txtInstructorUserName.Text = string.Empty;
            txtInstructorPhone.Text = string.Empty;
        }

        protected void btnAssignMemberToSection_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);



            Section section = db.Sections.FirstOrDefault(item => item.SectionID == Convert.ToInt32(txtSectionId.Text));

            if (section != null) 
            { 
                section.Member_ID = Convert.ToInt32(txtMemberId.Text);
                db.SubmitChanges();
            }

            txtMemberId.Text = string.Empty;
            txtSectionId.Text = string.Empty;
        }

        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            
            var db = new KarateDataContext(conn);

            

            var memberUserID = (from x in dbcon.Members
                                    where x.Member_UserID == Convert.ToInt32(txtDeleteMemberId.Text)
                                    select x).First();

            if (memberUserID != null)
            {
                dbcon.Members.DeleteOnSubmit(memberUserID);
                dbcon.SubmitChanges();
            }

            var netUserID = (from x in dbcon.NetUsers
                                where x.UserID == Convert.ToInt32(txtDeleteMemberId.Text)
                                select x).First();

            if (netUserID != null)
            {
                dbcon.NetUsers.DeleteOnSubmit(netUserID);
                dbcon.SubmitChanges();
            }
           
            Refresh();
            txtDeleteMemberId.Text = string.Empty;

        }

        protected void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            
            var db = new KarateDataContext(conn);



            var instructorUserID = (from x in dbcon.Instructors
                                    where x.InstructorID == Convert.ToInt32(txtDeleteInstructorId.Text)
                                    select x).First();

            if (instructorUserID != null)
            {
                dbcon.Instructors.DeleteOnSubmit(instructorUserID);
                dbcon.SubmitChanges();
            }

            var netUserID = (from x in dbcon.NetUsers
                            where x.UserID == Convert.ToInt32(txtDeleteInstructorId.Text)
                            select x).First();

            if(netUserID != null)
            {
                dbcon.NetUsers.DeleteOnSubmit(netUserID);
                dbcon.SubmitChanges();
            }

            Refresh();
            txtDeleteInstructorId.Text = string.Empty; 
        }
    }
}
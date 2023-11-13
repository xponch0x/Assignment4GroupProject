﻿using Microsoft.Ajax.Utilities;
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
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ehofm\\Desktop\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
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

            var member = new Member();
            member.MemberFirstName = txtMemberFirstName.Text;
            member.MemberPhoneNumber = txtMemberPhoneNumber.Text;
            member.MemberLastName = txtMemberLastName.Text;
            member.MemberEmail = txtMemberEmail.Text;

            var netuser = new NetUser();
            netuser.UserName = txtMemberUserName.Text;
            netuser.UserPassword = txtMemberPassword.Text;

            db.Members.InsertOnSubmit(member);
            db.NetUsers.InsertOnSubmit(netuser);
            db.SubmitChanges();
            Refresh();

        }

        protected void btnAddInstructor_Click(object sender, EventArgs e)
        {
            var db = new KarateDataContext(conn);

            var instructor = new Instructor();
            instructor.InstructorFirstName = txtInstructorFirstName.Text;
            instructor.InstructorPhoneNumber = txtInstructorPhone.Text;
            instructor.InstructorLastName = txtInstructorLastName.Text;
            

            var netuser = new NetUser();
            netuser.UserName = txtInstructorUserName.Text;
            netuser.UserPassword = txtInstructorPassword.Text;

            db.Instructors.InsertOnSubmit(instructor);
            db.NetUsers.InsertOnSubmit(netuser);
            db.SubmitChanges();
            Refresh();
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
            Refresh();
        }

        protected void btnDeleteMember_Click(object sender, EventArgs e)
        {
            
            var db = new KarateDataContext(conn);

            

            NetUser memberUserID = (from x in dbcon.NetUsers
                                    where x.UserID == Convert.ToInt32(txtDeleteMemberId.Text)
                                    select x).First();

            int id = memberUserID.UserID;



            Member member = dbcon.Members.FirstOrDefault(item => item.Member_UserID == id);
            NetUser netuser = dbcon.NetUsers.FirstOrDefault(item => item.UserID == id);

            if (member != null) 
            { 
                db.Members.DeleteOnSubmit(member);
                db.SubmitChanges();
            }

            if (netuser != null) 
            {
                db.NetUsers.DeleteOnSubmit(netuser);
                db.SubmitChanges();
            }

            Refresh();
        }

        protected void btnDeleteInstructor_Click(object sender, EventArgs e)
        {
            
            var db = new KarateDataContext(conn);



            NetUser instructorUserID = (from x in dbcon.NetUsers
                                    where x.UserID == Convert.ToInt32(txtDeleteInstructorId.Text)
                                    select x).First();

            int id = instructorUserID.UserID;



            Instructor instructor = dbcon.Instructors.FirstOrDefault(item => item.InstructorID == id);
            NetUser netuser = dbcon.NetUsers.FirstOrDefault(item => item.UserID == id);

            if (instructor != null)
            {
                db.Instructors.DeleteOnSubmit(instructor);
                db.SubmitChanges();
            }

            if (netuser != null)
            {
                db.NetUsers.DeleteOnSubmit(netuser);
                db.SubmitChanges();
            }

            Refresh();
        }
    }
}
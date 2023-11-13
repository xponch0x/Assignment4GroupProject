using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4GroupProject.Members
{
    public partial class Members : System.Web.UI.Page
    {

        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ehofm\\Desktop\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {

            //FIX need to show section name, instructors first and last names, payment date, and amount of all payments made by the current member
            dbcon = new KarateDataContext(conn);

            string myMember = "mollyl";

            int userId = (from x in dbcon.NetUsers
                             where x.UserName == myMember
                             select x).First().UserID;

            int memberId = userId;

            int sectionId = (from x in dbcon.Sections
                             where x.Member_ID == memberId
                             select x).First().SectionID;

            int instructorId = (from x in dbcon.Sections
                                where x.SectionID == sectionId
                                select x).First().Instructor_ID;

            var result = from user in dbcon.NetUsers
                         from member in dbcon.Members
                         from instructor in dbcon.Instructors
                         from section in dbcon.Sections
                         where section.Member_ID == memberId && section.SectionID == sectionId && instructor.InstructorID == instructorId
                         select new { section.SectionName, instructor.InstructorLastName, instructor.InstructorFirstName, member.MemberDateJoined, section.SectionFee };

            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}
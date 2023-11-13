using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4GroupProject.Instructors
{
    public partial class Instructors : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ehofm\\Desktop\\Assignment4GroupProject\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        KarateDataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //FIX need to show section name and all the member first and last name

            dbcon = new KarateDataContext(conn);

            string myInstruct = "allyjohnson";

            int userId = (from x in dbcon.NetUsers
                          where x.UserName == myInstruct
                          select x).First().UserID;

            int instructId = userId;

            int sectionId = (from x in dbcon.Sections
                             where x.Instructor_ID == instructId
                             select x).First().SectionID;

            int memberId = (from x in dbcon.Sections
                                where x.SectionID == sectionId
                                select x).First().Member_ID;

            var result = from user in dbcon.NetUsers
                         from member in dbcon.Members
                         from instructor in dbcon.Instructors
                         from section in dbcon.Sections
                         where section.Instructor_ID == instructId && section.SectionID == sectionId && member.Member_UserID == memberId
                         select new { section.SectionName, member.MemberLastName, member.MemberFirstName };

            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}
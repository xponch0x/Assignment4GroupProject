using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
            

            dbcon = new KarateDataContext(conn);

            string myInstruct = LoginName1.ToString();

            NetUser instructUserID = (from x in dbcon.NetUsers
                                      where x.UserName == myInstruct
                                      select x).First();

            int id = instructUserID.UserID;



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

            GridView1.DataSource = result;
            GridView1.DataBind();

        }

        
    }
}
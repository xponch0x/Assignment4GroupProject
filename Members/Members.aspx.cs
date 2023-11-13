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

            
            dbcon = new KarateDataContext(conn);

            string myMember = LoginName1.ToString();



            NetUser memberUserID = (from x in dbcon.NetUsers
                                    where x.UserName == myMember
                                    select x).First();

            int id = memberUserID.UserID;



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

            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}
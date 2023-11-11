using System;
using System.Collections.Generic;
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

            //FIX need to show sectrion name, instructors first and last names, payment date, and amount of all payments made by the current member
            dbcon = new KarateDataContext(conn);

            string myMem = "user1";

            int memberData = (from x in dbcon.NetUsers
                                where x.UserName == myMem
                              select x).First().UserID;

            var result = from item in dbcon.Members
                         where item.Member_UserID == memberData
                         select item;

            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}
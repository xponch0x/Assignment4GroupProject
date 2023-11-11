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

            dbcon = new KarateDataContext(conn);

            string mymEMBER = "user1";

            int ridForMember = (from x in dbcon.NetUsers
                                where x.UserName == mymEMBER
                                select x).First().UserID;

            var result = from item in dbcon.Members
                         where item.Member_UserID == ridForMember
                         select item;
            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Website.Models;

namespace Website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] pizzaNames = LogicHelper.GetItemNames("Pizza");
            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                for (int i = 0; i < pizzaNames.Length; i++)
                {
                    string[] pizza = LogicHelper.GetItem("Pizza", pizzaNames[i]);
                    dt.Rows.Add(pizza[1], pizza[2] + " kr,-");
                    dt.Rows.Add(string.Join(", ", LogicHelper.GetPizza(pizzaNames[i])), "");
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] toppings = this.Sear
        }
    }
}
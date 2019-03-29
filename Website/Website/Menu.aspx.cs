using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Xml;
using Website.Models;

namespace Website
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = GetPizzas(searchBar.Value);
            GridView1.DataBind();
        }
        public void GetPizzas(object sender, EventArgs e)
        {
            GridView1.DataSource = GetPizzas(searchBar.Value);
            GridView1.DataBind();
        }
        public static DataTable GetPizzas(string topping)
        {
            string[] toppings = topping.Split(',');
            if (string.IsNullOrEmpty(topping)) toppings = new string[0];
            string[] pizzaTemp = LogicHelper.GetItemNames("Pizza");
            List<string[]> pizzas = new List<string[]>();
            foreach (string pizza in pizzaTemp)
            {
                string[] toppingsOnPizza = LogicHelper.GetPizza(pizza);
                bool contains = true;
                for (int i = 0; i < toppings.Length && contains; i++)
                {
                    if (!toppingsOnPizza.Contains(toppings[i]))
                        contains = false;
                }
                if(contains)
                    pizzas.Add(LogicHelper.GetItem("Pizza", pizza));
            }
            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                foreach (var pizza in pizzas)
                {
                    dt.Rows.Add(pizza[0],pizza[1], pizza[2] + " kr,-");
                    dt.Rows.Add("",string.Join(", ", LogicHelper.GetPizza(pizza[1])));
                }
                return dt;
            }
        }
    }
}
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
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");
                string[][] pizzas = LogicHelper.GetItems("Pizza");
                for (int i = 0; i < pizzaNames.Length; i++)
                {
                    dt.Rows.Add(pizzas[i][0],pizzas[i][1], pizzas[i][2] + " kr,-");
                    dt.Rows.Add("",string.Join(", ", LogicHelper.GetPizza(pizzaNames[i])), "");
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        public void GetPizzas(object sender, EventArgs e)
        {
            string[] toppings = searchBar.Value.Split(',');
            List<string> pizzas = LogicHelper.GetItemNames("Pizza").ToList();
            string[] pizzaTemp = pizzas.ToArray();
            foreach (string pizza in pizzaTemp)
            {
                string[] toppingsOnPizza = LogicHelper.GetPizza(pizza);
                for (int i = 0; i < toppings.Length && pizzas.Contains(pizza); i++)
                {
                    if (!toppingsOnPizza.Contains(toppings[i])) pizzas.Remove(pizza);
                }
            }
            string[][] pizzaItems = new string[pizzas.Count][];
            for (int i = 0; i < pizzaItems.Length; i++)
            {
                pizzaItems[i] = LogicHelper.GetItem("Pizza", pizzas[i]);
            }
            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                dt.Columns.Add("Price");

                foreach (var pizza in pizzaItems)
                {
                    dt.Rows.Add(pizza[0],pizza[1], pizza[2] + " kr,-");
                    dt.Rows.Add("",string.Join(", ", LogicHelper.GetPizza(pizza[1])), "");
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
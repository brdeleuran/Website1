using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.Models;

namespace Website
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void CreateItem(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameSearch.Value) &&
                !string.IsNullOrEmpty(priceSearch.Value))
            {
                LogicHelper.CreateItem("Pizza",nameSearch.Value,int.Parse(priceSearch.Value));
            }
        }
        public void UpdateItem(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idSearch.Value))
            {

            }
        }
        public void ReadItem(object sender, EventArgs e)
        {
            gridViewPizza.DataSource = GetPizzas(null);
            gridViewPizza.DataBind();
        }
        public void DeleteItem(object sender, EventArgs e)
        {

        }
        public static DataTable GetPizzas(string topping)
        {
            string[] toppings;
            if (string.IsNullOrEmpty(topping)) 
                toppings = new string[0];
            else
                toppings = topping.Split(',');
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
using System.Configuration;

namespace Website.Models
{
    public class LogicHelper
    {
        static readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["PizzaDB"].ConnectionString;

        public static void CreateItem(string tableName, string itemName, int price)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                database.NonQueryProcedure("CreateItem", new[] { "TableName", "ItemName", "Price" }, new[] { tableName, itemName, price.ToString() });
            }
        }

        public static void PutToppingOnPizza(string pizzaName, string[] toppingNames)
        {
            foreach (string toppingName in toppingNames)
            {
                PutToppingOnPizza(pizzaName, toppingName);
            }
        }

        public static void PutToppingOnPizza(string pizzaName, string toppingName)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                database.NonQueryProcedure("PutToppingOnPizza", new[] { "PizzaName", "ToppingName" }, new[] { pizzaName, toppingName });
            }
        }

        public static string[] GetPizza(string pizzaName)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                return database.QueryProcedure1D("GetPizza", new[] { "PizzaName" }, new[] { pizzaName });
            }
        }

        public static string[] GetPizzaNameByTopping(string toppingName)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                return database.QueryProcedure1D("GetPizzaByTopping", new[] { "ToppingName" }, new[] { toppingName });
            }
        }

        public static string[][] GetPizzaByTopping(string toppingName)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                string[] pizzaNames = database.QueryProcedure1D("GetPizzaByTopping", new[] { "ToppingName" }, new[] { toppingName });
                string[][] output = new string[pizzaNames.Length][];
                for (int i = 0; i < pizzaNames.Length; i++)
                {
                    output[i] = GetItem("Pizza", pizzaNames[i]);
                }
                return output;
            }
        }

        public static string[][] GetPizzaToppingsByTopping(string toppingName)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                string[] pizzaNames = database.QueryProcedure1D("GetPizzaByTopping", new[] { "ToppingName" }, new[] { toppingName });
                string[][] output = new string[pizzaNames.Length][];
                for (int i = 0; i < pizzaNames.Length; i++)
                {
                    output[i] = GetPizza(pizzaNames[i]);
                }
                return output;
            }
        }

        public static string[] GetItem(string itemTable, string itemName)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                return database.Query1D("*", itemTable, "WHERE Name='" + itemName + "'");
            }
        }

        public static string[][] GetItems(string itemTable)
        {
            using (DatabaseHelper database = new DatabaseHelper(sqlConnectionString))
            {
                return database.Query("*", itemTable, "");
            }
        }
    }
}
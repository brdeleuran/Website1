using System.Configuration;

namespace Website.Models
{
    public class LogicHelper
    {

        public static void CreateItem(string tableName, string itemName, int price)
        {
            using (DatabaseHelper database = new DatabaseHelper())
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
            using (DatabaseHelper database = new DatabaseHelper())
            {
                database.NonQueryProcedure("PutToppingOnPizza", new[] { "PizzaName", "ToppingName" }, new[] { pizzaName, toppingName });
            }
        }

        public static string[] GetPizza(string pizzaName)
        {
            using (DatabaseHelper database = new DatabaseHelper())
            {
                return database.QueryProcedure1D("GetPizza", new[] { "PizzaName" }, new[] { pizzaName });
            }
        }

        public static string[] GetPizzaNameByTopping(string toppingName)
        {
            using (DatabaseHelper database = new DatabaseHelper())
            {
                return database.QueryProcedure1D("GetPizzaByTopping", new[] { "ToppingName" }, new[] { toppingName });
            }
        }

        public static string[][] GetPizzaByTopping(string toppingName)
        {
            using (DatabaseHelper database = new DatabaseHelper())
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
            using (DatabaseHelper database = new DatabaseHelper())
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
            using (DatabaseHelper database = new DatabaseHelper())
            {
                return database.QueryProcedure1D("GetItem", new []{"TableName","ItemName"},new []{itemTable,itemName});
            }
        }

        public static string[][] GetItems(string itemTable)
        {
            using (DatabaseHelper database = new DatabaseHelper())
            {
                return database.Query("*", itemTable, "");
            }
        }

        public static string[] GetItemNames(string item)
        {
            using (DatabaseHelper database = new DatabaseHelper())
            {
                return database.Query1D("Name", item, "ORDER BY ID");
            }
        }
        public static string[][] GetItemsWithoutId(string itemTable)
        {
            using (DatabaseHelper database = new DatabaseHelper())
            {
                return database.Query("Name, Price", itemTable, "");
            }
        }

    }
}
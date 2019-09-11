namespace Inventory_management.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class DBModels : DbContext
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=inventorymgt;password=password;allowuservariables=True");

       

        public DBModels(): base("name=DBModels")
        {
        }

        public List<income> incomeData()
        {
           
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM income", con);

            var model = new List<income>();
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DateTime dt = System.DateTime.Parse(rdr["date"].ToString());
                var income = new income();
                income.id = int.Parse(rdr["id"].ToString());
                income.date = dt.ToString("yyyy-MM-dd");
                income.category = rdr["category"].ToString();
                income.cash = Double.Parse(rdr["cash"].ToString());
                income.pos = Double.Parse(rdr["pos"].ToString());
                income.total = Double.Parse(rdr["amount"].ToString());
                model.Add(income);
            }

            return model;
        }

        public void incomeInsert(income income)
        {
            
            MySqlCommand cmd = new MySqlCommand("INSERT INTO income (date, category, cash, pos, amount) VALUES (@date, @category, @cash, @pos, @total)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@date", income.date);
            cmd.Parameters.AddWithValue("@category", income.category);
            cmd.Parameters.AddWithValue("@cash", income.cash);
            cmd.Parameters.AddWithValue("@pos", income.pos);
            cmd.Parameters.AddWithValue("@total", income.total);

            cmd.ExecuteNonQuery();


        }

        public void incomeEdit(income income)
        {
            

            MySqlCommand cmd = new MySqlCommand("UPDATE income SET date = @date, category = @category, cash = @cash, pos = @pos, amount = @total WHERE id = @id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@date", income.date);
            cmd.Parameters.AddWithValue("@category", income.category);
            cmd.Parameters.AddWithValue("@cash", income.cash);
            cmd.Parameters.AddWithValue("@pos", income.pos);
            cmd.Parameters.AddWithValue("@total", income.total);
            cmd.Parameters.AddWithValue("@id", income.id);

            cmd.ExecuteNonQuery();


        }

        public void deleteIncome(income income)
        {

            MySqlCommand cmd = new MySqlCommand("delete from income where id = @id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", income.id);

            cmd.ExecuteNonQuery();


        }

        public List<daily> dailyData()
        {
            

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM daily", con);

            var model = new List<daily>();
            con.Open();

            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DateTime dt = System.DateTime.Parse(rdr["date"].ToString());
                var daily = new daily();
                daily.id = int.Parse(rdr["id"].ToString());
                daily.date = dt.ToString("yyyy-MM-dd");
                daily.category = rdr["category"].ToString();
                daily.savings = Double.Parse(rdr["savings"].ToString());
                daily.amount = Double.Parse(rdr["amount"].ToString());
                model.Add(daily);
            }

            return model;
        }

        public void deleteDaily(daily daily)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from daily where id = @id", con);
            
            cmd.Parameters.AddWithValue("@id", daily.id);

            cmd.ExecuteNonQuery();
        }

        public void editDaily(daily daily)
        {

            MySqlCommand cmd = new MySqlCommand("UPDATE daily SET date = @date, category = @category, savings = @savings, amount = @amount WHERE id = @id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@date", daily.date);
            cmd.Parameters.AddWithValue("@category", daily.category);
            cmd.Parameters.AddWithValue("@savings", daily.savings);
            cmd.Parameters.AddWithValue("@amount", daily.amount);
            cmd.Parameters.AddWithValue("@id", daily.id);

            cmd.ExecuteNonQuery();
        }

        public void dailyInsert(daily daily)
        {
         

            MySqlCommand cmd = new MySqlCommand("INSERT INTO daily (date, category, savings, amount) VALUES (@date, @category, @savings, @amount)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@date", daily.date);
            cmd.Parameters.AddWithValue("@category", daily.category);
            cmd.Parameters.AddWithValue("@savings", daily.savings);
            cmd.Parameters.AddWithValue("@amount", daily.amount);

            cmd.ExecuteNonQuery();

        }

    }

    public class income
    {
        public int id { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public Double cash { get; set; }
        public Double pos { get; set; }
        public Double total { get; set; }
    }

    public class daily
    {
        public int id { get; set; }
        public string date { get; set; }
        public string category { get; set; }
        public Double savings { get; set; }
        public Double amount { get; set; }

    }

}
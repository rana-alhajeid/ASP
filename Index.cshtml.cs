using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
namespace Person2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public DataSet Person {  get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string connectionString = "server=(localdb)\\mssqllocaldb;Integrated Security=True; DATABASE=personDB";
            string sqlQuery = "select * from Person";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            SqlDataAdapter sda = new SqlDataAdapter(sc);

             Person = new DataSet();

            sda.Fill(Person);

            con.Close();
        }
        public void OnPost()
        {
            string Name = Request.Form["Name"];
            string Mobile = Request.Form["Mobile"];
            string Address = Request.Form["Address"];


            string connectionString = "server=(localdb)\\mssqllocaldb;Integrated Security=True; DATABASE=personDB";
            string sqlQuery = "INSERT INTO PERSON (Name, Mobile,Address)VALUES(" + "'" + Name + "'" + ", " + "'" + Mobile + "'" + ", " + "'" + Address + "'" + ")";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand sc = new SqlCommand(sqlQuery, con);
            sc.ExecuteNonQuery();
            con.Close();
            OnGet();

        }
    }
}

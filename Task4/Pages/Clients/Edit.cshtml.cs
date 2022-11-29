using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Task4.Pages.Clients
{
    public class EditModel : PageModel
    {
        internal ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["ID"];

            try
            {
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost()
        {
            clientInfo.id = Request.Form["ID"];
            clientInfo.name = Request.Form["name"];
            clientInfo.email = Request.Form["email"];


            if (clientInfo.id.Length==0 || clientInfo.name.Length == 0 || clientInfo.email.Length == 0)
            {
                errorMessage = "Необходимо заполнить все поля";
                return;
            }

            try
            {
                String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MyDataBase;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients " +
                                 "(name, email) VALUES " +
                                 "(@name, @email)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", clientInfo.name);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Clients/Index");
        }
    }
}

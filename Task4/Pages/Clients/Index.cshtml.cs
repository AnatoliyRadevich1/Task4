using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Task4.Pages.Clients
{
    public class IndexModel : PageModel
    {
        internal List<ClientInfo> listClients = new List<ClientInfo>();
        
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=MyDataBase;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = ""+reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.registration_date = reader.GetString(3);
                                clientInfo.date_of_last_visit = reader.GetString(4);
                                clientInfo.status = reader.GetDateTime(5).ToString();

                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception "+ex.ToString());
            }
        }
    }
    class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String registration_date;
        public String date_of_last_visit;
        public String status;
    }
}

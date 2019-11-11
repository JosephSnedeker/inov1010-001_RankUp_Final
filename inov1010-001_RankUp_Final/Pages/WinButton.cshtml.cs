using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

using System.Drawing;

using System.Text;



namespace inov1010_001_RankUp_Final.Pages
{
    
    public class WinButtonModel : PageModel
    {
        
        
        public void OnPost(int scoreplayera, int scoreplayerb)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-inov1010_001_RankUp_Final-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";
            SqlConnection cnn = new SqlConnection(connectionString);

            cnn.Open();
            string sql = "UPDATE AspNetUsers SET UserName= @test";
            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.Parameters.AddWithValue("@test", scoreplayera);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();
            
            
          
        }
    }
}

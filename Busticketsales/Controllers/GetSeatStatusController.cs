using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Busticketsales.Controllers
{
    public class GetSeatStatusController : Controller
    {
        protected void GetSeatStatus()
        {
            // Kết nối và thực hiện truy vấn đến cơ sở dữ liệu để lấy trạng thái ghế
            using (SqlConnection connection = new SqlConnection("Server=localhost;Database=Busticketsales; Integrated Security=True;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Seat, Status FROM CustomerOrder", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<object> seatStatusList = new List<object>();
                        while (reader.Read())
                        {
                            int Seat = (int)reader["Seat"];
                            int Status = (int)reader["Status"];
                            seatStatusList.Add(new { Seat, Status });
                        }
                        string json = JsonConvert.SerializeObject(seatStatusList);
                        Response.ContentType = "application/json";
                        Response.WriteAsync(json);
                    }
                }
            }
        }

    }
}

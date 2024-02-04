using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoAppController : ControllerBase
    {
        private IConfiguration _configuration;

        public TodoAppController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes()
        {
            string query = "select * from dbo.notes";
            var table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("todoAppDBCon");
            SqlDataReader reader;
            using (var con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (var command = new SqlCommand(query, con))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }

                return new JsonResult(table);
            }
        }

        [HttpPost]
        [Route("AddNotes")]
        public JsonResult GetNotes([FromForm] string newNotes)
        {
            string query = "insert into dbo.notes values(@newNotes)";
            var table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("todoAppDBCon");
            SqlDataReader reader;
            using (var con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (var command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@newNotes", newNotes);
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }

                return new JsonResult("Added Successfully");
            }
        }
    }
}

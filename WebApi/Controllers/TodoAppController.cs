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

        [HttpDelete]
        [Route("DeleteNotes")]
        public JsonResult DeleteNotes(int id)
        {
            string query = "delete from dbo.notes where id=@id";
            var table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("todoAppDBCon");
            SqlDataReader reader;
            using (var con = new SqlConnection(sqlDatasource))
            {
                con.Open();
                using (var command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@id", id);
                    reader = command.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }

                return new JsonResult("Deleted Successfully");
            }
        }


    }
}

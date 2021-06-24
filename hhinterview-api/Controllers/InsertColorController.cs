using hhinterview_api.Classes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace hhinterview_api.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("api/insertColor")]
    public class InsertColorController : ControllerBase
    {
        [HttpPost]
        public dynamic InsertColor([FromBody] InsertColorRequest parma)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=color-database.cneyddwe6evi.us-east-1.rds.amazonaws.com;initial catalog=ColorDb;user id=colorUser;password=Purple99!;MultipleActiveResultSets=True";
            var sCommand = new SqlCommand(@"
              Insert Into
                Color(hexString, colorName)
                Values(@hexString, @colorName)

            ", conn);

            sCommand.Parameters.AddWithValue("@hexString", parma.hexString);
            sCommand.Parameters.AddWithValue("@colorName", parma.colorName);


            var dataTable = SqlHelper.SQLCommandTableInsert(sCommand);


            return "Success";


        }

    }
}
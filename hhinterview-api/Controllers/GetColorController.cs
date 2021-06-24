using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace hhinterview_api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/getcolors")]
    [ApiController]
    public class GetColorController : ControllerBase
    {
        [HttpPost]
        public dynamic GetColors()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source=color-database.cneyddwe6evi.us-east-1.rds.amazonaws.com;initial catalog=ColorDb;user id=colorUser;password=Purple99!;MultipleActiveResultSets=True";
            var sCommand = new SqlCommand(@"
              Select * From Color

            ", conn);

            var dataTable = SqlHelper.SQLCommandToDataTable(sCommand);
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);

            return json;
        }



    }
}

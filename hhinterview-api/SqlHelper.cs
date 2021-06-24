using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace hhinterview_api
{
    public static class SqlHelper
    {
        public static DataTable SQLCommandToDataTable(SqlCommand sCommand)
        {
            var dt = new DataTable();

            var connectionState = sCommand.Connection;
            try
            {
                if (connectionState != null && connectionState.State == ConnectionState.Closed)
                {
                    connectionState.Open();
                }
                using (var reader = sCommand.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            catch // (Exception ex)
            {
                // error handling
                throw;
            }
            return dt;
        }

        public static int SQLCommandTableInsert(SqlCommand sCommand)
        {
            var dt = new DataTable();

            var connectionState = sCommand.Connection;

            try
            {
                if (connectionState != null && connectionState.State == ConnectionState.Closed)
                {
                    connectionState.Open();
                }

                object respId = sCommand.ExecuteScalar();
                if (respId != null)
                    return (int)(decimal)respId;
                else
                    return -1;
            }
            catch // (Exception ex)
            {
                // error handling
                throw;
            }

        }
    }
}

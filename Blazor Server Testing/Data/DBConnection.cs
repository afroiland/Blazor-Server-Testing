using Dapper;
using Microsoft.Data.SqlClient;
using Blazor_Server_Testing.Models;
using System.Collections.Generic;

namespace Blazor_Server_Testing.DB_Connection

{
    public class DBConnection
    {
        public static List<CharacterModel> QueryDB(string connectionString, string query)
        {
            List<CharacterModel> listResult = new();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<CharacterModel>(query);

                //TODO: Pull this out into its own method and have QueryDB return result, no?
                foreach (var x in result)
                {
                    listResult.Add(x);
                }
            }

            return listResult;
        }
    }
}

using Dapper;
using Microsoft.Data.SqlClient;
using Blazor_Server_Testing.Models;
using System.Collections.Generic;

namespace Blazor_Server_Testing.DB_Connection

{
    public class DBConnection
    {
        public static List<CharacterModel> GetCharactersFromDB(string connectionString, string query)
        {
            List<CharacterModel> listResult = new();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<CharacterModel>(query);

                foreach (var x in result)
                {
                    listResult.Add(x);
                }
            }

            return listResult;
        }

        public static void UpdateDB(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query(query);
            }
        }
    }
}

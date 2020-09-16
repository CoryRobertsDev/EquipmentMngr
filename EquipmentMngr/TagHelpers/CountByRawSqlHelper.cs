using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EquipmentManager.Helpers
{
    public static class CountByRawSqlHelper
    {
        public static int CountByRawSql(this DbContext dbContext, string sql,
            params KeyValuePair<string, object>[] parameters)
        {
            var result = -1;
            var connection = dbContext.Database.GetDbConnection() as SqlConnection;

            try
            {
                if (connection != null)
                {
                    connection.Open();

                    using var command = connection.CreateCommand();
                    command.CommandText = sql;

                    foreach (var parameter in parameters)
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                    using DbDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                        while (dataReader.Read())
                            result = dataReader.GetInt32(0);
                }
            }

            // We should have better error handling here
            catch (Exception)
            {
            }

            finally
            {
                connection?.Close();
            }

            return result;
        }
    }
}
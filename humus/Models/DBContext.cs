using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace humus.Models
{
    public class DBContext
    {
        public const string ConnectionString = "DefaultConnection";
        public string ConnectionStringConfig;
        public List<SqlParameter> SqlParameters;


        public DBContext()
        {
            ConnectionStringConfig = ConfigurationManager.ConnectionStrings[ConnectionString].ConnectionString;
            SqlParameters = new List<SqlParameter>();
        }

        public DBContext(string connectionString)
        {
            ConnectionStringConfig = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            SqlParameters = new List<SqlParameter>();
        }


        public DataSet SqlExecute(string SQL)
        {
            var connection = new SqlConnection(ConnectionStringConfig);

            var command = new SqlCommand(SQL, connection);

            var ds = new DataSet();
            string query = "";

            foreach (SqlParameter item in SqlParameters)
            {
                command.Parameters.Add(item);
            }

            foreach (SqlParameter p in command.Parameters)
            {
                query = query.Replace(p.ParameterName, p.Value.ToString());
                if (p.Value.ToString() != "")
                {
                    string xxx = "";
                }
            }

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            try
            {
                connection.Open();

                Adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

        }



        public DataRow SqlExecuteRow(string SQL)
        {
            var connection = new SqlConnection(ConnectionStringConfig);
            var command = new SqlCommand(SQL, connection);


            foreach (SqlParameter item in SqlParameters)
            {
                command.Parameters.Add(item);
            }

            SqlDataAdapter Adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();



            try
            {
                connection.Open();

                Adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                    return ds.Tables[0].Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

        }

        public object SqlExecuteScalar(string SQL)
        {
            var connection = new SqlConnection(ConnectionStringConfig);
            var command = new SqlCommand(SQL, connection);

            foreach (SqlParameter item in SqlParameters)
            {
                command.Parameters.Add(item);
            }

            try
            {
                connection.Open();

                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

        }
        public int SqlExecuteNonQuery(string SQL)
        {
            var connection = new SqlConnection(ConnectionStringConfig);
            var command = new SqlCommand(SQL, connection);
            string errorMessages = "";

            foreach (SqlParameter item in SqlParameters)
            {
                command.Parameters.AddWithValue(item.ParameterName, item.Value);
            }

            try
            {

                string query = command.CommandText;

                foreach (SqlParameter p in command.Parameters)
                {
                    query = query.Replace(p.ParameterName, p.Value.ToString());
                    if (p.Value.ToString() != "")
                    {
                        string xxx = "";
                    }
                }
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages = "Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n";
                }
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();

            }
        }
    }
}
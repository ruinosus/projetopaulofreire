using System;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Collections.Generic;

namespace Ppf.ModuloConexao
{
    public static class BancoConexao
    {
        #region Atributos

        private static Dictionary<string, SqlConnection> connectionPool = new Dictionary<string, SqlConnection>();

        #endregion

        #region Gets

        public static SqlCommand GetSqlCommand()
        {
            try
            {
                return GetSqlConnection().CreateCommand();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static SqlTransaction GetSqlTransaction()
        {
            try
            {
                return GetSqlConnection().BeginTransaction();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static SqlTransaction GetSqlTransaction(string nomeTransacao)
        {
            try
            {
                return GetSqlConnection().BeginTransaction(nomeTransacao);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Métodos Utilitários

        private static SqlConnection GetSqlConnection()
        {
            try
            {
                if (connectionPool.ContainsKey(Session()))
                {
                    if (!Conectado(connectionPool[Session()]))
                    {
                        Conectar(connectionPool[Session()]);
                    }
                }
                else
                {
                    CreateConnection();
                }

                return connectionPool[Session()];
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static bool Conectado(SqlConnection sqlConnection)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                return true;
            }

            return false;
        }

        private static void Conectar(SqlConnection sqlConnection)
        {
            sqlConnection.Open();
        }

        private static string Session()
        {
            //return HttpContext.Current.Session.SessionID;

            return HttpContext.Current.Request.GetHashCode().ToString();
        }

        #endregion

        #region Métodos Públicos
        
        public static SqlConnection CreateConnection()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ppf"].ConnectionString);
                sqlConnection.Open();


                connectionPool.Add(Session(), sqlConnection);

                return sqlConnection;
            }
            catch (Exception)
            {
                ReleaseConnection();
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Ppf"].ConnectionString);
                sqlConnection.Open();
                connectionPool.Add(Session(), sqlConnection);

                return sqlConnection;
            }

            return null;
        }

        public static void ReleaseConnection()
        {
            try
            {
                if (connectionPool.ContainsKey(Session()))
                {
                    if (Conectado(connectionPool[Session()]))
                    {
                        connectionPool[Session()].Close();

                        connectionPool[Session()].Dispose();

                        connectionPool.Remove(Session());
                    }
                }
            }
            catch (Exception)
            { }
        }

        #endregion
    }
}
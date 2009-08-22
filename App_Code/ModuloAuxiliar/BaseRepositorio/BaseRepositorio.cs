using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Ppf.ModuloConexao;



namespace Ppf.ModuloAuxiliar.BaseRepositorio
{
    public class BaseRepositorio
    {
        #region Atributos

        /// <summary>
        /// Atributo do Tipo SqlCommand usado para executar os comandos SQL.
        /// </summary>
        protected SqlCommand sqlCommand;

        /// <summary>
        /// Atributo do Tipo SqlTransaction usado para manter as transações.
        /// </summary>
        protected SqlTransaction sqlTransaction;

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public BaseRepositorio()
        {
        }

        #endregion

        #region Destrutor

        /// <summary>
        /// Destrutor da Classe
        /// </summary>
        ~BaseRepositorio()
        {
            if (sqlCommand != null)
            {
                sqlCommand.Dispose();
            }

            if (sqlTransaction != null)
            {
                sqlTransaction.Dispose();
            }
        }

        #endregion

        #region Métodos de Manipulação de Parametros SQL

        /// <summary>
        /// Adiciona um parâmetro ao sqlCommand
        /// </summary>
        /// <param name="nome">Nome do parâmetro</param>
        /// <param name="valor">Valor do parâmetro</param>
        protected void AdicionarParametro(string nome, object valor)
        {
            CriarSqlCommand();

            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = nome;
            sqlParameter.Value = valor;

            sqlCommand.Parameters.Add(sqlParameter);
        }

        /// <summary>
        /// Adiciona um parâmetro ao sqlCommand.
        /// </summary>
        /// <param name="parameter">SqlParameter que será passado.</param>
        protected void AdicionarParametro(SqlParameter parameter)
        {
            CriarSqlCommand();

            sqlCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Remove um específico pramêtro do sqlCommand
        /// </summary>
        /// <param name="nome">Nome do parâmetro que será removido</param>
        protected void RemoverParametro(string nome)
        {
            if (sqlCommand.Parameters[nome] != null)
            {
                sqlCommand.Parameters.Remove(sqlCommand.Parameters[nome]);
            }
        }

        /// <summary>
        /// Remove todos os parâmetros do sqlCommand
        /// </summary>
        protected void RemoverParametros()
        {
            if (sqlCommand != null && sqlCommand.Parameters.Count > 0)
                sqlCommand.Parameters.Clear();
        }

        #endregion

        #region Métodos de Execução de Comandos SQL

        /// <summary>
        /// Executa um comando SQL que não retorna um conjunto dados
        /// </summary>
        /// <param name="command">O comando SQL que será executado</param>
        /// <returns>Quantidade de registros afetados</returns>
        protected int ExecuteNonQuery(string command)
        {
            int quantidadeRegistrosAfetados;

            try
            {
                sqlCommand.CommandText = command;
                quantidadeRegistrosAfetados = sqlCommand.ExecuteNonQuery();

                return quantidadeRegistrosAfetados;
            }
            catch (Exception ex)
            {
                //Checa se o erro veio do SQL Server.
                if (ex is SqlException)
                {
                    String message = null;
                    SqlException exSql = ex as SqlException;

                    // Captura exceções pelo número
                    switch (exSql.Number)
                    {
                        case 547: // erro de FK de exclusão.
                            message = Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_EXCLUSAO;
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(message);
                        case 2627: // erro de FK de inclusão.
                            message = Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_INCLUSAO;
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(message);
                        case 2601: // erro de FK de inclusão.
                            message = Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_INCLUSAO;
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(message);
                        default:
                            quantidadeRegistrosAfetados = 0;
                            break;
                    }
                }
                else
                {
                    quantidadeRegistrosAfetados = 0;
                }

                return quantidadeRegistrosAfetados;
            }
            finally
            {
                RemoverParametros();

                DestruirSqlCommand();
            }
        }

        /// <summary>
        /// Executa um comando SQL que não retorna um conjunto dados.
        /// </summary>
        /// <param name="command">O comando SQL que será executado</param>
        /// <returns>Id do registro na tabela.</returns>
        protected int ExecuteNonQuery_ID(string command)
        {
            return ExecuteNonQuery_ID(command, true);
        }

        /// <summary>
        /// Executa um comando SQL que não retorna um conjunto dados.
        /// </summary>
        /// <param name="command">O comando SQL que será executado</param>
        /// <param name="OnErrorResumeNext">Ativar ou desativar tratamento de exceções.</param>
        /// <returns>Id do registro na tabela.</returns>
        protected int ExecuteNonQuery_ID(string command, bool OnErrorResumeNext)
        {
            int ID;

            try
            {
                command = command.Insert(command.Length, " SELECT SCOPE_IDENTITY()");

                ID = Convert.ToInt32(ExecuteScalar(command, OnErrorResumeNext));

                return ID;
            }
            catch (Exception ex)
            {
                //Checa se o erro veio do SQL Server.
                if (ex is SqlException)
                {
                    String message = null;
                    SqlException exSql = ex as SqlException;

                    // Captura exceções pelo número
                    switch (exSql.Number)
                    {
                        case 547: // erro de FK de exclusão.
                            message = Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_EXCLUSAO;
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(message);
                        case 2627: // erro de FK de inclusão.
                            message = Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_INCLUSAO;
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(message);
                        default:
                            ID = 0;
                            break;
                    }
                }
                else if (ex is Ppf.ModuloAuxiliar.Excecoes.GenericException & !OnErrorResumeNext)
                {
                    throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(ex.Message);
                }
                else
                {
                    ID = 0;
                }
                return ID;
            }
        }

        /// <summary>
        /// Executa um comando SQL  que retorna um conjunto de dados
        /// </summary>
        /// <param name="command">O comando SQL  que será executado</param>
        /// <returns>Conjunto de dados retornado pelo comando ou null em caso de erro na consulta</returns>
        public SqlDataReader ExecuteReader(string command)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (sqlCommand == null)
                    CriarSqlCommand();

                sqlCommand.CommandText = command;
                if (!String.IsNullOrEmpty(sqlCommand.CommandText))
                    sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader;
            }
            catch
            {
                return sqlDataReader;
            }
            finally
            {
                RemoverParametros();

                DestruirSqlCommand();
            }
        }

        /// <summary>
        /// Executa um comando SQL que retorna um conjunto de dados
        /// </summary>
        /// <param name="command">O comando SQL que será executado</param>
        /// <returns></returns>
        protected IEnumerator ExcecuteReader(string command)
        {
            IEnumerator iEnumerator;
            SqlDataReader sqlDataReader;

            try
            {
                sqlCommand.CommandText = command;
                sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                iEnumerator = sqlDataReader.GetEnumerator();

                sqlDataReader.Close();

                return iEnumerator;
            }
            catch (SqlException)
            {
                iEnumerator = null;
                return iEnumerator;
            }
            finally
            {
                RemoverParametros();

                DestruirSqlCommand();
            }
        }

        /// <summary>
        /// Executa um comando SQL que retorna apenas um dado.
        /// </summary>
        /// <param name="command">O comando SQL que será executado</param>
        /// <returns>Dado retornado pelo comando</returns>
        protected object ExecuteScalar(string command)
        {
            return ExecuteScalar(command, true);
        }

        /// <summary>
        /// Executa um comando SQL que retorna apenas um dado.
        /// </summary>
        /// <param name="command">O comando SQL que será executado</param>
        /// <param name="OnErrorResumeNext">Ativar ou desativar tratamento de exceções.</param>
        /// <returns>Dado retornado pelo comando</returns>
        protected object ExecuteScalar(string command, bool OnErrorResumeNext)
        {
            object dadoDeRetorno;

            try
            {
                if (sqlCommand == null)
                    CriarSqlCommand();

                sqlCommand.CommandText = command;
                dadoDeRetorno = sqlCommand.ExecuteScalar();

                return dadoDeRetorno;
            }
            catch (SqlException ex)
            {
                if (!OnErrorResumeNext)
                {
                    // Captura exceções pelo número
                    switch (ex.Number)
                    {
                        case 547: // erro de FK de exclusão.
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_EXCLUSAO);
                        case 2627: // erro de FK de inclusão.
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_FK_INCLUSAO);
                        default:
                            throw new Ppf.ModuloAuxiliar.Excecoes.GenericException(Ppf.ModuloAuxiliar.Excecoes.GenericExceptionMessages.ERRO_GENERICO);
                    }
                }
                dadoDeRetorno = null;
                return dadoDeRetorno;
            }
            finally
            {
                RemoverParametros();

                DestruirSqlCommand();
            }
        }

        #endregion

        #region Métodos de Manipulação de Transações

        /// <summary>
        /// Inicia uma Transação
        /// </summary>
        [Obsolete]
        protected void BeginTransaction()
        {
            sqlCommand.Transaction = sqlTransaction;
        }

        /// <summary>
        /// Inicia uma Transação
        /// </summary>
        /// <param name="nomeTransacao">Nome da Transação</param>
        [Obsolete]
        protected void BeginTransaction(string nomeTransacao)
        {
            sqlCommand.Transaction = sqlTransaction;
        }

        /// <summary>
        /// Comita uma Transação
        /// </summary>
        [Obsolete]
        protected void Commit()
        {
            if (sqlTransaction != null)
                sqlTransaction.Commit();
        }

        /// <summary>
        /// Cancela uma Transação
        /// </summary>
        [Obsolete]
        protected void Rollback()
        {
            if (sqlTransaction != null)
                sqlTransaction.Rollback();
        }

        #endregion

        #region Métodos Utilitários

        /// <summary>
        /// Cria um novo objeto do tipo SqlCommand
        /// </summary>
        protected void CriarSqlCommand()
        {
            if (sqlCommand == null)
            {
                sqlCommand = BancoConexao.GetSqlCommand();
            }
        }

        /// <summary>
        /// Destroi um objeto do tipo SqlCommand
        /// </summary>
        protected void DestruirSqlCommand()
        {
            if (sqlCommand != null)
            {
                sqlCommand.Dispose();
                sqlCommand = null;
            }
        }

        #endregion
    }
}
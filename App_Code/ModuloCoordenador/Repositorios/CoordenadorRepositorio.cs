using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ppf.ModuloAuxiliar.BaseFiltro;
using System.Data.SqlClient;
using Ppf.ModuloAuxiliar.Excecoes;
using Ppf.ModuloAuxiliar.BaseRepositorio;
using Ppf.ModuloCoordenador.Filtros;
using Ppf.ModuloCoordenador.Excecoes;

namespace Ppf.ModuloCoordenador.Repositorios
{
    /// <summary>
    /// Summary description for CoordenadorRepositorio
    /// </summary>
    public class CoordenadorRepositorio : BaseRepositorio, ICoordenadorRepositorio
    {
        #region Construtor

        public CoordenadorRepositorio()
            : base()
        { }

        #endregion

        #region Metodos da Interface

        public void Incluir(CoordenadorVO coordenadorVO)
        {
            coordenadorVO.ID = this.ObterProximoCodigo();

            AdicionarParametro("COD_COORDENADOR", coordenadorVO.ID);
            AdicionarParametro("ENTIDADE", coordenadorVO.Entidade);
            AdicionarParametro("NOME", coordenadorVO.Nome);
            AdicionarParametro("DATA_NASCIMENTO", coordenadorVO.DataNascimento);
            AdicionarParametro("ESTADO_CIVIL", coordenadorVO.EstadoCivil);
            AdicionarParametro("NOME_MAE", coordenadorVO.NomeMae);
            AdicionarParametro("NOME_PAI", coordenadorVO.NomePai);
            AdicionarParametro("SEXO", coordenadorVO.Sexo);
            AdicionarParametro("CPF", coordenadorVO.CPF);
            AdicionarParametro("IDENTIDADE", coordenadorVO.Rg.Numero);
            AdicionarParametro("DATA_EMISSAO", coordenadorVO.Rg.DataExpedicao);
            AdicionarParametro("ORGAO_EXPEDITOR", coordenadorVO.Rg.OrgaoExpeditor);
            AdicionarParametro("ENDERECO", coordenadorVO.EnderecoAtual.Logradouro);
            AdicionarParametro("CIDADE", coordenadorVO.EnderecoAtual.Cidade.Nome);
            AdicionarParametro("UF", coordenadorVO.EnderecoAtual.Cidade.Estado.Sigla);
            AdicionarParametro("CEP", coordenadorVO.EnderecoAtual.Cep);
            AdicionarParametro("TELEFONE", coordenadorVO.Telefone);
            AdicionarParametro("CELULAR", coordenadorVO.Celular);
            AdicionarParametro("BANCO", coordenadorVO.NomeBanco);
            AdicionarParametro("EMAIL", coordenadorVO.Email);
            AdicionarParametro("AGENCIA", coordenadorVO.Agencia);
            AdicionarParametro("OBS", coordenadorVO.Observacao);

            //Criação da sql que sérá usada para incluir
            string sqlTexto = string.Concat("INSERT INTO coordenador",
                            " (COD_COORDENADOR,ENTIDADE,NOME,DATA_NASCIMENTO",
                            " ,ESTADO_CIVIL,NOME_MAE,NOME_PAI,SEXO,CPF,IDENTIDADE",
                            " ,DATA_EMISSAO,ORGAO_EXPEDITOR,ENDERECO,CIDADE,UF",
                            " ,CEP,TELEFONE,CELULAR,BANCO,EMAIL,AGENCIA,OBS)",
                            " VALUES",
                            " (@COD_COORDENADOR,@ENTIDADE,@NOME,@DATA_NASCIMENTO",
                            " ,@ESTADO_CIVIL,@NOME_MAE,@NOME_PAI,@SEXO,@CPF,@IDENTIDADE",
                            " ,@DATA_EMISSAO,@ORGAO_EXPEDITOR,@ENDERECO,@CIDADE,@UF",
                            " ,@CEP,@TELEFONE,@CELULAR,@BANCO,@EMAIL,@AGENCIA,@OBS)");
            try
            {
                /// Verifica se o INSERT foi executado corretamente
                if (ExecuteNonQuery(sqlTexto) == 0)
                {
                    throw new CoordenadorNaoIncluidoExcecao();
                }
            }
            catch (GenericException)
            {
                //Caso ocorra algum erro de FK no momento da inclusão no SQL Server.
                throw new CoordenadorJaCadastradoExcecao();
            }
        }

        public void Excluir(CoordenadorVO coordenadorVO)
        {
            AdicionarParametro("id", coordenadorVO.ID);
            string sqlTexto = string.Concat(" DELETE FROM COORDENADOR",
                                            " WHERE COD_COORDENADOR = @id");

            try
            {
                /// Verifica se o DELETE foi executado corretamente
                if (ExecuteNonQuery(sqlTexto) == 0)
                {
                    throw new CoordenadorNaoExcluidoExcecao();
                }
            }
            catch (GenericException)
            {
                //Caso ocorra algum erro de FK no momento da exclusão no SQL Server.
                throw new CoordenadorJaUtilizadoExcecao();
            }
        }

        public void Alterar(CoordenadorVO coordenadorVO)
        {

            AdicionarParametro("COD_COORDENADOR", coordenadorVO.ID);
            AdicionarParametro("ENTIDADE", coordenadorVO.Entidade);
            AdicionarParametro("NOME", coordenadorVO.Nome);
            AdicionarParametro("DATA_NASCIMENTO", coordenadorVO.DataNascimento);
            AdicionarParametro("ESTADO_CIVIL", coordenadorVO.EstadoCivil);
            AdicionarParametro("NOME_MAE", coordenadorVO.NomeMae);
            AdicionarParametro("NOME_PAI", coordenadorVO.NomePai);
            AdicionarParametro("SEXO", coordenadorVO.Sexo);
            AdicionarParametro("CPF", coordenadorVO.CPF);
            AdicionarParametro("IDENTIDADE", coordenadorVO.Rg.Numero);
            AdicionarParametro("DATA_EMISSAO", coordenadorVO.Rg.DataExpedicao);
            AdicionarParametro("ORGAO_EXPEDITOR", coordenadorVO.Rg.OrgaoExpeditor);
            AdicionarParametro("ENDERECO", coordenadorVO.EnderecoAtual.Logradouro);
            AdicionarParametro("CIDADE", coordenadorVO.EnderecoAtual.Cidade.Nome);
            AdicionarParametro("UF", coordenadorVO.EnderecoAtual.Cidade.Estado.Sigla);
            AdicionarParametro("CEP", coordenadorVO.EnderecoAtual.Cep);
            AdicionarParametro("TELEFONE", coordenadorVO.Telefone);
            AdicionarParametro("CELULAR", coordenadorVO.Celular);
            AdicionarParametro("BANCO", coordenadorVO.NomeBanco);
            AdicionarParametro("EMAIL", coordenadorVO.Email);
            AdicionarParametro("AGENCIA", coordenadorVO.Agencia);
            AdicionarParametro("OBS", coordenadorVO.Observacao);

            //Criação da sql que sérá usada para alterar
            string sqlTexto = string.Concat("UPDATE coordenador",
                           " SET COD_COORDENADOR = @COD_COORDENADOR,ENTIDADE = @ENTIDADE,NOME = @NOME",
                           " ,DATA_NASCIMENTO = @DATA_NASCIMENTO,ESTADO_CIVIL = @ESTADO_CIVIL",
                           " ,NOME_MAE = @NOME_MAE,NOME_PAI = @NOME_PAI,SEXO = @SEXO,CPF = @CPF",
                           " ,IDENTIDADE = @IDENTIDADE,DATA_EMISSAO = @DATA_EMISSAO,ORGAO_EXPEDITOR = @ORGAO_EXPEDITOR",
                           " ,ENDERECO = @ENDERECO,CIDADE = @CIDADE,UF = @UF,CEP = @CEP,TELEFONE = @TELEFONE",
                           " ,CELULAR = @CELULAR,BANCO = @BANCO,EMAIL = @EMAIL,AGENCIA = @AGENCIA,OBS = @OBS",
                           " WHERE COD_COORDENADOR = @COD_COORDENADOR");
            try
            {
                /// Verifica se o INSERT foi executado corretamente
                if (ExecuteNonQuery(sqlTexto) == 0)
                {
                    throw new CoordenadorNaoAlteradoExcecao();
                }
            }
            catch (GenericException)
            {
                //Caso ocorra algum erro de FK no momento da alteração no SQL Server.
                throw new CoordenadorJaCadastradoExcecao();
            }
        }

        public List<CoordenadorVO> Consultar(CoordenadorVO coordenadorVO, CoordenadorFiltroConsulta coordenadorFiltroConsulta, bool lazy)
        {
            string sqlTexto = "";
            if (coordenadorVO.ID != 0)
            {
                AdicionarParametro("COD_COORDENADOR", coordenadorVO.ID);
                sqlTexto = string.Concat("SELECT " + coordenadorFiltroConsulta.GetCampos() + " FROM COORDENADOR ",
                                        "WHERE id_estrutura_produto_estprd = @COD_COORDENADOR ");
                return this.Consultar(sqlTexto, coordenadorFiltroConsulta, lazy);

            }
            else if (!string.IsNullOrEmpty(coordenadorVO.Nome))
            {
                AdicionarParametro("NOME", "%" + coordenadorVO.Nome + "%");
                sqlTexto = string.Concat(" SELECT " + coordenadorFiltroConsulta.GetCampos() + " FROM COORDENADOR",
                                         " WHERE NOME LIKE @NOME ");
            }

            return this.Consultar(sqlTexto, coordenadorFiltroConsulta, lazy);
        }

        public List<CoordenadorVO> Consultar(CoordenadorFiltroConsulta coordenadorFiltroConsulta, bool lazy)
        {
            //Pega a data de atual do servidor do IIS.
            System.DateTime today = System.DateTime.Now;

            AdicionarParametro("systemDate", today);
            string sqlTexto = "SELECT " + coordenadorFiltroConsulta.GetCampos() + " FROM COORDENADOR ";

            return this.Consultar(sqlTexto, coordenadorFiltroConsulta, lazy);
        }

        #endregion

        #region Funcoes Utilitárias

        /// <summary>
        /// Consulta que recebe uma SQL em texto, à executa e preenche uma lista to tipo variavel 
        /// </summary>
        /// <param name="sqlTexto"> O Sql texto como parametro de consulta</param>
        /// <param name="marcaFiltroProduto"> O filtro da consulta</param>
        /// <returns></returns>
        private List<CoordenadorVO> Consultar(string sqlTexto, FiltroConsulta filtro, bool lazy)
        {
            List<CoordenadorVO> coordenadorList = new List<CoordenadorVO>();

            SqlDataReader sqlDataReader = ExecuteReader(sqlTexto);

            // Verifica se foram retornados dados da consulta
            if (sqlDataReader != null && sqlDataReader.HasRows)
            {
                // Loop para carregar a lista de retorno do metodo
                while (sqlDataReader.Read())
                {
                    CoordenadorVO coordenador = new CoordenadorVO();
                    //As verificações abaixo checam quais dados devem ser retornados na consulta,
                    //baseado nos campos do filtro passado como parâmetro. Depois checa se o valor do banco
                    //é diferente de nulo para não ocorrer problemas na hora da converção.
                    //----------------------------------------------------------------------------------

                    if (filtro["COD_COORDENADOR"])
                    {
                        if (sqlDataReader["COD_COORDENADOR"] != DBNull.Value)
                            coordenador.ID = Convert.ToInt32(sqlDataReader["COD_COORDENADOR"]);
                    }

                    if (filtro["CELULAR"])
                    {
                        if (sqlDataReader["CELULAR"] != DBNull.Value)
                            coordenador.Celular = Convert.ToString(sqlDataReader["CELULAR"]);
                    }
                    if (filtro["CPF"])
                    {
                        if (sqlDataReader["CPF"] != DBNull.Value)
                            coordenador.CPF = Convert.ToString(sqlDataReader["CPF"]);
                    }
                    if (filtro["DATA_NASCIMENTO"])
                    {
                        if (sqlDataReader["DATA_NASCIMENTO"] != DBNull.Value)
                            coordenador.DataNascimento = Convert.ToDateTime(sqlDataReader["DATA_NASCIMENTO"]);
                    }
                    if (filtro["EMAIL"])
                    {
                        if (sqlDataReader["EMAIL"] != DBNull.Value)
                            coordenador.Email = Convert.ToString(sqlDataReader["EMAIL"]);
                    }

                    if (filtro["ENDERECO"])
                    {
                        if (sqlDataReader["ENDERECO"] != DBNull.Value)
                            coordenador.EnderecoAtual.Logradouro = Convert.ToString(sqlDataReader["ENDERECO"]);
                    }

                    if (filtro["CEP"])
                    {
                        if (sqlDataReader["CEP"] != DBNull.Value)
                            coordenador.EnderecoAtual.Cep = Convert.ToString(sqlDataReader["CEP"]);
                    }

                    if (filtro["CIDADE"])
                    {
                        if (sqlDataReader["CIDADE"] != DBNull.Value)
                            coordenador.EnderecoAtual.Cidade.Nome = Convert.ToString(sqlDataReader["CIDADE"]);
                    }

                    if (filtro["UF"])
                    {
                        if (sqlDataReader["UF"] != DBNull.Value)
                            coordenador.EnderecoAtual.Cidade.Estado.Sigla = Convert.ToString(sqlDataReader["UF"]);
                    }

                    if (filtro["ESTADO_CIVIL"])
                    {
                        if (sqlDataReader["ESTADO_CIVIL"] != DBNull.Value)
                            coordenador.EstadoCivil = Convert.ToString(sqlDataReader["ESTADO_CIVIL"]);
                    }

                    if (filtro["ENTIDADE"])
                    {
                        if (sqlDataReader["ENTIDADE"] != DBNull.Value)
                            coordenador.Entidade = Convert.ToString(sqlDataReader["ENTIDADE"]);
                    }

                    if (filtro["NOME"])
                    {
                        if (sqlDataReader["NOME"] != DBNull.Value)
                            coordenador.Nome = Convert.ToString(sqlDataReader["NOME"]);
                    }

                    if (filtro["NOME_MAE"])
                    {
                        if (sqlDataReader["NOME_MAE"] != DBNull.Value)
                            coordenador.NomeMae = Convert.ToString(sqlDataReader["NOME_MAE"]);
                    }

                    if (filtro["NOME_PAI"])
                    {
                        if (sqlDataReader["NOME_PAI"] != DBNull.Value)
                            coordenador.NomePai = Convert.ToString(sqlDataReader["NOME_PAI"]);
                    }

                    if (filtro["SEXO"])
                    {
                        if (sqlDataReader["SEXO"] != DBNull.Value)
                            coordenador.Sexo = Convert.ToChar(sqlDataReader["SEXO"]);
                    }

                    if (filtro["IDENTIDADE"])
                    {
                        if (sqlDataReader["IDENTIDADE"] != DBNull.Value)
                            coordenador.Rg.Numero = Convert.ToString(sqlDataReader["IDENTIDADE"]);
                    }

                    if (filtro["DATA_EMISSAO"])
                    {
                        if (sqlDataReader["DATA_EMISSAO"] != DBNull.Value)
                            coordenador.Rg.DataExpedicao = Convert.ToDateTime(sqlDataReader["DATA_EMISSAO"]);
                    }

                    if (filtro["ORGAO_EXPEDITOR"])
                    {
                        if (sqlDataReader["ORGAO_EXPEDITOR"] != DBNull.Value)
                            coordenador.Rg.OrgaoExpeditor = Convert.ToString(sqlDataReader["ORGAO_EXPEDITOR"]);
                    }

                    if (filtro["TELEFONE"])
                    {
                        if (sqlDataReader["TELEFONE"] != DBNull.Value)
                            coordenador.Telefone = Convert.ToString(sqlDataReader["TELEFONE"]);
                    }

                    if (filtro["BANCO"])
                    {
                        if (sqlDataReader["BANCO"] != DBNull.Value)
                            coordenador.NomeBanco = Convert.ToString(sqlDataReader["BANCO"]);
                    }

                    if (filtro["AGENCIA"])
                    {
                        if (sqlDataReader["AGENCIA"] != DBNull.Value)
                            coordenador.Agencia = Convert.ToString(sqlDataReader["AGENCIA"]);
                    }

                    if (filtro["OBS"])
                    {
                        if (sqlDataReader["OBS"] != DBNull.Value)
                            coordenador.Observacao = Convert.ToString(sqlDataReader["OBS"]);
                    }

                    coordenadorList.Add(coordenador);
                }

            }
            if (sqlDataReader != null && !sqlDataReader.IsClosed)
                sqlDataReader.Close();
            return coordenadorList;
        }

        /// <summary>
        /// Método responsavel por retornar o proximo codigo a ser inserido.
        /// </summary>
        /// <returns>Proximo codigo.</returns>
        private int ObterProximoCodigo()
        {
            int id = 0;

            string sqlTexto = "SELECT MAX(COD_COORDENADOR) CODIGO FROM COORDENADOR";
            SqlDataReader sqlDataReader = ExecuteReader(sqlTexto);
            if (sqlDataReader != null && sqlDataReader.HasRows)
            {
                // Loop para carregar a lista de retorno do metodo
                while (sqlDataReader.Read())
                {

                    if (sqlDataReader["CODIGO"] != DBNull.Value)
                        id = Convert.ToInt32(sqlDataReader["CODIGO"]);
                }

            }

            id += 1;

            return id;

        }

        #endregion
    }
}
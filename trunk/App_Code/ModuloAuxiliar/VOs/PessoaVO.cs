using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ppf.ModuloAuxuliar.VOs
{
    /// <summary>
    /// Summary description for PessoaVO
    /// </summary>
    public class PessoaVO : RegistroModificacao
    {
        #region Atributos
        private int id;
        private string nome;
        private string cpf;
        private DateTime dataNascimento;
        private char sexo;
        private string email;
        private string entidade;
        private string estadoCivil;
        private string nomeMae;
        private string nomePai;
        private Endereco enderecoAtual;
        private Rg rg;
        private string observacao;
        private string nomeBanco;
        private string agencia;
        private string numeroConta;
        private string telefone;
        private string celular;
        #endregion

        #region Propriedades

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Agencia
        {
            get { return agencia; }
            set { agencia = value; }
        }
        public string NumeroConta
        {
            get { return numeroConta; }
            set { numeroConta = value; }
        }

        public string NomeBanco
        {
            get { return nomeBanco; }
            set { nomeBanco = value; }
        }
        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }

        public Rg Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        public Endereco EnderecoAtual
        {
            get { return enderecoAtual; }
            set { enderecoAtual = value; }
        }

        public string NomeMae
        {
            get { return nomeMae; }
            set { nomeMae = value; }
        }


        public string NomePai
        {
            get { return nomePai; }
            set { nomePai = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string Entidade
        {
            get { return entidade; }
            set { entidade = value; }
        }



        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public char Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }



        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}
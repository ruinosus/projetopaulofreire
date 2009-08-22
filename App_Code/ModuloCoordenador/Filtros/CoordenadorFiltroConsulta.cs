using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ppf.ModuloAuxiliar.BaseFiltro;

namespace Ppf.ModuloCoordenador.Filtros
{
    /// <summary>
    /// Summary description for CoordenadorFiltroConsulta
    /// </summary>
    public class CoordenadorFiltroConsulta : FiltroConsulta
    {
        public bool ID
        {
            set
            {
                ExecutarOperacao(value, "COD_COORDENADOR");
            }
        }
        public bool Nome
        {
            set
            {
                ExecutarOperacao(value, "NOME");
            }
        }
        public bool Cpf
        {
            set
            {
                ExecutarOperacao(value, "CPF");
            }
        }

        public bool DataNascimento
        {
            set
            {
                ExecutarOperacao(value, "DATA_NASCIMENTO");
            }
        }

        public bool Sexo
        {
            set
            {
                ExecutarOperacao(value, "SEXO");
            }
        }

        public bool Email
        {
            set
            {
                ExecutarOperacao(value, "EMAIL");
            }
        }

        public bool Rg
        {
            set
            {
                ExecutarOperacao(value, "IDENTIDADE");
                ExecutarOperacao(value, "DATA_EMISSAO");
                ExecutarOperacao(value, "ORGAO_EXPEDITOR");
            }
        }

        public bool Entidade
        {
            set
            {
                ExecutarOperacao(value, "ENTIDADE");
            }
        }

        public bool EstadoCivil
        {
            set
            {
                ExecutarOperacao(value, "ESTADO_CIVIL");
            }
        }

        public bool NomeMae
        {
            set
            {
                ExecutarOperacao(value, "NOME_MAE");
            }
        }

        public bool NomePai
        {
            set
            {
                ExecutarOperacao(value, "NOME_PAI");
            }
        }

        public bool Endereco
        {
            set
            {
                ExecutarOperacao(value, "ENDERECO");
                ExecutarOperacao(value, "CIDADE");
                ExecutarOperacao(value, "UF");
                ExecutarOperacao(value, "CEP");
            }
        }

        public bool Telefone
        {
            set
            {
                ExecutarOperacao(value, "TELEFONE");
            }
        }

        public bool Celular
        {
            set
            {
                ExecutarOperacao(value, "CELULAR");
            }
        }

        public bool Observacao
        {
            set
            {
                ExecutarOperacao(value, "OBS");
            }
        }

        public bool NomeBanco
        {
            set
            {
                ExecutarOperacao(value, "BANCO");
            }
        }

        public bool Agencia
        {
            set
            {
                ExecutarOperacao(value, "AGENCIA");
            }
        }


        public void HabilitaTudo()
        {
            this.Agencia = true;
            this.Celular = true;
            this.Cpf = true;
            this.DataNascimento = true;
            this.Email = true;
            this.Endereco = true;
            this.Entidade = true;
            this.EstadoCivil = true;
            this.ID = true;
            this.Nome = true;
            this.NomeBanco = true;
            this.NomeMae = true;
            this.NomePai = true;
            this.Observacao = true;
            this.Rg = true;
            this.Sexo = true;
            this.Telefone = true;
        }

    }
}
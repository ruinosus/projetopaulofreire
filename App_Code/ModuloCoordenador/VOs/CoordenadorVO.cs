using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ppf.ModuloAuxuliar.VOs;

/// <summary>
/// Coordenador de uma turma de professores.
/// </summary>
public class CoordenadorVO : PessoaVO
{
	public CoordenadorVO()
	{
        this.EnderecoAtual = new Endereco();
        this.Rg = new Rg();
	}
}

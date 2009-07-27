using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Classe de constantes contantendo as mensagens de erro do sistema.
/// </summary>
namespace Ppf.ModuloAuxiliar.Excecoes
{
    public class GenericExceptionMessages
    {
   
        //MENSAGENS GERAIS
        public static readonly String REGISTRO_NAO_LOCALIZADO = "N�o foi poss�vel localizar o registro solicitado.";
        public static readonly String ERRO_FK_EXCLUSAO = "N�o � poss�vel excluir o registro, pois j� foi referenciado por outro processo. A opera��o de exclus�o foi cancelada";
        public static readonly String ERRO_FK_INCLUSAO = "N�o � poss�vel inserir o registro, pois este j� est� cadastrado. A opera��o inser��o foi cancelada.";
        public static readonly String ERRO_GENERICO = "Ocorreu um erro inesperado durante a execu��o do sistema. Entre em contato com o administrador.";
   
    }
}
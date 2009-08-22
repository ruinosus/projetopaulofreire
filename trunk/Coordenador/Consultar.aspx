<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Consultar.aspx.cs" Inherits="Coordenador_Consultar" %>

<%@ Register Src="CoordenadorSelecionar.ascx" TagName="CoordenadorSelecionar" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="conteudo" width="100%">
        <tr>
            <td>
                <ajax:UpdatePanel ID="updPanelProdutoConsultar" runat="server">
                    <ContentTemplate>
                        <uc1:CoordenadorSelecionar ID="CoordenadorSelecionar1" runat="server" />
                        </td>
                    </ContentTemplate>
                </ajax:UpdatePanel>
        </tr>
        <tr>
            <td style="height: 7px">
            </td>
        </tr>
    </table>
</asp:Content>

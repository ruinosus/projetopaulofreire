<%@ Page Title="Coordenador - Consultar" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Consultar.aspx.cs" Inherits="Coordenador_Consultar" %>

<%@ Register Src="CoordenadorSelecionar.ascx" TagName="CoordenadorSelecionar" TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<table width="100%">
        <tr align="center">
            <td align="center">
                <ajax:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="300" AssociatedUpdatePanelID="updPanelProdutoConsultar">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/loading.gif" />
                    </ProgressTemplate>
                </ajax:UpdateProgress>
            </td>
        </tr>
    </table>
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
    <ajax:UpdatePanel ID="updBotoes" runat="server" UpdateMode="Conditional"  >
                    <ContentTemplate>
    <table width="100%">
        <tr align="center">
            <td align="center" valign="top">
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" CausesValidation="False"
                    TabIndex="3" onclick="btnIncluir_Click" />
                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" CausesValidation="False"
                    TabIndex="4" />
                <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CausesValidation="False"
                    TabIndex="5" />
                <asp:Button ID="btnRetornar" runat="server" Text="Retornar" CausesValidation="false" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </ajax:UpdatePanel>
</asp:Content>

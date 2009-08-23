<%@ Page Title="Coordenador - Incluir" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Incluir.aspx.cs" Inherits="Coordenador_Incluir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../js/validationScripts.js"></script>

<div id="AvisoDeErro1" style="text-align: center;">
    <asp:ValidationSummary ID="vsuAvisoDeErro" runat="server" ValidationGroup="AvisoDeErro">
    </asp:ValidationSummary>
    <asp:ValidationSummary ID="vsuAvisoDeInformacao" runat="server" ValidationGroup="AvisoDeInformacao"
        ForeColor="#14A351"></asp:ValidationSummary>
    <asp:CustomValidator ID="cvaAvisoDeErro" runat="server" ValidationGroup="AvisoDeErro"
        Visible="false"></asp:CustomValidator>
    <asp:CustomValidator ID="cvaAvisoDeInformacao" runat="server" ValidationGroup="AvisoDeInformacao"
        ForeColor="#14A351" Visible="False"></asp:CustomValidator>
</div>
</asp:Content>


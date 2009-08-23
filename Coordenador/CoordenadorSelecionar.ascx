<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CoordenadorSelecionar.ascx.cs"
    Inherits="Coordenador_CoordenadorSelecionar" %>

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
<table width="100%">
    <tr align="center">
        <td align="center">
            <asp:Label ID="lblNome" runat="server" Text="Nome:" Font-Names="Arial"></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" Width="300px" ValidationGroup="AvisoDeErro"
                MaxLength="100"></asp:TextBox>
            <asp:Button ID="btnPesquisar" runat="server" Style="position: relative" Text="Pesquisar"
                TabIndex="2" OnClick="btnPesquisar_OnClick" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:GridView ID="GrdCoordenador" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
                CellPadding="3" GridLines="Vertical" OnPageIndexChanging="grdCoordenador_PageIndexChanging"
                OnRowCreated="grdCoordenador_RowCreated" OnPreRender="grdCoordenador_PreRender">
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="&amp;nbsp;">
                        <ItemTemplate>
                            <asp:RadioButton ID="idCoordenador" runat="server" value='<%# Eval("ID") %>' onclick='<%# GetOnSelectEvent(Eval("ID"))%>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label ID="lblNome" AssociatedControlID="idCoordenador" runat="server" Text='<%# Eval("Nome") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40%" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data de Nascimento">
                        <ItemTemplate>
                            <asp:Label ID="lblDataNascimento" AssociatedControlID="idCoordenador" runat="server"
                                Text='<%# GetDataNascimento(Eval("DataNascimento")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Endereço">
                        <ItemTemplate>
                            <asp:Label ID="lblEndereco" AssociatedControlID="idCoordenador" runat="server" Text='<%# Eval("EnderecoAtual.Logradouro") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
        </td>
    </tr>
</table>

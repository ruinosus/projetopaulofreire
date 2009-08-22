<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enableviewstate="true">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <br />
    <asp:LoginName ID="LoginName1" runat="server" />
    <div>
        <table id="Table2" width="100%" style="border: 1px solid;">
            <tr>
                <td style="border-right: 1px solid; border-top: 1px solid; border-left: 1px solid;
                    border-bottom: 1px solid; background-color: #F1F4FD" align="center">
                    <asp:Label ID="Label5" runat="server" Text="Outras informações cadastrais" Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td align="justify">
                    <ajax:UpdatePanel runat="server" ID="updProdutoMarca">
                        <ContentTemplate>
                            <asp:Table enableviewstate="false" ID="tblProdutoMarca" Width="100%" runat="server" OnDisposed="tblProdutoMarca_Disposed"
                                OnPreRender="tblProdutoMarca_PreRender">
                                <asp:TableRow ID="linha1" runat="server">
                                    <asp:TableCell ID="subMarca1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblSubMarca" runat="server" Text="Sub-marca:">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="subMarca2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:DropDownList ID="dplSubMarca" runat="server" DataTextField="Descricao" DataValueField="ID"
                                            Width="200px">
                                        </asp:DropDownList>
                                    </asp:TableCell>
                                    <asp:TableCell ID="classe1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblClasse" runat="server" Text="Classe:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="classe2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:DropDownList ID="dplClasse" runat="server" DataTextField="Descricao" DataValueField="ID"
                                            Width="200px" Visible="true">
                                        </asp:DropDownList>
                                    </asp:TableCell>
                                    <asp:TableCell ID="apresentacao1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblApresentacao" runat="server" Text="Apresentação:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="apresentacao2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:DropDownList ID="dplApresentacao" runat="server" DataTextField="Descricao" DataValueField="ID"
                                            Width="200px" Visible="true">
                                        </asp:DropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow ID="linha2" runat="server">
                                    <asp:TableCell ID="modelo1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblModelo" runat="server" Text="Modelo:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="modelo2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtModelo" runat="server" CssClass="txt200" Visible="true" MaxLength="30">
                                        </asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell ID="tamanho1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblTamanho" runat="server" Text="Tamanho:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="tamanho2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtTamanho" runat="server" CssClass="txt200" Visible="true" MaxLength="30"></asp:TextBox>&nbsp;
                                        <cc1:MaskedEditExtender ID="mskTamanho" runat="server" TargetControlID="txtTamanho"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="gramatura1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblNumeroDaGramatura" runat="server" Text="Gramatura:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="gramatura2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtNumeroDaGramatura" runat="server" CssClass="txt200" Visible="true"
                                            MaxLength="6"></asp:TextBox>&nbsp;<asp:Label ID="lblGramas" runat="server" Text="gramas"
                                                Visible="False"></asp:Label>
                                        <cc1:MaskedEditExtender ID="mskNumeroGramatura" runat="server" TargetControlID="txtNumeroDaGramatura"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow ID="linha3" runat="server">
                                    <asp:TableCell ID="quantidadeFios1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblQuantidadedeFios" runat="server" Text="Quantidade de fios do produto:"
                                            Visible="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="quantidadeFios2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtQuantidadedeFios" runat="server" CssClass="txt200" Visible="true"
                                            MaxLength="5"></asp:TextBox>&nbsp;
                                        <cc1:MaskedEditExtender ID="mskQuantidadeFios" runat="server" TargetControlID="txtQuantidadedeFios"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="fibra1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblPercentualFibras" runat="server" Text="Fibras do produto:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="fibra2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtPercentualFibras" runat="server" CssClass="txt200" Visible="true"
                                            MaxLength="6"></asp:TextBox>&nbsp;<asp:Label ID="lblPercentual" runat="server" Text="%"
                                                Visible="true"></asp:Label>
                                        <cc1:MaskedEditExtender ID="mskPercentualFibras" runat="server" TargetControlID="txtPercentualFibras"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="voltagem1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblVoltagem" runat="server" Text="Voltagem:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="voltagem2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtVoltagem" runat="server" CssClass="txt200" Visible="true" MaxLength="20"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow ID="linha4" runat="server">
                                    <asp:TableCell ID="pesoBruto1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblQuantidadeDePesoBruto" runat="server" Text="Peso Bruto:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="pesoBruto2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtQuantidadeDePesoBruto" runat="server" CssClass="txt200" Visible="true"
                                            MaxLength="6"></asp:TextBox>
                                        <asp:Label ID="lblkgBruto" runat="server" Text="Kg" Visible="true"></asp:Label>
                                        <cc1:MaskedEditExtender ID="mskQuantidadePesoBruto" runat="server" TargetControlID="txtQuantidadeDePesoBruto"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="pesoLiquido1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblQuantidadeDePesoLiquido" runat="server" Text="Peso Liquido:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="pesoLiquido2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtQuantidadeDePesoLiquido" runat="server" CssClass="txt200" Visible="true"
                                            MaxLength="6"></asp:TextBox>
                                        <asp:Label ID="lblKgLiquido" runat="server" Text="Kg" Visible="true"></asp:Label>
                                        <cc1:MaskedEditExtender ID="mskQuantidadePesoLiquido" runat="server" TargetControlID="txtQuantidadeDePesoLiquido"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="embalagem1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblEmbalagem" runat="server" Text="Tipo da embalagem:" Visible="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="embalagem2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:DropDownList ID="dplEmbalagem" runat="server" DataTextField="Descricao" DataValueField="ID"
                                            Width="200px" Visible="true">
                                        </asp:DropDownList>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow ID="linha5" runat="server">
                                    <asp:TableCell ID="quantidadeEmbalagem1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblQuantidadeEmbalagem" runat="server" Text="Quantidade por embalagem:"
                                            Visible="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="quantidadeEmbalagem2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtQuantidadeEmbalagem" runat="server" CssClass="txt200" Visible="true"
                                            MaxLength="6"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="mskQuantidadeEmbalagem" runat="server" TargetControlID="txtQuantidadeEmbalagem"
                                            MaskType="none" Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ipi1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblIpi" runat="server" Text="Aliquota do IPI:" Visible="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ipi2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtIpi" runat="server" CssClass="txt200" Visible="true" MaxLength="6"></asp:TextBox>&nbsp;<asp:Label
                                            ID="lblIpiPercentual" runat="server" Text="%" Visible="true"></asp:Label>
                                        <cc1:MaskedEditExtender ID="mskIpi" runat="server" TargetControlID="txtIpi" MaskType="none"
                                            Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                    <asp:TableCell ID="icms1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblIcms" runat="server" Text="Aliquota do ICMS:" Visible="true">
                                        </asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="icms2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtIcms" runat="server" CssClass="txt200" Visible="true" MaxLength="6"></asp:TextBox>&nbsp;<asp:Label
                                            ID="lblIcmsPercentual" runat="server" Text="%" Visible="true"></asp:Label>
                                        <cc1:MaskedEditExtender ID="mskIcms" runat="server" TargetControlID="txtIcms" MaskType="none"
                                            Mask="999999999" ClearMaskOnLostFocus="true">
                                        </cc1:MaskedEditExtender>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow ID="linha6" runat="server">
                                    <asp:TableCell ID="ncm1Coluna" HorizontalAlign="right" Visible="true">
                                        <asp:Label ID="lblNcm" runat="server" Text="NCM do Produto:" Visible="true"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell ID="ncm2Coluna" HorizontalAlign="Left" Visible="true">
                                        <asp:TextBox ID="txtNcm" runat="server" CssClass="txt200" Visible="true" MaxLength="10"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell1" HorizontalAlign="right" Visible="true">
                                  
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell2" HorizontalAlign="Left" Visible="true">
                                                                    
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell3" HorizontalAlign="right" Visible="true">
                                
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell4" HorizontalAlign="Left" Visible="true">
                                                             
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ContentTemplate>
                    </ajax:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnTeste" runat="server" OnClick="btnTeste_OnClick" Text="ok" />
        <asp:Button ID="btnTeste2" runat="server" OnClick="btnTeste2_OnClick" Text="ok2" />
        <asp:RadioButton ID="RadioButton1" runat="server" />
        <asp:RadioButton ID="RadioButton2" runat="server" />
    </div>
    
    </form>
</body>
</html>
<%--<asp:TableCell ID="1" runat="server">
                    <asp:Label ID="lbl" runat="server" Text=":"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="2" runat="server">
                    <asp:TextBox ID="txt" runat="server" Text=""></asp:TextBox>
                </asp:TableCell>--%>
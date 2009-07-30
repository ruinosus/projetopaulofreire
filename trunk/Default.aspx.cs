using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private bool subMarca = false;
    private bool classe = false;
    private bool apresentacao = false;
    private bool modelo = false;
    private bool tamanho = false;
    private bool gramatura = false;
    private bool quantidadeFios = false;
    private bool fibra = false;
    private bool voltagem = false;
    private bool pesoBruto = false;
    private bool pesoLiquido = false;
    private bool embalagem = false;
    private bool quantidadeEmbalagem = false;
    private bool ipi = false;
    private bool icms = false;
    private bool ncm = false;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnTeste_OnClick(object sender, EventArgs e)
    {


        subMarca = true;
        classe = false;
        apresentacao = true;
        modelo = false;
        tamanho = false;
        gramatura = false;
        quantidadeFios = false;
        fibra = true;
        voltagem = true;
        pesoBruto = false;
        pesoLiquido = true;
        embalagem = false;
        quantidadeEmbalagem = false;
        ipi = true;
        icms = false;
        ncm = true;

        HabilitarComponentes();
        MontarTabela();
    }

    private List<int> AcharPosicaoVazia()
    {
        List<int> posicao = new List<int>();

        for (int i = 0; i < tblProdutoMarca.Rows.Count; i++)
        {
            for (int j = 0; j < tblProdutoMarca.Rows[i].Cells.Count; j++)
            {
                if (!tblProdutoMarca.Rows[i].Cells[j].Visible)
                {
                    posicao.Add(i);
                    posicao.Add(j);
                    return posicao;
                }
            }
        }

        return posicao;
    }

    private int CalcularColunaVazia(int indiceLinha)
    {
        int resultado = 0;

        for (int i = 0; i < tblProdutoMarca.Rows[indiceLinha].Cells.Count; i++)
        {
            if (!tblProdutoMarca.Rows[indiceLinha].Cells[i].Visible)
                resultado++;
        }

        return resultado;
    }

    private List<int> AcharProximoElemento(int indiceLinha, int indiceColuna)
    {
        List<int> posicao = new List<int>();

        for (int i = indiceLinha; i < tblProdutoMarca.Rows.Count; i++)
        {
            if (!(CalcularColunaVazia(i) == 0))
            {
                if (i > indiceLinha)
                    indiceColuna = 0;
                for (int j = indiceColuna; j < tblProdutoMarca.Rows[i].Cells.Count; j++)
                {
                    if (tblProdutoMarca.Rows[i].Cells[j].Visible)
                    {
                        posicao.Add(i);
                        posicao.Add(j);
                        return posicao;
                    }
                }
            }
        }

        return posicao;

    }

    private void MontarTabela()
    {
        List<int> posicaoVazia = this.AcharPosicaoVazia();

        if (posicaoVazia.Count > 0)
        {
            List<int> proximoElemento = this.AcharProximoElemento(posicaoVazia[0], posicaoVazia[1]);

            if (proximoElemento.Count > 0)
            {
                tblProdutoMarca.Rows[posicaoVazia[0]].
                    Cells[posicaoVazia[1]].Controls.Clear();

                tblProdutoMarca.Rows[posicaoVazia[0]].
                    Cells[posicaoVazia[1] + 1].Controls.Clear();

                for (int i = 0; i < tblProdutoMarca.
                        Rows[proximoElemento[0]].
                            Cells[proximoElemento[1]].Controls.Count; i++)
                    tblProdutoMarca.Rows[posicaoVazia[0]].
                        Cells[posicaoVazia[1]].Controls.Add(tblProdutoMarca.
                            Rows[proximoElemento[0]].
                                Cells[proximoElemento[1]].Controls[i]);

                for (int i = 0; i < tblProdutoMarca.
                        Rows[proximoElemento[0]].
                            Cells[proximoElemento[1] + 1].Controls.Count; i++)
                    tblProdutoMarca.Rows[posicaoVazia[0]].
                        Cells[posicaoVazia[1] + 1].Controls.Add(tblProdutoMarca.
                            Rows[proximoElemento[0]].
                                Cells[proximoElemento[1] + 1].Controls[i]);

                tblProdutoMarca.
                        Rows[proximoElemento[0]].
                            Cells[proximoElemento[1] + 1].Controls.Clear();
                tblProdutoMarca.
                        Rows[proximoElemento[0]].
                            Cells[proximoElemento[1]].Controls.Clear();

                tblProdutoMarca.
                        Rows[proximoElemento[0]].
                            Cells[proximoElemento[1] + 1].Visible = false;
                tblProdutoMarca.
                        Rows[proximoElemento[0]].
                            Cells[proximoElemento[1]].Visible = false;

                if (CalcularColunaVazia(proximoElemento[0]) == 6)
                    tblProdutoMarca.
                        Rows[proximoElemento[0]].Visible = false;

                tblProdutoMarca.Rows[posicaoVazia[0]].Visible = true;
                tblProdutoMarca.Rows[posicaoVazia[0]].
                   Cells[posicaoVazia[1]].Visible = true;

                tblProdutoMarca.Rows[posicaoVazia[0]].
                    Cells[posicaoVazia[1] + 1].Visible = true;

                posicaoVazia.Clear();
                posicaoVazia = this.AcharPosicaoVazia();

                if (posicaoVazia.Count > 0 && proximoElemento.Count > 0)
                    MontarTabela();
                else
                    return;


            }
        }

    }

    private void HabilitarComponentes()
    {
        //linha1.Visible = subMarca || classe || apresentacao;
        //linha2.Visible = modelo || tamanho || gramatura;
        //linha3.Visible = quantidadeFios || fibra || voltagem;
        //linha4.Visible = pesoBruto || pesoLiquido || embalagem;
        //linha5.Visible = quantidadeEmbalagem || ipi || icms;
        //linha6.Visible = ncm;

        linha1.Visible = true;
        linha2.Visible = true;
        linha3.Visible = true;
        linha4.Visible = true;
        linha5.Visible = true;
        linha6.Visible = true;

        subMarca1Coluna.Visible = subMarca;
        subMarca2Coluna.Visible = subMarca;

        classe1Coluna.Visible = classe;
        classe2Coluna.Visible = classe;

        apresentacao1Coluna.Visible = apresentacao;
        apresentacao2Coluna.Visible = apresentacao;

        modelo1Coluna.Visible = modelo;
        modelo2Coluna.Visible = modelo;

        tamanho1Coluna.Visible = tamanho;
        tamanho2Coluna.Visible = tamanho;

        gramatura1Coluna.Visible = gramatura;
        gramatura2Coluna.Visible = gramatura;

        quantidadeFios1Coluna.Visible = quantidadeFios;
        quantidadeFios2Coluna.Visible = quantidadeFios;

        fibra1Coluna.Visible = fibra;
        fibra2Coluna.Visible = fibra;

        voltagem1Coluna.Visible = voltagem;
        voltagem2Coluna.Visible = voltagem;

        pesoBruto1Coluna.Visible = pesoBruto;
        pesoBruto2Coluna.Visible = pesoBruto;

        pesoLiquido1Coluna.Visible = pesoLiquido;
        pesoLiquido2Coluna.Visible = pesoLiquido;

        embalagem1Coluna.Visible = embalagem;
        embalagem2Coluna.Visible = embalagem;

        quantidadeEmbalagem1Coluna.Visible = quantidadeEmbalagem;
        quantidadeEmbalagem2Coluna.Visible = quantidadeEmbalagem;

        ipi1Coluna.Visible = ipi;
        ipi2Coluna.Visible = ipi;

        icms1Coluna.Visible = icms;
        icms2Coluna.Visible = icms;

        ncm1Coluna.Visible = ncm;
        ncm2Coluna.Visible = ncm;


    }



}

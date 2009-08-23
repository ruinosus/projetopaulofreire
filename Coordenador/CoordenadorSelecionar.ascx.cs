using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ppf.ModuloCoordenador.Filtros;
using Ppf.ModuloCoordenador.Processos;
using Ppf.ModuloCoordenador.Excecoes;

public partial class Coordenador_CoordenadorSelecionar : System.Web.UI.UserControl, System.Web.UI.IPostBackEventHandler
{

    #region Atributos

    private int idCoordenador;
    private List<CoordenadorVO> coordenadorLista;
    private bool check = false;


    #endregion

    #region Propriedades
    public int IdCoordenador
    {
        get
        {
            if (Session["idCoordenador"] != null)
                idCoordenador = Convert.ToInt32(Session["idCoordenador"]);

            return idCoordenador;
        }
        set
        {
            Session.Add("idCoordenador", value);
        }
    }

    public List<CoordenadorVO> CoordenadorLista
    {
        get
        {
            if (Session["CoordenadorLista"] != null)
                coordenadorLista = (List<CoordenadorVO>)Session["CoordenadorLista"];

            return coordenadorLista;
        }
        set
        {
            Session.Add("CoordenadorLista", value);
        }
    }
    #endregion

    #region Eventos

    public event EventHandler OnSelect;

    #endregion

    #region IPostBackEventHandler Members

    void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
    {
        IdCoordenador = Convert.ToInt32(eventArgument);

        // Verifica se existe algum Evento relacionado
        if (OnSelect != null)
        {

            OnSelect.Invoke(this, new EventArgs());
        }
    }

    #endregion

    #region Métodos Privados

    /// <summary>
    /// Método para exibir o gridView com valores em branco.
    /// </summary>
    private void PreencherGridVazio()
    {
        CoordenadorLista = new List<CoordenadorVO>();

        CoordenadorVO coordenadorInicial = new CoordenadorVO();

        CoordenadorLista.Add(coordenadorInicial);

        GrdCoordenador.DataSource = CoordenadorLista;
        GrdCoordenador.DataBind();

        foreach (TableCell cell in GrdCoordenador.Rows[0].Cells)
        {
            cell.Text = "&nbsp;";
        }
    }

    /// <summary>
    /// Retorna o JavaScript necessário para invocar o evento OnSelect
    /// </summary>
    /// <param name="idProduto">O ID do ProdutoVO que será passado como parâmetro para o evento</param>
    /// <returns>O JavaScript</returns>
    protected string GetOnSelectEvent(object idCoordenador)
    {
        if (OnSelect != null && idCoordenador != null)
        {
            PostBackOptions options = new PostBackOptions(this);

            options.Argument = idCoordenador.ToString();

            string postBackReference = Page.ClientScript.GetPostBackEventReference(options);

            return "checkOnlyOne(this,'idCoordenador');" + postBackReference + ";";
        }

        return "checkOnlyOne(this,'idCoordenador');";
    }

    private void ClearSession()
    {
        Session.Remove("idCoordenador");
        Session.Remove("CoordenadorLista");
    }

    protected string GetDataNascimento(object dataNascimento)
    {
        string resultado = "-";

        if (dataNascimento != null && !string.IsNullOrEmpty(dataNascimento.ToString()))
        {
            string dataEditada = (string)dataNascimento;
            resultado = string.Concat(dataEditada.Substring(0, 2), "/", dataEditada.Substring(2, 2), "/", dataEditada.Substring(4, 4));
        }

        return resultado;

    }

    #endregion

    #region Métodos Publicos

    public void Consultar()
    {
        CoordenadorFiltroConsulta filtro = new CoordenadorFiltroConsulta();
        filtro.HabilitaTudo();

        CoordenadorVO coordenador = new CoordenadorVO();
        ICoordenadorProcesso processo = CoordenadorProcesso.Instance;

        coordenador.Nome = txtNome.Text.Trim();

        CoordenadorLista = processo.Consultar(coordenador, filtro, true);

        CarregarGrid();

    }

    private void CarregarGrid()
    {
        if (CoordenadorLista.Count > 0)
        {
            GrdCoordenador.DataSource = CoordenadorLista;
            GrdCoordenador.DataBind();
        }
        else
        {
            PreencherGridVazio();
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearSession();
            PreencherGridVazio();
        }
    }

    protected void btnPesquisar_OnClick(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtNome.Text.Trim()))
        {
            Consultar();
        }
        else
        {
            PreencherGridVazio();
            cvaAvisoDeErro.ErrorMessage = ConstantesCoordenador.COORDENADOR_NOMENAOINFORMADO;
            cvaAvisoDeErro.IsValid = false;
        }
    }

    protected void grdCoordenador_RowCreated(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell cell in e.Row.Cells)
        {
            Control control = cell.FindControl("idCoordenador");

            if (check && control != null && control is RadioButton)
            {
                ((RadioButton)control).Checked = check;
            }
        }
    }

    protected void grdCoordenador_PreRender(object sender, EventArgs e)
    {

        if (CoordenadorLista == null || CoordenadorLista.Count == 0)
        {
            PreencherGridVazio();
        }
    }

    protected void grdCoordenador_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdCoordenador.DataSource = CoordenadorLista;
        if (GrdCoordenador.DataSource != null)
        {
            GrdCoordenador.PageIndex = e.NewPageIndex;
            GrdCoordenador.DataBind();
        }
    }


}

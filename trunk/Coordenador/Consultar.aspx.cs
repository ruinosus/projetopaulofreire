using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Coordenador_Consultar : System.Web.UI.Page
{
    #region Atributos

    private int idCoordenador;

    private bool selecionado;

    #endregion

    #region Propriedades

    public int IdCoordenador
    {
        get { return idCoordenador; }
        set { idCoordenador = value; }
    }

    public bool Selecionado
    {
        get
        {
            return IdCoordenador > 0;
        }

    }

    #endregion

    private void HabilitarBotoes()
    {
        DesabilitarBotoes();

        if (Selecionado)
        {
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        btnIncluir.Enabled = true;
        btnRetornar.Enabled = true;

        updBotoes.Update();
    }

    private void DesabilitarBotoes()
    {
        btnAlterar.Enabled = false;
        btnExcluir.Enabled = false;
        btnIncluir.Enabled = false;
        btnRetornar.Enabled = false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DesabilitarBotoes();
        CoordenadorSelecionar1.OnSelect += new EventHandler(OnSelect);
        HabilitarBotoes();
    }

    void OnSelect(object sender, EventArgs e)
    {
        IdCoordenador = CoordenadorSelecionar1.IdCoordenador;
        HabilitarBotoes();
    }
    protected void btnIncluir_Click(object sender, EventArgs e)
    {
        Response.Redirect("Incluir.aspx",false);
    }
}

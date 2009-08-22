using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ppf.ModuloConexao;
using Ppf.ModuloConexao.Singleton;
using Ppf.ModuloCoordenador.Filtros;
using Ppf.ModuloCoordenador.Repositorios;
using Ppf.ModuloCoordenador.Fabricas;

namespace Ppf.ModuloCoordenador.Processos
{
    /// <summary>
    /// Summary description for CoordenadorProcesso
    /// </summary>
    public class CoordenadorProcesso : Singleton<CoordenadorProcesso>, ICoordenadorProcesso
    {

        #region Atributos
        private ICoordenadorRepositorio coordenadorRepositorio = null; 
        #endregion

        #region Construtor
        public CoordenadorProcesso()
        {
            coordenadorRepositorio = ModuloCoordenadorFabrica.GetCoordenadorRepositorio();
        }
        
        #endregion

        #region Métodos da Interface

        public void Incluir(CoordenadorVO coordenadorVO)
        {
            coordenadorRepositorio.Incluir(coordenadorVO);
        }

        public void Excluir(CoordenadorVO coordenadorVO)
        {
            coordenadorRepositorio.Excluir(coordenadorVO);
        }

        public void Alterar(CoordenadorVO coordenadorVO)
        {
            coordenadorRepositorio.Alterar(coordenadorVO);
        }

        public List<CoordenadorVO> Consultar(CoordenadorVO coordenadorVO, CoordenadorFiltroConsulta coordenadorFiltroConsulta, bool lazy)
        {
            return coordenadorRepositorio.Consultar(coordenadorVO, coordenadorFiltroConsulta, lazy);
        }

        public List<CoordenadorVO> Consultar(CoordenadorFiltroConsulta coordenadorFiltroConsulta, bool lazy)
        {
            return coordenadorRepositorio.Consultar(coordenadorFiltroConsulta, lazy);
        }

        #endregion
    }
}
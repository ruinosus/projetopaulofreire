using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ppf.ModuloCoordenador.Filtros;

namespace Ppf.ModuloCoordenador.Repositorios
{
    /// <summary>
    /// Summary description for ICoordenadorRepositorio
    /// </summary>
    public interface ICoordenadorRepositorio
    {
        void Incluir(CoordenadorVO coordenadorVO);

        void Excluir(CoordenadorVO coordenadorVO);

        void Alterar(CoordenadorVO coordenadorVO);

        List<CoordenadorVO> Consultar(CoordenadorVO coordenadorVO, CoordenadorFiltroConsulta coordenadorFiltroConsulta, bool lazy);

        List<CoordenadorVO> Consultar(CoordenadorFiltroConsulta coordenadorFiltroConsulta, bool lazy);

    }
}
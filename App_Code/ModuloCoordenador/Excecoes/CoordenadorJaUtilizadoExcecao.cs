using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ppf.ModuloCoordenador.Excecoes
{
    /// <summary>
    /// Summary description for CoordenadorJaUtilizadoExcecao
    /// </summary>
    public class CoordenadorJaUtilizadoExcecao : Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante.
        /// </summary>
        public CoordenadorJaUtilizadoExcecao()
            : base(ConstantesCoordenador.COORDENADOR_JAUTILIZADO)
        { }
    }
}
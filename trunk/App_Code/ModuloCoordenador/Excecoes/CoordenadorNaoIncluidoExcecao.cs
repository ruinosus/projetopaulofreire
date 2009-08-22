using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ppf.ModuloCoordenador.Excecoes
{

    /// <summary>
    /// Summary description for CoordenadorNaoIncluidoExcecao
    /// </summary>
    public class CoordenadorNaoIncluidoExcecao : Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante.
        /// </summary>
        public CoordenadorNaoIncluidoExcecao()
            : base(ConstantesCoordenador.COORDENADOR_NAOINCLUIDO)
        { }
    }
}
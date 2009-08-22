using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ppf.ModuloCoordenador.Excecoes
{
    /// <summary>
    /// Summary description for CoordenadorNaoExcluidoExcecao
    /// </summary>
    public class CoordenadorNaoExcluidoExcecao : Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante.
        /// </summary>
        public CoordenadorNaoExcluidoExcecao()
            : base(ConstantesCoordenador.COORDENADOR_NAOEXCLUIDO)
        { }
    }
}
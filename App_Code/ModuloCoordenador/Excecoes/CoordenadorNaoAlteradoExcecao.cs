using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ppf.ModuloCoordenador.Excecoes
{

    /// <summary>
    /// Summary description for CoordenadorNaoAlteradoExcecao
    /// </summary>
    public class CoordenadorNaoAlteradoExcecao : Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante.
        /// </summary>
        public CoordenadorNaoAlteradoExcecao()
            : base(ConstantesCoordenador.COORDENADOR_NAOALTERADO)
        { }
    }
}
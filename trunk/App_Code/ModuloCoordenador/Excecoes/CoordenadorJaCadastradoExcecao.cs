using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ppf.ModuloCoordenador.Excecoes
{
    /// <summary>
    /// Summary description for CoordenadorJaCadastradoExcecao
    /// </summary>
    public class CoordenadorJaCadastradoExcecao : Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante.
        /// </summary>
        public CoordenadorJaCadastradoExcecao()
            : base(ConstantesCoordenador.COORDENADOR_JACADASTRADO)
        { }
    }
}
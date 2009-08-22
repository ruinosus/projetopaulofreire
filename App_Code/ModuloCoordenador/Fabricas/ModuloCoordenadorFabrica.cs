using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ppf.ModuloCoordenador.Repositorios;

namespace Ppf.ModuloCoordenador.Fabricas
{
    /// <summary>
    /// Summary description for ModuloCoordenadorFabrica
    /// </summary>
    public static class ModuloCoordenadorFabrica
    {

        public static ICoordenadorRepositorio GetCoordenadorRepositorio()
        {
            return new CoordenadorRepositorio();
        }

    }
}
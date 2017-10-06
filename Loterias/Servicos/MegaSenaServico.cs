using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loterias.Models.Util;

namespace Loterias.Servicos
{
    public sealed class MegaSenaServico : LoteriaServico
    {
        public MegaSenaServico() : base(JogoLoteriaEnum.MegaSena)
        {
        }
    }
}
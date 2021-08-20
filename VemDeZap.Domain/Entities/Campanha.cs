using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities.Base;

namespace VemDeZap.Domain.Entities
{
    public class Campanha : EntityBase
    {
        protected Campanha()
        {
        }

        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
    }
}

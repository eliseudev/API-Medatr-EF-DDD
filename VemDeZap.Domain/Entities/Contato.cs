using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Enums;

namespace VemDeZap.Domain.Entities
{
    public class Contato : EntityBase
    {
        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnumNicho Nicho { get; set; }
    }
}

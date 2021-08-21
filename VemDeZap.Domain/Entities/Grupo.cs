using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities.Base;
using VemDeZap.Domain.Enums;

namespace VemDeZap.Domain.Entities
{
    public class Grupo : EntityBase
    {
        public Grupo(Usuario usuario, string nome, EnumNicho nicho)
        {
            Usuario = usuario;
            Nome = nome;
            Nicho = nicho;

            if(usuario == null)
            {
                AddNotification("Usuário", "Informe o usuário");
            }

            new AddNotifications<Grupo>(this)
                .IfNullOrInvalidLength(x => x.Nome, 3, 150)
                .IfEnumInvalid(x => x.Nicho);
        }

        protected Grupo()
        {
        }

        public Usuario Usuario { get; set; }
        public string Nome { get; set; }
        public EnumNicho Nicho { get; set; }

        public void AlterarGrupo(string nome, EnumNicho nicho)
        {
            Nome = nome;
            Nicho = nicho;
        }
    }
}

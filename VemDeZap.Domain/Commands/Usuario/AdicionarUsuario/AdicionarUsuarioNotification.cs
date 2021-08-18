using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Domain.Commands.Usuario.AdicionarUsuario
{
    public class AdicionarUsuarioNotification : INotification
    {
        public AdicionarUsuarioNotification(Entities.Usuario usuario)
        {
            Usuario = usuario;
        }
        public Entities.Usuario Usuario { get; set; }

    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Domain.Commands.Grupo.RemoverGrupo.Notification
{
    public class RemoverGrupoNotification : INotification
    {
        public RemoverGrupoNotification(Entities.Grupo grupo)
        {
            Grupo = grupo;
        }

        public Entities.Grupo Grupo { get; set; }
    }
}

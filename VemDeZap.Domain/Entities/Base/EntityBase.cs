using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace VemDeZap.Domain.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}

﻿using EducaMBAXpert.Core.Messages;
using EducaMBAXpert.Core.Messages.CommonMessages.DomainEvents;
using EducaMBAXpert.Core.Messages.CommonMessages.Notifications;

namespace EducaMBAXpert.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}

﻿using EducaMBAXpert.Core.Bus;
using EducaMBAXpert.Core.DomainObjects;
using EducaMBAXpert.Pagamentos.Data.Context;

namespace EducaMBAXpert.Pagamentos.Data.Extension
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatrHandler mediator, PagamentoContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublicarEvento(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}

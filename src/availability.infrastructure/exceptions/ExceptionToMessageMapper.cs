using System;
using availability.application.commands;
using availability.application.events.rejected;
using availability.application.exceptions;
using availability.core.exceptions;
using Convey.MessageBrokers.RabbitMQ;

namespace availability.infrastructure.exceptions {
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
        => exception switch {
            CannotExpropriateReservationException e => new ReserveResourceRejected(e.ResourceId, e.Code, e.Message),
            ResourceAlreadyExistsException e => new AddResourceRejected(e.Id, e.Code, e.Message),
            ResourceNotFoundException e => message switch {
                ReserveResource command => new ReserveResourceRejected(command.ResourceId, e.Code, e.Message),
                _ => null
            },
            _ => null
        };
    }
}
using System;
namespace Actio.Common.Events
{
    public interface IAuthenticatedEvent:IEvents
    {
        Guid UserId{get;}
    }
}
using System;

namespace Actio.Common.Events
{
    public class CreateActivityRejected : IRejectedEvent
    {
        public string Reason { get; }

        public string Code { get; }

        public Guid Id { get; }

        protected CreateActivityRejected()
        {
        }

        public CreateActivityRejected(string code, string reason, Guid id)
        {
            Reason = reason;
            Code = code;
            Id = id;
        }
    }
}

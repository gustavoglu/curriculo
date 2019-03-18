using Curriculo.Domain.Core.Events;
using System;

namespace Curriculo.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Version = 1;
            Id = Guid.NewGuid().ToString();
        }
        public string Key { get; protected set; }
        public string Value { get; protected set; }
        public int Version { get; protected set; }
        public string Id { get; protected set; }
    }
}

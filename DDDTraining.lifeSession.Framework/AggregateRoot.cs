using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Framework
{
    public abstract class AggregateRoot<TId> : IInternalEventHandler
            where TId : Value<TId>
    {
        public TId Id { get; protected set; }
        protected abstract void When(object @event);

        private readonly List<object> _changes;
        protected AggregateRoot() => _changes = new List<object>();
        protected void Apply(object @event)
        {
            When(@event);
            EnsureValidState();
            _changes.Add(@event);
        }
        protected void ApplyToEntity(
            IInternalEventHandler entity,
            object @event)
                => entity?.Handle(@event);
        public IEnumerable<object> GetChanges()
        => _changes.AsEnumerable();
        public void ClearChanges() => _changes.Clear();
        protected abstract void EnsureValidState();

        public void Handle(object @event)
        
            => When(@event);
        
    }
}

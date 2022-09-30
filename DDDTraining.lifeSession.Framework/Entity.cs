using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Framework
{
   public abstract class Entity<TId> :IInternalEventHandler where TId : Value<TId>
    {
        public TId Id { get; protected set; }
        private readonly Action<object> _applier;
        protected Entity(Action<object> applier)
        => _applier = applier;
        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);

        }
       

        protected abstract void When(object @event);

      
        public void Handle(object @event)
        
           => When(@event);
        
    }
}

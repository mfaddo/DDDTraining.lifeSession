using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
    public class TestEntity : Entity
    {
        // contract
        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        //events
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}

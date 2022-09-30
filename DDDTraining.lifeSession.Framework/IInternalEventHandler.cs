using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Framework
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}

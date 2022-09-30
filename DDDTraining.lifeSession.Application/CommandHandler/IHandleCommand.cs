using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Application.CommandHandler
{
    public interface IHandleCommand<in T>
    {
        Task Handle(T command);
    }
}

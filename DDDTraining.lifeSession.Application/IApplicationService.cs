using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Application
{
    public interface IApplicationService
    {
        Task Handle(object command);
    }
}

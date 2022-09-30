using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
    // new record feature to replace Value class in framework
    public record RecordMoney
    {
        public decimal Amount;
    }
}

using DDDTraining.lifeSession.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
    public class PictureId : Value<PictureId>
    {
        public PictureId(Guid value) => Value = value;
        public Guid Value { get; }
    }
}

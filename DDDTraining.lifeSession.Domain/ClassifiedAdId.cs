using DDDTraining.lifeSession.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
   public class ClassifiedAdId :Value <ClassifiedAdId>
    {
        private readonly Guid _value;
        public ClassifiedAdId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(
                nameof(value),
                "Classified Ad id cannot be empty");
            _value = value;
        }

        // research for this implicit operator...
        public static implicit operator Guid(ClassifiedAdId self)
            =>self._value;

        public static implicit operator ClassifiedAdId(string value) => 
            new ClassifiedAdId (Guid.Parse(value));
    }
}

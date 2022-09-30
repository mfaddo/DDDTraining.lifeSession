﻿using DDDTraining.lifeSession.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
   public class UserId : Value<UserId>
    {
        private readonly Guid _value;
        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(
                nameof(value), "User id cannot be empty");
            _value = value;
        }

        public static implicit operator Guid(UserId self)=>self._value;
    }
}

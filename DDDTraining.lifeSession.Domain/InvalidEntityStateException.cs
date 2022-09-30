﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTraining.lifeSession.Domain
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException(object entity, string message)
        : base($"Entity {entity.GetType().Name} state change rejected, { message}")
        {
        }
    }
}

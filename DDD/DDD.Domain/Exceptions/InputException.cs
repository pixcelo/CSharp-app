﻿using System;
using System.CodeDom;

namespace DDD.Domain.Exceptions
{
    public sealed class InputException : Exception
    {
        public InputException(string message) : base(message)
        {
               
        }
    }
}

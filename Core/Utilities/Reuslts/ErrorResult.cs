﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Reuslts
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false)
        {
            
        }
        public ErrorResult() : base(false)
        {
            
        }
    }
}

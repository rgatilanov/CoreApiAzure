﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiAzure.Models
{
    public class Login : UserMin
    {
        public string Token { get; set; }
    }
}
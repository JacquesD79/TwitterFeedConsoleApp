﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public string UserName { get; set; }
        public List<Follower> Followers { get; set; }
    }
}
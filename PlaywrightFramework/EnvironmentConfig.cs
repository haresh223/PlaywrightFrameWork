﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightFramework
{
    public class EnvironmentConfig
    {
        public string baseUrl { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string browserType { get; set; }
    }
}

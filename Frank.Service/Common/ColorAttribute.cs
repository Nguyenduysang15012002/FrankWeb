﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frank.Service.Common
{
    public class ColorAttribute : Attribute
    {
        public string Color { get; set; }
        public string BgColor { get; set; }
        public string Icon { get; set; }
    }
}
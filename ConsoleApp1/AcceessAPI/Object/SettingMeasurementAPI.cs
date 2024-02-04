﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceessAPI.Object
{
    public class SettingMeasurementAPI
    {
        private string _nameDomen;
        private string _version;

        public string NameDomen
        {
            get { return _nameDomen; }
            set { _nameDomen = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public SettingMeasurementAPI(string nameDomen, string version)
        {
            NameDomen = nameDomen;
            Version = version;
        }
    }
}

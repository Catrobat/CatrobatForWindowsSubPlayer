﻿using System;
using System.Xml.Linq;

namespace Catrobat.Data.Xml.XmlObjects
{
    public abstract class DataRootObject
    {
        protected XElement Root;

        public DataRootObject() {}

        public DataRootObject(String xml)
        {
        }

        protected abstract void LoadFromXML(String xmlSource);

        internal abstract XDocument CreateXML();
    }
}
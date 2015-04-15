﻿using System.Xml.Linq;

namespace Catrobat.Data.Xml.XmlObjects.Bricks.Nxt
{
    public partial class XmlNxtMotorStopBrick : XmlBrick
    {
        public string Motor { get; set; }

        public XmlNxtMotorStopBrick() {}

        public XmlNxtMotorStopBrick(XElement xElement) : base(xElement) {}

        internal override void LoadFromXml(XElement xRoot)
        {
            Motor = xRoot.Element("motor").Value;
        }

        internal override XElement CreateXml()
        {
            var xRoot = new XElement("legoNxtMotorStopBrick");

            xRoot.Add(new XElement("motor")
            {
                Value = Motor
            });

            //CreateCommonXML(xRoot);

            return xRoot;
        }
    }
}
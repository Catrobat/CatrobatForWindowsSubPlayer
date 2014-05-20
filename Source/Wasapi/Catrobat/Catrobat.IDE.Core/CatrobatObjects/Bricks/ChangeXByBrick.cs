﻿using System.Xml.Linq;
using Catrobat.IDE.Core.CatrobatObjects.Formulas;
using Catrobat.IDE.Core.Formulas;

namespace Catrobat.IDE.Core.CatrobatObjects.Bricks
{
    public class ChangeXByBrick : Brick
    {
        protected Formula _xMovement;
        public Formula XMovement
        {
            get { return _xMovement; }
            set
            {
                _xMovement = value;
                RaisePropertyChanged();
            }
        }


        public ChangeXByBrick() {}

        public ChangeXByBrick(XElement xElement) : base(xElement) {}

        internal override void LoadFromXML(XElement xRoot)
        {
            _xMovement = new Formula(xRoot.Element("xMovement"));
        }

        internal override XElement CreateXML()
        {
            var xRoot = new XElement("changeXByNBrick");

            var xVariable = new XElement("xMovement");
            xVariable.Add(_xMovement.CreateXML());
            xRoot.Add(xVariable);

            return xRoot;
        }

        internal override void LoadReference(XmlFormulaTreeConverter converter)
        {
            if (_xMovement != null)
                _xMovement.LoadReference(converter);
        }

        public override DataObject Copy()
        {
            var newBrick = new ChangeXByBrick();
            newBrick._xMovement = _xMovement.Copy() as Formula;

            return newBrick;
        }

        public override bool Equals(DataObject other)
        {
            var otherBrick = other as ChangeXByBrick;

            if (otherBrick == null)
                return false;

            return XMovement.Equals(otherBrick.XMovement);
        }
    }
}
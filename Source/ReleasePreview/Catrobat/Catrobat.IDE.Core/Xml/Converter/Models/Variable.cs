﻿using Catrobat.IDE.Core.Xml.Converter;
using Catrobat.IDE.Core.Xml.XmlObjects.Variables;

// ReSharper disable once CheckNamespace
namespace Catrobat.IDE.Core.Models
{
    abstract partial class Variable : IXmlObjectConvertible
    {
    }

    #region Implementations

    partial class GlobalVariable : IXmlObjectConvertible<XmlUserVariable>
    {
        XmlUserVariable IXmlObjectConvertible<XmlUserVariable>.ToXmlObject()
        {
            return new XmlUserVariable
            {
                Name = Name
            };
        }
    }

    partial class LocalVariable : IXmlObjectConvertible<XmlUserVariable>
    {
        XmlUserVariable IXmlObjectConvertible<XmlUserVariable>.ToXmlObject()
        {
            return new XmlUserVariable
            {
                Name = Name
            };
        }
    }

    #endregion
}

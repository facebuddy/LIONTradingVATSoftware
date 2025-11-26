using System;
using System.Xml;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class csXML
    {
        public csXML()
        {
        }

        public class XmlHelper
        {
            public XmlHelper()
            {
            }

            public static XmlNode AddAttribute(string attributeName, string textContent, XmlNode parent)
            {
                XmlAttribute xmlAttribute = parent.OwnerDocument.CreateAttribute(attributeName);
                xmlAttribute.Value = textContent;
                parent.Attributes.Append(xmlAttribute);
                return xmlAttribute;
            }

            public static XmlNode AddElement(string tagName, string textContent, XmlNode parent)
            {
                XmlNode xmlNodes = parent.OwnerDocument.CreateElement(tagName);
                parent.AppendChild(xmlNodes);
                if (textContent != null)
                {
                    XmlNode xmlNodes1 = parent.OwnerDocument.CreateTextNode(textContent);
                    xmlNodes.AppendChild(xmlNodes1);
                }
                return xmlNodes;
            }
        }
    }

}
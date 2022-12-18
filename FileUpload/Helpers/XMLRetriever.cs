using System;
using System.Xml.Linq;

namespace FileUpload.API.Helpers
{
    public class XMLRetriever
    {
        private XElement root;
        public XMLRetriever(XElement _root)
        {
            root = _root;
        }

        public string GetParameter(string param)
        {
            String value = null;
            XElement grandChild = null;
            try
            {
                string[] tokens = param.Split('.');
                for(int i = 0; i < tokens.Length; i++)
                {
                    XElement child;
                    if(i == 0)
                    {
                        child = root.Element(tokens[i]);
                    }
                    else
                    {
                        child = grandChild.Element(tokens[i]);
                    }
                    if (i == tokens.Length - 1)
                    {
                        value = child.Value;
                        break;
                    }
                    grandChild = child;
                }
                return value;
            } catch {
                return null;
            };
        }
    }
}
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace LibPostalNet
{
    public unsafe class AddressExpansionResponse
    {
        private sbyte** expansionsInternal;
        private ulong nInternal;

        internal AddressExpansionResponse(sbyte** expansions, ulong n)
        {
            expansionsInternal = expansions;
            nInternal = n;
        }

        internal void ExpansionArrayDestroy()
        {
            LibPostal.UnsafeNativeMethods.ExpansionArrayDestroy(expansionsInternal, nInternal);
        }

        public string[] Expansions
        {
            get
            {
                long n = (long)nInternal;
                sbyte** expansions = expansionsInternal;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    ret[x] = Marshal.PtrToStringAnsi((IntPtr)expansions[x]);
                }
                return ret;
            }
        }

        public string ToJSON()
        {
            var json = new JArray();
            foreach (var expansion in Expansions)
            {
                json.Add(new JValue(expansion));
            }
            return json.ToString();
        }

        public string ToXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", string.Empty));
            var address = doc.CreateElement("Address");
            foreach (var expansion in Expansions)
            {
                var elem = doc.CreateElement("Expansion");
                elem.InnerText = expansion;
                address.AppendChild(elem);
            }
            doc.AppendChild(address);
            return doc.OuterXml;
        }
    }
}

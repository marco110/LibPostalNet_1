using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace LibPostalNet
{
    public unsafe partial class AddressParserResponse : IDisposable
    {
        internal IntPtr Instance { get; set; }

        internal static readonly System.Collections.Concurrent.ConcurrentDictionary<IntPtr, AddressParserResponse> NativeToManagedMap = new System.Collections.Concurrent.ConcurrentDictionary<IntPtr, AddressParserResponse>();
        protected bool ownsNativeInstance;

        internal static AddressParserResponse __CreateInstance(IntPtr native, bool skipVTables = false)
        {
            return new AddressParserResponse(native.ToPointer(), skipVTables);
        }

        internal static AddressParserResponse __CreateInstance(UnsafeNativeMethods native, bool skipVTables = false)
        {
            return new AddressParserResponse(native, skipVTables);
        }

        private static void* __CopyValue(UnsafeNativeMethods native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            *(UnsafeNativeMethods*)ret = native;
            return ret.ToPointer();
        }

        private AddressParserResponse(UnsafeNativeMethods native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
        }

        internal AddressParserResponse(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            Instance = new IntPtr(native);
        }

        internal AddressParserResponse()
        {
            Instance = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
        }

        internal AddressParserResponse(AddressParserResponse _0)
        {
            Instance = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
            *((UnsafeNativeMethods*)Instance) = *((UnsafeNativeMethods*)_0.Instance);
        }

        ~AddressParserResponse()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Instance == IntPtr.Zero)
                return;
            AddressParserResponse __dummy;
            NativeToManagedMap.TryRemove(Instance, out __dummy);
            if (ownsNativeInstance)
                Marshal.FreeHGlobal(Instance);
            Instance = IntPtr.Zero;
        }

        public long NumComponents
        {
            get
            {
                return (long)((UnsafeNativeMethods*)Instance)->num_components;
            }

            //set
            //{
            //    ((Internal*)Instance)->num_components = (ulong)value;
            //}
        }

        public string[] Components
        {
            get
            {
                long n = NumComponents;
                sbyte** comps = (sbyte**)((UnsafeNativeMethods*)Instance)->components;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    ret[x] = Marshal.PtrToStringAnsi((IntPtr)comps[x]);
                }
                return ret;
                //return (sbyte**)((Internal*)Instance)->components;
            }

            //set
            //{
            //    ((Internal*)Instance)->components = (IntPtr)value;
            //}
        }

        public string[] Labels
        {
            get
            {
                long n = NumComponents;
                sbyte** labels = (sbyte**)((UnsafeNativeMethods*)Instance)->labels;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    ret[x] = Marshal.PtrToStringAnsi((IntPtr)labels[x]);
                }
                return ret;
                //return (sbyte**)((Internal*)Instance)->labels;
            }

            //set
            //{
            //    ((Internal*)Instance)->labels = (IntPtr)value;
            //}
        }

        public List<KeyValuePair<string, string>> Results
        {
            get
            {
                var _results = new List<KeyValuePair<string, string>>();

                sbyte**
                    labels = (sbyte**)((UnsafeNativeMethods*)Instance)->labels,
                    components = (sbyte**)((UnsafeNativeMethods*)Instance)->components
                ;

                unsafe
                {
                    for (int buc = 0; buc < (int)NumComponents; buc++)
                    {
                        sbyte* pLabel = labels[buc];
                        sbyte* pComponent = components[buc];

                        _results.Add(new KeyValuePair<string, string>(Marshal.PtrToStringAnsi((IntPtr)pLabel), Marshal.PtrToStringAnsi((IntPtr)pComponent)));
                    }
                }
                return _results;
            }
        }

        public string ToJSON()
        {
            var json = new JObject();
            foreach (var x in Results)
            {
                json.Add(new JProperty(x.Key, x.Value));
            }
            return json.ToString();
        }

        public string ToXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", string.Empty));
            var address = doc.CreateElement("Address");
            foreach (var x in Results)
            {
                var elem = doc.CreateElement(x.Key);
                elem.InnerText = x.Value;
                address.AppendChild(elem);
            }
            doc.AppendChild(address);
            return doc.OuterXml;
        }
    }
}

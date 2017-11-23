using System;

namespace LibPostalNet
{
    public unsafe partial class LibPostal
    {
        public static AddressExpansionOptions GetDefaultOptions()
        {
            var __ret = new AddressExpansionOptions.UnsafeNativeMethods();
            UnsafeNativeMethods.GetDefaultOptions(new IntPtr(&__ret));
            return AddressExpansionOptions.__CreateInstance(__ret);
        }
        public static AddressExpansionResponse ExpandAddress(string input, AddressExpansionOptions options)
        {
            ulong n = 0;
            var __arg1 = ReferenceEquals(options, null) ? new AddressExpansionOptions.UnsafeNativeMethods() : *(AddressExpansionOptions.UnsafeNativeMethods*)options.Instance;
            var __arg2 = &n;
            var __ret = UnsafeNativeMethods.ExpandAddress(input, __arg1, __arg2);
            return new AddressExpansionResponse(__ret, *__arg2);
        }
        public static void ExpansionArrayDestroy(AddressExpansionResponse self)
        {
            self.ExpansionArrayDestroy();
        }

        
        public static AddressParserOptions GetAddressParserDefaultOptions()
        {
            var __ret = new AddressParserOptions.UnsafeNativeMethods();
            UnsafeNativeMethods.GetAddressParserDefaultOptions(new IntPtr(&__ret));
            return AddressParserOptions.__CreateInstance(__ret);
        }
        public static AddressParserResponse ParseAddress(string address, AddressParserOptions options)
        {
            var __arg1 = ReferenceEquals(options, null) ? new AddressParserOptions.UnsafeNativeMethods() : *(AddressParserOptions.UnsafeNativeMethods*)options.Instance;
            var __ret = UnsafeNativeMethods.ParseAddress(address, __arg1);
            AddressParserResponse __result0;
            if (__ret == IntPtr.Zero) __result0 = null;
            else if (AddressParserResponse.NativeToManagedMap.ContainsKey(__ret))
                __result0 = AddressParserResponse.NativeToManagedMap[__ret];
            else __result0 = AddressParserResponse.__CreateInstance(__ret);
            return __result0;
        }
        public static void AddressParserResponseDestroy(AddressParserResponse self)
        {
            var __arg0 = ReferenceEquals(self, null) ? IntPtr.Zero : self.Instance;
            UnsafeNativeMethods.AddressParserResponseDestroy(__arg0);
        }


        public static bool Setup()
        {
            var __ret = UnsafeNativeMethods.Setup();
            return __ret;
        }
        public static bool Setup(string datadir)
        {
            var __ret = UnsafeNativeMethods.SetupDatadir(datadir);
            return __ret;
        }
        public static void Teardown()
        {
            UnsafeNativeMethods.Teardown();
        }

        public static bool SetupParser()
        {
            var __ret = UnsafeNativeMethods.SetupParser();
            return __ret;
        }
        public static bool SetupParser(string datadir)
        {
            var __ret = UnsafeNativeMethods.SetupParserDatadir(datadir);
            return __ret;
        }
        public static void TeardownParser()
        {
            UnsafeNativeMethods.TeardownParser();
        }

        public static bool SetupLanguageClassifier()
        {
            var __ret = UnsafeNativeMethods.SetupLanguageClassifier();
            return __ret;
        }
        public static bool SetupLanguageClassifier(string datadir)
        {
            var __ret = UnsafeNativeMethods.SetupLanguageClassifierDatadir(datadir);
            return __ret;
        }
        public static void TeardownLanguageClassifier()
        {
            UnsafeNativeMethods.TeardownLanguageClassifier();
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace LibPostalNet
{
    public unsafe partial class AddressExpansionOptions : IDisposable
    {
        internal IntPtr Instance { get; set; }

        internal static readonly System.Collections.Concurrent.ConcurrentDictionary<IntPtr, AddressExpansionOptions> NativeToManagedMap = new System.Collections.Concurrent.ConcurrentDictionary<IntPtr, AddressExpansionOptions>();
        protected bool ownsNativeInstance;

        internal static AddressExpansionOptions __CreateInstance(IntPtr native, bool skipVTables = false)
        {
            return new AddressExpansionOptions(native.ToPointer(), skipVTables);
        }

        internal static AddressExpansionOptions __CreateInstance(UnsafeNativeMethods native, bool skipVTables = false)
        {
            return new AddressExpansionOptions(native, skipVTables);
        }

        private static void* __CopyValue(UnsafeNativeMethods native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            *(UnsafeNativeMethods*)ret = native;
            return ret.ToPointer();
        }

        private AddressExpansionOptions(UnsafeNativeMethods native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
        }

        internal AddressExpansionOptions(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            Instance = new IntPtr(native);
        }

        internal AddressExpansionOptions()
        {
            Instance = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
        }

        internal AddressExpansionOptions(AddressExpansionOptions _0)
        {
            Instance = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
            *((UnsafeNativeMethods*)Instance) = *((UnsafeNativeMethods*)_0.Instance);
        }

        ~AddressExpansionOptions()
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
            AddressExpansionOptions __dummy;
            NativeToManagedMap.TryRemove(Instance, out __dummy);
            if (ownsNativeInstance)
                Marshal.FreeHGlobal(Instance);
            Instance = IntPtr.Zero;
        }

        //public string[] Langs
        //{
        //    get
        //    {
        //        IList<string> _lang = new List<string>();
        //        unsafe
        //        {
        //            for (int buc = 0; buc < (int)NumLanguages; buc++)
        //            {
        //                sbyte* pLang = Languages[buc];
        //                _lang.Add(Marshal.PtrToStringAnsi((IntPtr)pLang));
        //            }
        //        }
        //        return _lang.ToArray();
        //    }
        //}

        public string[] Languages
        {
            get
            {
                long n = NumLanguages;
                sbyte** langs = (sbyte**)((UnsafeNativeMethods*)Instance)->languages;
                string[] ret = new string[n];
                for (int x = 0; x < n; x++)
                {
                    ret[x] = Marshal.PtrToStringAnsi((IntPtr)langs[x]);
                }
                return ret;
            }

            //set
            //{
            //    ((Internal*)Instance)->languages = (IntPtr)value;
            //}
        }

        public long NumLanguages
        {
            get
            {
                return (long)((UnsafeNativeMethods*)Instance)->num_languages;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->num_languages = (ulong)value;
            }
        }

        public long AddressComponents
        {
            get
            {
                return (short)((UnsafeNativeMethods*)Instance)->address_components;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->address_components = (ushort)value;
            }
        }

        public bool LatinAscii
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->latin_ascii != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->latin_ascii = (byte)(value ? 1 : 0);
            }
        }

        public bool Transliterate
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->transliterate != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->transliterate = (byte)(value ? 1 : 0);
            }
        }

        public bool StripAccents
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->strip_accents != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->strip_accents = (byte)(value ? 1 : 0);
            }
        }

        public bool Decompose
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->decompose != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->decompose = (byte)(value ? 1 : 0);
            }
        }

        public bool Lowercase
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->lowercase != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->lowercase = (byte)(value ? 1 : 0);
            }
        }

        public bool TrimString
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->trim_string != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->trim_string = (byte)(value ? 1 : 0);
            }
        }

        public bool DropParentheticals
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->drop_parentheticals != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->drop_parentheticals = (byte)(value ? 1 : 0);
            }
        }

        public bool ReplaceNumericHyphens
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->replace_numeric_hyphens != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->replace_numeric_hyphens = (byte)(value ? 1 : 0);
            }
        }

        public bool DeleteNumericHyphens
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->delete_numeric_hyphens != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->delete_numeric_hyphens = (byte)(value ? 1 : 0);
            }
        }

        public bool SplitAlphaFromNumeric
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->split_alpha_from_numeric != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->split_alpha_from_numeric = (byte)(value ? 1 : 0);
            }
        }

        public bool ReplaceWordHyphens
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->replace_word_hyphens != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->replace_word_hyphens = (byte)(value ? 1 : 0);
            }
        }

        public bool DeleteWordHyphens
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->delete_word_hyphens != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->delete_word_hyphens = (byte)(value ? 1 : 0);
            }
        }

        public bool DeleteFinalPeriods
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->delete_final_periods != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->delete_final_periods = (byte)(value ? 1 : 0);
            }
        }

        public bool DeleteAcronymPeriods
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->delete_acronym_periods != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->delete_acronym_periods = (byte)(value ? 1 : 0);
            }
        }

        public bool DropEnglishPossessives
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->drop_english_possessives != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->drop_english_possessives = (byte)(value ? 1 : 0);
            }
        }

        public bool DeleteApostrophes
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->delete_apostrophes != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->delete_apostrophes = (byte)(value ? 1 : 0);
            }
        }

        public bool ExpandNumex
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->expand_numex != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->expand_numex = (byte)(value ? 1 : 0);
            }
        }

        public bool RomanNumerals
        {
            get
            {
                return ((UnsafeNativeMethods*)Instance)->roman_numerals != 0;
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->roman_numerals = (byte)(value ? 1 : 0);
            }
        }
    }
}

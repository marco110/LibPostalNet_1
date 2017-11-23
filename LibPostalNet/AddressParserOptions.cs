using System;
using System.Runtime.InteropServices;

namespace LibPostalNet
{
    public unsafe partial class AddressParserOptions : IDisposable
    {
        internal IntPtr Instance { get; set; }

        internal static readonly System.Collections.Concurrent.ConcurrentDictionary<IntPtr, AddressParserOptions> NativeToManagedMap = new System.Collections.Concurrent.ConcurrentDictionary<IntPtr, AddressParserOptions>();
        protected bool ownsNativeInstance;

        internal static AddressParserOptions __CreateInstance(IntPtr native, bool skipVTables = false)
        {
            return new AddressParserOptions(native.ToPointer(), skipVTables);
        }

        internal static AddressParserOptions __CreateInstance(UnsafeNativeMethods native, bool skipVTables = false)
        {
            return new AddressParserOptions(native, skipVTables);
        }

        private static void* __CopyValue(UnsafeNativeMethods native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            *(UnsafeNativeMethods*)ret = native;
            return ret.ToPointer();
        }

        private AddressParserOptions(UnsafeNativeMethods native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
        }

        internal AddressParserOptions(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            Instance = new IntPtr(native);
        }

        internal AddressParserOptions()
        {
            Instance = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
        }

        internal AddressParserOptions(AddressParserOptions _0)
        {
            Instance = Marshal.AllocHGlobal(sizeof(UnsafeNativeMethods));
            ownsNativeInstance = true;
            NativeToManagedMap[Instance] = this;
            *((UnsafeNativeMethods*)Instance) = *((UnsafeNativeMethods*)_0.Instance);
        }

        ~AddressParserOptions()
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
            AddressParserOptions __dummy;
            NativeToManagedMap.TryRemove(Instance, out __dummy);
            if (ownsNativeInstance)
                Marshal.FreeHGlobal(Instance);
            Instance = IntPtr.Zero;
        }

        public string Language
        {
            get
            {
                return Marshal.PtrToStringAnsi(((UnsafeNativeMethods*)Instance)->language);
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->language = Marshal.StringToHGlobalAnsi(value);
            }
        }

        public string Country
        {
            get
            {
                return Marshal.PtrToStringAnsi(((UnsafeNativeMethods*)Instance)->country);
            }

            set
            {
                ((UnsafeNativeMethods*)Instance)->country = Marshal.StringToHGlobalAnsi(value);
            }
        }
    }
}

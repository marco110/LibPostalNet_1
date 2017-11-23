using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public unsafe partial class AddressParserOptions
    {
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal unsafe struct UnsafeNativeMethods
        {
            [FieldOffset(0)]
            internal IntPtr language;

            [FieldOffset(8)]
            internal IntPtr country;

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "??0libpostal_address_parser_options@@QEAA@AEBU0@@Z")]
            internal static extern IntPtr cctor(IntPtr instance, IntPtr _0);
        }
    }
}

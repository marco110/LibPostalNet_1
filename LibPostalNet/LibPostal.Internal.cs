using System;
using System.Runtime.InteropServices;
using System.Security;

namespace LibPostalNet
{
    public unsafe partial class LibPostal
    {
        internal unsafe struct UnsafeNativeMethods
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_get_default_options")]
            internal static extern void GetDefaultOptions(IntPtr @return);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_expand_address")]
            internal static extern sbyte** ExpandAddress([MarshalAs(UnmanagedType.LPStr)] string input, AddressExpansionOptions.UnsafeNativeMethods options, ulong* n);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_expansion_array_destroy")]
            internal static extern void ExpansionArrayDestroy(sbyte** expansions, ulong n);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_address_parser_response_destroy")]
            internal static extern void AddressParserResponseDestroy(IntPtr self);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_get_address_parser_default_options")]
            internal static extern void GetAddressParserDefaultOptions(IntPtr @return);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_parse_address")]
            internal static extern IntPtr ParseAddress([MarshalAs(UnmanagedType.LPStr)] string address, AddressParserOptions.UnsafeNativeMethods options);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool Setup();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_datadir")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupDatadir([MarshalAs(UnmanagedType.LPStr)] string datadir);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_teardown")]
            internal static extern void Teardown();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_parser")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupParser();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_parser_datadir")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupParserDatadir([MarshalAs(UnmanagedType.LPStr)] string datadir);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_teardown_parser")]
            internal static extern void TeardownParser();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_language_classifier")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupLanguageClassifier();

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_setup_language_classifier_datadir")]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool SetupLanguageClassifierDatadir([MarshalAs(UnmanagedType.LPStr)] string datadir);

            [SuppressUnmanagedCodeSecurity]
            [DllImport("libpostal", CallingConvention = CallingConvention.Cdecl,
                EntryPoint = "libpostal_teardown_language_classifier")]
            internal static extern void TeardownLanguageClassifier();
        }
    }
}

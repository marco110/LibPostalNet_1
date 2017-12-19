# LibPostalNet: A .Net Wrapper for [libpostal](https://github.com/openvenues/libpostal)

[![Build Status](https://ci.appveyor.com/api/projects/status/github/aeroxuk/libpostalnet?branch=master&svg=true)](https://ci.appveyor.com/project/aeroxuk/libpostalnet/branch/master)
[![License](https://img.shields.io/github/license/aeroxuk/libpostalnet.svg)](https://github.com/aeroxuk/libpostalnet/blob/master/LICENSE)

These are unofficial .Net bindings for [libpostal](https://github.com/openvenues/libpostal), a fast statistical parser/normalizer for street addresses anywhere in the world.

Installation
------------

Before using the .Net bindings, you must build the libpostal C library or download the precompiled library.
Build instructions can be found here: https://github.com/openvenues/libpostal#installation-windows

Downloads (From openvenues/libpostal AppVeyor CI):
+ [x86 / 32-bit version](https://goo.gl/Bf3EzE)
+ [x64 / 64-bit version](https://goo.gl/o8DAi8)

Usage
-----

```c#
using LibPostalNet;
using System;

namespace LibPostalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "781 Franklin Ave Crown Heights Brooklyn NYC NY 11216 USA";

            LibPostal libPostal = LibPostal.GetInstance();

            var expansionOptions = libPostal.GetAddressExpansionDefaultOptions();
            using (var expansion = libPostal.ExpandAddress(address, expansionOptions))
            {
                Console.WriteLine(expansion.ToJSON());
            }

            var parserOptions = libPostal.GetAddressParserDefaultOptions();
            using (var response = libPostal.ParseAddress(address, parserOptions))
            {
                Console.WriteLine(response.ToJSON());
            }
        }
    }
}
```

License
-------

The software is available as open source under the terms of the [MIT License](http://opensource.org/licenses/MIT).

﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Loretta.Utils
{
    // interop with C
    public static class CInterop
    {
        [DllImport ( "ucrtbase.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "atof", CharSet = CharSet.Ansi )]
        [return: MarshalAs ( UnmanagedType.R8 )]
        public static extern Double atof ( [MarshalAs ( UnmanagedType.LPStr )] String number );

        public static String ConvertStringToASCII ( String value )
        {
            using ( var mem = new MemoryStream ( ) )
            using ( var writer = new StreamWriter ( mem, new UTF8Encoding ( false, false ) ) )
            using ( var reader = new StreamReader ( mem, Encoding.GetEncoding ( 28591 ) ) )
            {
                writer.AutoFlush = true;
                writer.Write ( value );

                mem.Seek ( 0, SeekOrigin.Begin );
                return reader.ReadToEnd ( );
            }
        }

        public static String ReadToEndAsASCII ( Stream source )
        {
            using ( var reader = new StreamReader ( source ) )
                return ConvertStringToASCII ( reader.ReadToEnd ( ) );
        }
    }
}

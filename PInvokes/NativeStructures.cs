// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace RaphaëlBardini.WinClean.PInvokes
{

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHSTOCKICONINFO : IEquatable<SHSTOCKICONINFO>
    {
#pragma warning disable CA1051

        public uint cbSize;
        public IntPtr hIcon;
        public int iSysIconIndex;
        public int iIcon;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]// 260 is MAX_PATH
        public string szPath;

#pragma warning restore CA1051

        public override bool Equals(object obj) => obj is SHSTOCKICONINFO sHSTOCKICONINFO && Equals(sHSTOCKICONINFO);

        public bool Equals(SHSTOCKICONINFO other) => cbSize == other.cbSize && hIcon.Equals(other.hIcon) && iSysIconIndex == other.iSysIconIndex && iIcon == other.iIcon && szPath == other.szPath;

        public override int GetHashCode() => HashCode.Combine(cbSize, hIcon, iSysIconIndex, iIcon, szPath);

        public static bool operator ==(SHSTOCKICONINFO left, SHSTOCKICONINFO right) => left.Equals(right);

        public static bool operator !=(SHSTOCKICONINFO left, SHSTOCKICONINFO right) => !(left == right);
    }
}

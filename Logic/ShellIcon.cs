// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    [Flags]
    public enum ShellIcon
    {
        /// <inheritdoc cref="SHGSI.SHGSI_LARGEICON"/>
        /// <remarks>Default behavior</remarks>
        None = SHGSI.SHGSI_LARGEICON,

        /// <inheritdoc cref="SHGSI.SHGSI_LINKOVERLAY"/>
        LinkOverlay = SHGSI.SHGSI_LINKOVERLAY,

        /// <inheritdoc cref="SHGSI.SHGSI_SELECTED"/>
        Selected = SHGSI.SHGSI_SELECTED,

        /// <inheritdoc cref="SHGSI.SHGSI_SMALLICON"/>
        Small = SHGSI.SHGSI_SMALLICON,

        /// <inheritdoc cref="SHGSI.SHGSI_SHELLICONSIZE"/>
        ShellSize = SHGSI.SHGSI_SHELLICONSIZE
    }

#pragma warning restore CA1720
#pragma warning restore CA1069
#pragma warning restore CA1712
#pragma warning restore CA1707
#pragma warning restore CA1008
#pragma warning restore CA1028
}

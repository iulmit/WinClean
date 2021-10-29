// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>If a script is advised for general purpose</summary>
    public enum ScriptAdvised
    {
        /// <summary>Not specified. It should be.</summary>
        Unspecified,

        /// <summary>
        /// The script is advised for any user. It has almost no side effects and won't hinder features the said user might want
        /// to use. It can be selected automatically.
        /// </summary>
        Yes,

        /// <summary>
        /// The script only advised for users who want advanced optimisation. It may hinder useful system features. It should be
        /// selected individually by the user.
        /// </summary>
        Limited,

        /// <summary>
        /// The script must be selected only by users who know what they are doing. It will almost certainly hinder useful
        /// system features. It should be selected by the user, only if specifically needed.
        /// </summary>
        No
    }
}

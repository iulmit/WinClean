// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Effect of running a script.</summary>
    public enum ImpactEffect
    {
        /// <summary>System praticality.</summary>
        Ergonomics,

        /// <summary>Idle system memory usage.</summary>
        MemoryUsage,

        /// <summary>Idle system network usage.</summary>
        NetworkUsage,

        /// <summary>System rapidity of executing commands.</summary>
        ResponseTime,

        /// <summary>System shutdown time.</summary>
        ShutdownTime,

        /// <summary>System privacy invasion and spying.</summary>
        DataCollection,

        /// <summary>System startup time.</summary>
        StartupTime,

        /// <summary>Free storage space.</summary>
        StorageCapacity,

        /// <summary>Storage read-write speed.</summary>
        StorageSpeed,

        /// <summary>System visuals.</summary>
        Visuals
    }
}

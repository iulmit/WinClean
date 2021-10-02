// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Operational
{
    public static class SystemMetrics
    {
        #region Public Methods

        public static int Get(PInvokes.SystemMetric metric) => PInvokes.NativeMethods.GetSystemMetrics(metric);

        #endregion Public Methods
    }
}

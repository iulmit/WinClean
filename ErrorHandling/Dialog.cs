// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.ErrorHandling;

public abstract class Dialog : TaskDialogPage
{
    #region Protected Constructors

    protected Dialog()
    {
        Caption = Application.ProductName;
        SizeToContent = true;
    }

    #endregion Protected Constructors
}

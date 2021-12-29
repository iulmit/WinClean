namespace RaphaëlBardini.WinClean.Presentation;

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
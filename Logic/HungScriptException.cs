// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    public class HungScriptException : Exception
    {
        #region Public Constructors

        public HungScriptException()
        {
        }

        public HungScriptException(Operational.Script script)
            : base(Resources.ErrorMessages.HungScript(Constants.ScriptTimeoutSeconds))
            => Script = script;

        public HungScriptException(string message) : base(message)
        {
        }

        public HungScriptException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public Operational.Script Script { get; }

        #endregion Public Properties
    }
}

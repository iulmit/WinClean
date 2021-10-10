// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    public class BadFileExtensionException : Exception
    {
        #region Public Constructors

        public BadFileExtensionException()
        {
        }

        public BadFileExtensionException(string extension) : base($"Unsupported file extension for the operation : {extension}")
        {
            Extension = extension;
        }

        public BadFileExtensionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public string Extension { get; }

        #endregion Public Properties
    }
}

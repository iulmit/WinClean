﻿// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this
// file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Operational;

/// <summary>
/// The exception is thrown when a file has the wrong extension.
/// </summary>
public class BadFileExtensionException : IOException
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BadFileExtensionException"/> class.
    /// </summary>
    public BadFileExtensionException() : base("A bad file extension has been specified.")
    {
    }

    /// <inheritdoc cref="BadFileExtensionException()"/>
    /// <param name="extension">The wrong extension.</param>
    public BadFileExtensionException(string? extension) : base($"Bad file extension for the operation : '{extension}'.") => Extension = extension;

    /// <inheritdoc cref="BadFileExtensionException()"/>
    /// <param name="extension">The wrong extension.</param>
    /// <param name="message">The exception's message.</param>
    public BadFileExtensionException(string? extension, string? message) : base(message) => Extension = extension;

    /// <inheritdoc cref="BadFileExtensionException(string)"/>
    /// <inheritdoc path="/param"/>
    public BadFileExtensionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// The wrong file extension.
    /// </summary>
    public string? Extension { get; } = string.Empty;

    #endregion Public Properties
}
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RaphaëlBardini.WinClean.Operation
{
    /// <summary>Provides methods to show the administrator icon next to a ButtonControl.</summary>
    public static class ButtonShieldExtension
    {
        #region Private Enums

        private enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            MaxTokenInfoClass
        }

        #endregion Private Enums

        #region Public Methods

        /// <summary>Ajoute l'icône des permissions administrateurs à un contrôle de bouton.</summary>
        /// <param name="b">Le bouton à modifier.</param>
        public static void AddShield(this ButtonBase b)
        {
            b.FlatStyle = FlatStyle.System;
            _ = SendMessage(b.Handle, 0x1600 + 0x000C, IntPtr.Zero, (IntPtr)1);
        }

        /// <summary>Enlève l'icône des permissions administrateurs à un contrôle de bouton.</summary>
        /// <param name="b">Le bouton à modifier.</param>
        public static void RemoveShield(this ButtonBase b)
        {
            b.FlatStyle = FlatStyle.System;
            _ = SendMessage(b.Handle, 0x1600 + 0x000C, IntPtr.Zero, (IntPtr)0);
        }

        [DllImport("user32")]
        private static extern uint SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        #endregion Public Methods

        #region Private Methods

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool GetTokenInformation(IntPtr TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, IntPtr TokenInformation, uint TokenInformationLength, out uint ReturnLength);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

        #endregion Private Methods
    }
}

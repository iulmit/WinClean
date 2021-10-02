// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace RaphaëlBardini.WinClean.PInvokes
{
    #region Enums

#pragma warning disable CA1712
#pragma warning disable CA1008
#pragma warning disable CA1707
#pragma warning disable CA1069
#pragma warning disable CA1028

    [Flags]
    public enum SHGSI
    {
        /// <summary>
        /// The szPath and iIcon members of the SHSTOCKICONINFO structure receive the path and icon index of the requested icon, in a format suitable for passing to the ExtractIcon function. The
        /// numerical value of this flag is zero, so you always get the icon location regardless of other flags.
        /// </summary>

        SHGSI_ICONLOCATION = 0,

        /// <summary>The hIcon member of the SHSTOCKICONINFO structure receives a handle to the specified icon.</summary>
        SHGSI_ICON = 0x000000100,

        /// <summary>The iSysImageImage member of the SHSTOCKICONINFO structure receives the index of the specified icon in the system imagelist.</summary>
        SHGSI_SYSICONINDEX = 0x000004000,

        /// <summary>Modifies the SHGSI_ICON value by causing the function to add the link overlay to the file's icon.</summary>
        SHGSI_LINKOVERLAY = 0x000008000,

        /// <summary>Modifies the SHGSI_ICON value by causing the function to blend the icon with the system highlight color.</summary>
        SHGSI_SELECTED = 0x000010000,

        /// <summary>Modifies the SHGSI_ICON value by causing the function to retrieve the large version of the icon, as specified by the SM_CXICON and SM_CYICON system metrics.</summary>
        SHGSI_LARGEICON = 0x000000000,

        /// <summary>Modifies the SHGSI_ICON value by causing the function to retrieve the small version of the icon, as specified by the SM_CXSMICON and SM_CYSMICON system metrics.</summary>
        SHGSI_SMALLICON = 0x000000001,

        /// <summary>Modifies the SHGSI_LARGEICON or SHGSI_SMALLICON values by causing the function to retrieve the Shell-sized icons rather than the sizes specified by the system metrics.</summary>
        SHGSI_SHELLICONSIZE = 0x000000004
    }

    public enum SHSTOCKICONID : uint
    {
        /// <summary>Document of a type with no associated application.</summary>
        SIID_DOCNOASSOC = 0,

        /// <summary>Document of a type with an associated application.</summary>
        SIID_DOCASSOC = 1,

        /// <summary>Generic application with no custom icon.</summary>
        SIID_APPLICATION = 2,

        /// <summary>Folder (generic, unspecified state).</summary>
        SIID_FOLDER = 3,

        /// <summary>Folder (open).</summary>
        SIID_FOLDEROPEN = 4,

        /// <summary>5.25-inch disk drive.</summary>
        SIID_DRIVE525 = 5,

        /// <summary>3.5-inch disk drive.</summary>
        SIID_DRIVE35 = 6,

        /// <summary>Removable drive.</summary>
        SIID_DRIVEREMOVE = 7,

        /// <summary>Fixed drive (hard disk).</summary>
        SIID_DRIVEFIXED = 8,

        /// <summary>Network drive (connected).</summary>
        SIID_DRIVENET = 9,

        /// <summary>Network drive (disconnected).</summary>
        SIID_DRIVENETDISABLED = 10,

        /// <summary>CD drive.</summary>
        SIID_DRIVECD = 11,

        /// <summary>RAM disk drive.</summary>
        SIID_DRIVERAM = 12,

        /// <summary>The entire network.</summary>
        SIID_WORLD = 13,

        /// <summary>A computer on the network.</summary>
        SIID_SERVER = 15,

        /// <summary>A local printer or print destination.</summary>
        SIID_PRINTER = 16,

        /// <summary>The Network virtual folder (FOLDERID_NetworkFolder/CSIDL_NETWORK).</summary>
        SIID_MYNETWORK = 17,

        /// <summary>The Search feature.</summary>
        SIID_FIND = 22,

        /// <summary>The Help and Support feature.</summary>
        SIID_HELP = 23,

        /// <summary>Overlay for a shared item.</summary>
        SIID_SHARE = 28,

        /// <summary>Overlay for a shortcut.</summary>
        SIID_LINK = 29,

        /// <summary>Overlay for items that are expected to be slow to access.</summary>
        SIID_SLOWFILE = 30,

        /// <summary>The Recycle Bin (empty).</summary>
        SIID_RECYCLER = 31,

        /// <summary>The Recycle Bin (not empty).</summary>
        SIID_RECYCLERFULL = 32,

        /// <summary>Audio CD media.</summary>
        SIID_MEDIACDAUDIO = 40,

        /// <summary>Security lock.</summary>
        SIID_LOCK = 47,

        /// <summary>A virtual folder that contains the results of a search.</summary>
        SIID_AUTOLIST = 49,

        /// <summary>A network printer.</summary>
        SIID_PRINTERNET = 50,

        /// <summary>A server shared on a network.</summary>
        SIID_SERVERSHARE = 51,

        /// <summary>A local fax printer.</summary>
        SIID_PRINTERFAX = 52,

        /// <summary>A network fax printer.</summary>
        SIID_PRINTERFAXNET = 53,

        /// <summary>A file that receives the output of a Print to file operation.</summary>
        SIID_PRINTERFILE = 54,

        /// <summary>A category that results from a Stack by command to organize the contents of a folder.</summary>
        SIID_STACK = 55,

        /// <summary>Super Video CD (SVCD) media.</summary>
        SIID_MEDIASVCD = 56,

        /// <summary>A folder that contains only subfolders as child items.</summary>
        SIID_STUFFEDFOLDER = 57,

        /// <summary>Unknown drive type.</summary>
        SIID_DRIVEUNKNOWN = 58,

        /// <summary>DVD drive.</summary>
        SIID_DRIVEDVD = 59,

        /// <summary>DVD media.</summary>
        SIID_MEDIADVD = 60,

        /// <summary>DVD-RAM media.</summary>
        SIID_MEDIADVDRAM = 61,

        /// <summary>DVD-RW media.</summary>
        SIID_MEDIADVDRW = 62,

        /// <summary>DVD-R media.</summary>
        SIID_MEDIADVDR = 63,

        /// <summary>DVD-ROM media.</summary>
        SIID_MEDIADVDROM = 64,

        /// <summary>CD+ (enhanced audio CD) media.</summary>
        SIID_MEDIACDAUDIOPLUS = 65,

        /// <summary>CD-RW media.</summary>
        SIID_MEDIACDRW = 66,

        /// <summary>CD-R media.</summary>
        SIID_MEDIACDR = 67,

        /// <summary>A writable CD in the process of being burned.</summary>
        SIID_MEDIACDBURN = 68,

        /// <summary>Blank writable CD media.</summary>
        SIID_MEDIABLANKCD = 69,

        /// <summary>CD-ROM media.</summary>
        SIID_MEDIACDROM = 70,

        /// <summary>An audio file.</summary>
        SIID_AUDIOFILES = 71,

        /// <summary>An image file.</summary>
        SIID_IMAGEFILES = 72,

        /// <summary>A video file.</summary>
        SIID_VIDEOFILES = 73,

        /// <summary>A mixed file.</summary>
        SIID_MIXEDFILES = 74,

        /// <summary>Folder back.</summary>
        SIID_FOLDERBACK = 75,

        /// <summary>Folder front.</summary>
        SIID_FOLDERFRONT = 76,

        /// <summary>Security shield. Use for UAC prompts only.</summary>
        SIID_SHIELD = 77,

        /// <summary>Warning.</summary>
        SIID_WARNING = 78,

        /// <summary>Informational.</summary>
        SIID_INFO = 79,

        /// <summary>Error.</summary>
        SIID_ERROR = 80,

        /// <summary>Key.</summary>
        SIID_KEY = 81,

        /// <summary>Software.</summary>
        SIID_SOFTWARE = 82,

        /// <summary>A UI item, such as a button, that issues a rename command.</summary>
        SIID_RENAME = 83,

        /// <summary>A UI item, such as a button, that issues a delete command.</summary>
        SIID_DELETE = 84,

        /// <summary>Audio DVD media.</summary>
        SIID_MEDIAAUDIODVD = 85,

        /// <summary>Movie DVD media.</summary>
        SIID_MEDIAMOVIEDVD = 86,

        /// <summary>Enhanced CD media.</summary>
        SIID_MEDIAENHANCEDCD = 87,

        /// <summary>Enhanced DVD media.</summary>
        SIID_MEDIAENHANCEDDVD = 88,

        /// <summary>High definition DVD media in the HD DVD format.</summary>
        SIID_MEDIAHDDVD = 89,

        /// <summary>High definition DVD media in the Blu-ray Disc™ format.</summary>
        SIID_MEDIABLURAY = 90,

        /// <summary>Video CD (VCD) media.</summary>
        SIID_MEDIAVCD = 91,

        /// <summary>DVD+R media.</summary>
        SIID_MEDIADVDPLUSR = 92,

        /// <summary>DVD+RW media.</summary>
        SIID_MEDIADVDPLUSRW = 93,

        /// <summary>A desktop computer.</summary>
        SIID_DESKTOPPC = 94,

        /// <summary>A mobile computer (laptop).</summary>
        SIID_MOBILEPC = 95,

        /// <summary>The User Accounts Control Panel item.</summary>
        SIID_USERS = 96,

        /// <summary>Smart media.</summary>
        SIID_MEDIASMARTMEDIA = 97,

        /// <summary>CompactFlash media.</summary>
        SIID_MEDIACOMPACTFLASH = 98,

        /// <summary>A cell phone.</summary>
        SIID_DEVICECELLPHONE = 99,

        /// <summary>A digital camera.</summary>
        SIID_DEVICECAMERA = 100,

        /// <summary>A digital video camera.</summary>
        SIID_DEVICEVIDEOCAMERA = 101,

        /// <summary>An audio player.</summary>
        SIID_DEVICEAUDIOPLAYER = 102,

        /// <summary>Connect to network.</summary>
        SIID_NETWORKCONNECT = 103,

        /// <summary>The Network and Internet Control Panel item.</summary>
        SIID_INTERNET = 104,

        /// <summary>A compressed file with a .zip file name extension.</summary>
        SIID_ZIPFILE = 105,

        /// <summary>The Additional Options Control Panel item.</summary>
        SIID_SETTINGS = 106,

        /// <summary>High definition DVD drive (any type - HD DVD-ROM, HD DVD-R, HD-DVD-RAM) that uses the HD DVD format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_DRIVEHDDVD = 132,

        /// <summary>High definition DVD drive (any type - BD-ROM, BD-R, BD-RE) that uses the Blu-ray Disc format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_DRIVEBD = 133,

        /// <summary>High definition DVD-ROM media in the HD DVD-ROM format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_MEDIAHDDVDROM = 134,

        /// <summary>High definition DVD-R media in the HD DVD-R format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_MEDIAHDDVDR = 135,

        /// <summary>High definition DVD-RAM media in the HD DVD-RAM format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_MEDIAHDDVDRAM = 136,

        /// <summary>High definition DVD-ROM media in the Blu-ray Disc BD-ROM format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_MEDIABDROM = 137,

        /// <summary>High definition write-once media in the Blu-ray Disc BD-R format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_MEDIABDR = 138,

        /// <summary>High definition read/write media in the Blu-ray Disc BD-RE format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_MEDIABDRE = 139,

        /// <summary>A cluster disk array.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        SIID_CLUSTEREDDRIVE = 140,

        /// <summary>The highest valid value in the enumeration.</summary>
        /// <remarks>Values over 160 are Windows 7-only icons.</remarks>
        SIID_MAX_ICONS = 175
    }

    /// <summary>
    /// Flags used with the Windows API (User32.dll):GetSystemMetrics(SystemMetric smIndex)
    ///
    /// This Enum and declaration signature was written by Gabriel T. Sharp ai_productions@verizon.net or osirisgothra@hotmail.com Obtained on pinvoke.net, please contribute your code to support the wiki!
    /// </summary>
    public enum SystemMetric
    {
        /// <summary>The flags that specify how the system arranged minimized windows. For more information, see the Remarks section in this topic.</summary>

        SM_ARRANGE = 56,

        /// <summary>
        /// The value that specifies how the system is started: 0 Normal boot 1 Fail-safe boot 2 Fail-safe with network boot A fail-safe boot (also called SafeBoot, Safe Mode, or Clean
        /// Boot) bypasses the user startup files.
        /// </summary>
        SM_CLEANBOOT = 67,

        /// <summary>The number of display monitors on a desktop. For more information, see the Remarks section in this topic.</summary>
        SM_CMONITORS = 80,

        /// <summary>The number of buttons on a mouse, or zero if no mouse is installed.</summary>
        SM_CMOUSEBUTTONS = 43,

        /// <summary>The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.</summary>
        SM_CXBORDER = 5,

        /// <summary>The width of a cursor, in pixels. The system cannot create cursors of other sizes.</summary>
        SM_CXCURSOR = 13,

        /// <summary>This value is the same as SM_CXFIXEDFRAME.</summary>
        SM_CXDLGFRAME = 7,

        /// <summary>
        /// The width of the rectangle around the location of a first click in a double-click sequence, in pixels. , The second click must occur within the rectangle that is defined by SM_CXDOUBLECLK
        /// and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. The two clicks must also occur within a specified time. To set the width of the double-click rectangle, call
        /// SystemParametersInfo with SPI_SETDOUBLECLKWIDTH.
        /// </summary>
        SM_CXDOUBLECLK = 36,

        /// <summary>
        /// The number of pixels on either side of a mouse-down point that the mouse pointer can move before a drag operation begins. This allows the user to click and release the mouse button easily
        /// without unintentionally starting a drag operation. If this value is negative, it is subtracted from the left of the mouse-down point and added to the right of it.
        /// </summary>
        SM_CXDRAG = 68,

        /// <summary>The width of a 3-D border, in pixels. This metric is the 3-D counterpart of SM_CXBORDER.</summary>
        SM_CXEDGE = 45,

        /// <summary>
        /// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is
        /// the width of the vertical border. This value is the same as SM_CXDLGFRAME.
        /// </summary>
        SM_CXFIXEDFRAME = 7,

        /// <summary>The width of the left and right edges of the focus rectangle that the DrawFocusRectdraws. This value is in pixels. Windows 2000: This value is not supported.</summary>
        SM_CXFOCUSBORDER = 83,

        /// <summary>This value is the same as SM_CXSIZEFRAME.</summary>
        SM_CXFRAME = 32,

        /// <summary>
        /// The width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen that is not obscured by the system
        /// taskbar or by application desktop toolbars, call the SystemParametersInfofunction with the SPI_GETWORKAREA value.
        /// </summary>
        SM_CXFULLSCREEN = 16,

        /// <summary>The width of the arrow bitmap on a horizontal scroll bar, in pixels.</summary>
        SM_CXHSCROLL = 21,

        /// <summary>The width of the thumb box in a horizontal scroll bar, in pixels.</summary>
        SM_CXHTHUMB = 10,

        /// <summary>The default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions that SM_CXICON and SM_CYICON specifies.</summary>
        SM_CXICON = 11,

        /// <summary>
        /// The width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater
        /// than or equal to SM_CXICON.
        /// </summary>
        SM_CXICONSPACING = 38,

        /// <summary>The default width, in pixels, of a maximized top-level window on the primary display monitor.</summary>
        SM_CXMAXIMIZED = 61,

        /// <summary>
        /// The default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger
        /// than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
        /// </summary>
        SM_CXMAXTRACK = 59,

        /// <summary>The width of the default menu check-mark bitmap, in pixels.</summary>
        SM_CXMENUCHECK = 71,

        /// <summary>The width of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.</summary>
        SM_CXMENUSIZE = 54,

        /// <summary>The minimum width of a window, in pixels.</summary>
        SM_CXMIN = 28,

        /// <summary>The width of a minimized window, in pixels.</summary>
        SM_CXMINIMIZED = 57,

        /// <summary>
        /// The width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CXMINIMIZED.
        /// </summary>
        SM_CXMINSPACING = 47,

        /// <summary>
        /// The minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the
        /// WM_GETMINMAXINFO message.
        /// </summary>
        SM_CXMINTRACK = 34,

        /// <summary>The amount of border padding for captioned windows, in pixels. Windows XP/2000: This value is not supported.</summary>
        SM_CXPADDEDBORDER = 92,

        /// <summary>The width of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).</summary>
        SM_CXSCREEN = 0,

        /// <summary>The width of a button in a window caption or title bar, in pixels.</summary>
        SM_CXSIZE = 30,

        /// <summary>
        /// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height
        /// of the vertical border. This value is the same as SM_CXFRAME.
        /// </summary>
        SM_CXSIZEFRAME = 32,

        /// <summary>The recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</summary>
        SM_CXSMICON = 49,

        /// <summary>The width of small caption buttons, in pixels.</summary>
        SM_CXSMSIZE = 52,

        /// <summary>
        /// The width of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The SM_XVIRTUALSCREEN metric is the coordinates for the left side of the
        /// virtual screen.
        /// </summary>
        SM_CXVIRTUALSCREEN = 78,

        /// <summary>The width of a vertical scroll bar, in pixels.</summary>
        SM_CXVSCROLL = 2,

        /// <summary>The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.</summary>
        SM_CYBORDER = 6,

        /// <summary>The height of a caption area, in pixels.</summary>
        SM_CYCAPTION = 4,

        /// <summary>The height of a cursor, in pixels. The system cannot create cursors of other sizes.</summary>
        SM_CYCURSOR = 14,

        /// <summary>This value is the same as SM_CYFIXEDFRAME.</summary>
        SM_CYDLGFRAME = 8,

        /// <summary>
        /// The height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by SM_CXDOUBLECLK and
        /// SM_CYDOUBLECLK for the system to consider the two clicks a double-click. The two clicks must also occur within a specified time. To set the height of the double-click rectangle, call
        /// SystemParametersInfo with SPI_SETDOUBLECLKHEIGHT.
        /// </summary>
        SM_CYDOUBLECLK = 37,

        /// <summary>
        /// The number of pixels above and below a mouse-down point that the mouse pointer can move before a drag operation begins. This allows the user to click and release the mouse button easily
        /// without unintentionally starting a drag operation. If this value is negative, it is subtracted from above the mouse-down point and added below it.
        /// </summary>
        SM_CYDRAG = 69,

        /// <summary>The height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER.</summary>
        SM_CYEDGE = 46,

        /// <summary>
        /// The thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border, and SM_CYFIXEDFRAME is
        /// the width of the vertical border. This value is the same as SM_CYDLGFRAME.
        /// </summary>
        SM_CYFIXEDFRAME = 8,

        /// <summary>The height of the top and bottom edges of the focus rectangle drawn byDrawFocusRect. This value is in pixels. Windows 2000: This value is not supported.</summary>
        SM_CYFOCUSBORDER = 84,

        /// <summary>This value is the same as SM_CYSIZEFRAME.</summary>
        SM_CYFRAME = 33,

        /// <summary>
        /// The height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or
        /// by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
        /// </summary>
        SM_CYFULLSCREEN = 17,

        /// <summary>The height of a horizontal scroll bar, in pixels.</summary>
        SM_CYHSCROLL = 3,

        /// <summary>The default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.</summary>
        SM_CYICON = 12,

        /// <summary>
        /// The height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater
        /// than or equal to SM_CYICON.
        /// </summary>
        SM_CYICONSPACING = 39,

        /// <summary>For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels.</summary>
        SM_CYKANJIWINDOW = 18,

        /// <summary>The default height, in pixels, of a maximized top-level window on the primary display monitor.</summary>
        SM_CYMAXIMIZED = 62,

        /// <summary>
        /// The default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger
        /// than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
        /// </summary>
        SM_CYMAXTRACK = 60,

        /// <summary>The height of a single-line menu bar, in pixels.</summary>
        SM_CYMENU = 15,

        /// <summary>The height of the default menu check-mark bitmap, in pixels.</summary>
        SM_CYMENUCHECK = 72,

        /// <summary>The height of menu bar buttons, such as the child window close button that is used in the multiple document interface, in pixels.</summary>
        SM_CYMENUSIZE = 55,

        /// <summary>The minimum height of a window, in pixels.</summary>
        SM_CYMIN = 29,

        /// <summary>The height of a minimized window, in pixels.</summary>
        SM_CYMINIMIZED = 58,

        /// <summary>
        /// The height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CYMINIMIZED.
        /// </summary>
        SM_CYMINSPACING = 48,

        /// <summary>
        /// The minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the
        /// WM_GETMINMAXINFO message.
        /// </summary>
        SM_CYMINTRACK = 35,

        /// <summary>The height of the screen of the primary display monitor, in pixels. This is the same value obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).</summary>
        SM_CYSCREEN = 1,

        /// <summary>The height of a button in a window caption or title bar, in pixels.</summary>
        SM_CYSIZE = 31,

        /// <summary>
        /// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height
        /// of the vertical border. This value is the same as SM_CYFRAME.
        /// </summary>
        SM_CYSIZEFRAME = 33,

        /// <summary>The height of a small caption, in pixels.</summary>
        SM_CYSMCAPTION = 51,

        /// <summary>The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.</summary>
        SM_CYSMICON = 50,

        /// <summary>The height of small caption buttons, in pixels.</summary>
        SM_CYSMSIZE = 53,

        /// <summary>
        /// The height of the virtual screen, in pixels. The virtual screen is the bounding rectangle of all display monitors. The SM_YVIRTUALSCREEN metric is the coordinates for the top of the
        /// virtual screen.
        /// </summary>
        SM_CYVIRTUALSCREEN = 79,

        /// <summary>The height of the arrow bitmap on a vertical scroll bar, in pixels.</summary>
        SM_CYVSCROLL = 20,

        /// <summary>The height of the thumb box in a vertical scroll bar, in pixels.</summary>
        SM_CYVTHUMB = 9,

        /// <summary>Nonzero if User32.dll supports DBCS; otherwise, 0.</summary>
        SM_DBCSENABLED = 42,

        /// <summary>Nonzero if the debug version of User.exe is installed; otherwise, 0.</summary>
        SM_DEBUG = 22,

        /// <summary>
        /// Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input service is started; otherwise, 0. The return value is a bitmask that specifies the
        /// type of digitizer input supported by the device. For more information, see Remarks. Windows Server 2008, Windows Vista, and Windows XP/2000: This value is not supported.
        /// </summary>
        SM_DIGITIZER = 94,

        /// <summary>
        /// Nonzero if Input Method Manager/Input Method Editor features are enabled; otherwise, 0. SM_IMMENABLED indicates whether the system is ready to use a Unicode-based IME on a Unicode
        /// application. To ensure that a language-dependent IME works, check SM_DBCSENABLED and the system ANSI code page. Otherwise the ANSI-to-Unicode conversion may not be performed correctly, or
        /// some components like fonts or registry settings may not be present.
        /// </summary>
        SM_IMMENABLED = 82,

        /// <summary>
        /// Nonzero if there are digitizers in the system; otherwise, 0. SM_MAXIMUMTOUCHES returns the aggregate maximum of the maximum number of contacts supported by every digitizer in the system.
        /// If the system has only single-touch digitizers, the return value is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts the hardware can
        /// provide. Windows Server 2008, Windows Vista, and Windows XP/2000: This value is not supported.
        /// </summary>
        SM_MAXIMUMTOUCHES = 95,

        /// <summary>Nonzero if the current operating system is the Windows XP, Media Center Edition, 0 if not.</summary>
        SM_MEDIACENTER = 87,

        /// <summary>Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; 0 if the menus are left-aligned.</summary>
        SM_MENUDROPALIGNMENT = 40,

        /// <summary>Nonzero if the system is enabled for Hebrew and Arabic languages, 0 if not.</summary>
        SM_MIDEASTENABLED = 74,

        /// <summary>
        /// Nonzero if a mouse is installed; otherwise, 0. This value is rarely zero, because of support for virtual mice and because some systems detect the presence of the port instead of the
        /// presence of a mouse.
        /// </summary>
        SM_MOUSEPRESENT = 19,

        /// <summary>Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.</summary>
        SM_MOUSEHORIZONTALWHEELPRESENT = 91,

        /// <summary>Nonzero if a mouse with a vertical scroll wheel is installed; otherwise 0.</summary>
        SM_MOUSEWHEELPRESENT = 75,

        /// <summary>The least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use.</summary>
        SM_NETWORK = 63,

        /// <summary>Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.</summary>
        SM_PENWINDOWS = 41,

        /// <summary>
        /// This system metric is used in a Terminal Services environment to determine if the current Terminal Server session is being remotely controlled. Its value is nonzero if the current session
        /// is remotely controlled; otherwise, 0. You can use terminal services management tools such as Terminal Services Manager (tsadmin.msc) and shadow.exe to control a remote session. When a
        /// session is being remotely controlled, another user can view the contents of that session and potentially interact with it.
        /// </summary>
        SM_REMOTECONTROL = 0x2001,

        /// <summary>
        /// This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services client session, the return value is nonzero. If the calling
        /// process is associated with the Terminal Services console session, the return value is 0. Windows Server 2003 and Windows XP: The console session is not necessarily the physical console.
        /// For more information, seeWTSGetActiveConsoleSessionId.
        /// </summary>
        SM_REMOTESESSION = 0x1000,

        /// <summary>
        /// Nonzero if all the display monitors have the same color format, otherwise, 0. Two displays can have the same bit depth, but different color formats. For example, the red, green, and blue
        /// pixels can be encoded with different numbers of bits, or those bits can be located in different places in a pixel color value.
        /// </summary>
        SM_SAMEDISPLAYFORMAT = 81,

        /// <summary>This system metric should be ignored; it always returns 0.</summary>
        SM_SECURE = 44,

        /// <summary>The build number if the system is Windows Server 2003 R2; otherwise, 0.</summary>
        SM_SERVERR2 = 89,

        /// <summary>
        /// Nonzero if the user requires an application to present information visually in situations where it would otherwise present the information only in audible form; otherwise, 0.
        /// </summary>
        SM_SHOWSOUNDS = 70,

        /// <summary>Nonzero if the current session is shutting down; otherwise, 0. Windows 2000: This value is not supported.</summary>
        SM_SHUTTINGDOWN = 0x2000,

        /// <summary>Nonzero if the computer has a low-end (slow) processor; otherwise, 0.</summary>
        SM_SLOWMACHINE = 73,

        /// <summary>Nonzero if the current operating system is Windows 7 Starter Edition, Windows Vista Starter, or Windows XP Starter Edition; otherwise, 0.</summary>
        SM_STARTER = 88,

        /// <summary>Nonzero if the meanings of the left and right mouse buttons are swapped; otherwise, 0.</summary>
        SM_SWAPBUTTON = 23,

        /// <summary>
        /// Nonzero if the current operating system is the Windows XP Tablet PC edition or if the current operating system is Windows Vista or Windows 7 and the Tablet PC Input service is started;
        /// otherwise, 0. The SM_DIGITIZER setting indicates the type of digitizer input supported by a device running Windows 7 or Windows Server 2008 R2. For more information, see Remarks.
        /// </summary>
        SM_TABLETPC = 86,

        /// <summary>
        /// The coordinates for the left side of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The SM_CXVIRTUALSCREEN metric is the width of the virtual screen.
        /// </summary>
        SM_XVIRTUALSCREEN = 76,

        /// <summary>
        /// The coordinates for the top of the virtual screen. The virtual screen is the bounding rectangle of all display monitors. The SM_CYVIRTUALSCREEN metric is the height of the virtual screen.
        /// </summary>
        SM_YVIRTUALSCREEN = 77,
    }

#pragma warning restore CA1712
#pragma warning restore CA1008
#pragma warning restore CA1707
#pragma warning restore CA1069
#pragma warning restore CA1028

    #endregion Enums

    #region Structures

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHSTOCKICONINFO : IEquatable<SHSTOCKICONINFO>
    {
#pragma warning disable CA1051

        public uint cbSize;
        public IntPtr hIcon;
        public int iSysIconIndex;
        public int iIcon;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]// 260 is MAX_PATH
        public string szPath;

#pragma warning restore CA1051

        public override bool Equals(object obj) => obj is SHSTOCKICONINFO sHSTOCKICONINFO && Equals(sHSTOCKICONINFO);

        public bool Equals(SHSTOCKICONINFO other) => cbSize == other.cbSize && hIcon.Equals(other.hIcon) && iSysIconIndex == other.iSysIconIndex && iIcon == other.iIcon && szPath == other.szPath;

        public override int GetHashCode() => HashCode.Combine(cbSize, hIcon, iSysIconIndex, iIcon, szPath);

        public static bool operator ==(SHSTOCKICONINFO left, SHSTOCKICONINFO right) => left.Equals(right);

        public static bool operator !=(SHSTOCKICONINFO left, SHSTOCKICONINFO right) => !(left == right);
    }

    #endregion Structures

    internal static class NativeMethods
    {
        #region Public Methods

        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern uint SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>Enables support for non-standard DPI displays.</summary>
        /// <returns><see langword="true"/> if the call succeeded, <see langword="false"/> if it didn't.</returns>
        [DllImport("user32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern bool SetProcessDPIAware();

        [DllImport("Shell32.dll", SetLastError = false)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern int SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        #endregion Public Methods
    }
}

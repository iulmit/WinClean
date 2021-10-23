// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license.

namespace RaphaëlBardini.WinClean.Logic
{
    /// <summary>Identifies a known system shell icon.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1027", Justification = "Values are not supposed to be combined")]
    public enum ShellIcon
    {
        /// <summary>Document of a type with no associated application.</summary>
        DocNoAssoc = 0,

        /// <summary>Document of a type with an associated application.</summary>
        DocAssoc = 1,

        /// <summary>Generic application with no custom icon.</summary>
        Application = 2,

        /// <summary>Folder (generic, unspecified state).</summary>
        Folder = 3,

        /// <summary>Folder (open).</summary>
        FolderOpen = 4,

        /// <summary>5.25-inch disk drive.</summary>
        Drive525 = 5,

        /// <summary>3.5-inch disk drive.</summary>
        Drive35 = 6,

        /// <summary>Removable drive.</summary>
        DriveRemovable = 7,

        /// <summary>Fixed drive (hard disk).</summary>
        DriveFixed = 8,

        /// <summary>Network drive (connected).</summary>
        DriveNetwork = 9,

        /// <summary>Network drive (disconnected).</summary>
        DriveNeworkDisconnected = 10,

        /// <summary>CD drive.</summary>
        DriveCD = 11,

        /// <summary>RAM disk drive.</summary>
        DriveRAM = 12,

        /// <summary>Planet Earth.</summary>
        World = 13,

        /// <summary>Planet Earth with a mouse plugged into it.</summary>
        WorldMouse = 14,

        /// <summary>A computer on the network.</summary>
        Server = 15,

        /// <summary>A local printer or print destination.</summary>
        Printer = 16,

        /// <summary>The Network virtual folder (FOLDERID_NetworkFolder/CSIDL_NETWORK).</summary>
        MyNetwork = 17,

        /// <summary>3 linked computers.</summary>
        Network = 18,

        /// <summary>A folder with 9 small icons.</summary>
        FolderSmallIcons = 19,

        /// <summary>Document of a type with no associated application with a clock overlay.</summary>
        DocNoAssocClock = 20,

        /// <summary>Control Panel icon</summary>
        ControlPanel = 21,

        /// <summary>The Search feature.</summary>
        Find = 22,

        /// <summary>The Help and Support feature.</summary>
        Help = 23,

        /// <summary>The Run.. program icon</summary>
        Run = 24,

        /// <summary>A monitor with a moon displayed.</summary>
        ComputerMoon = 25,

        /// <summary>An USB key with an arrow pointing to the right.</summary>
        UsbArrow = 26,

        /// <summary>The Windows XP shutdown icon.</summary>
        ShutdownXp = 27,

        /// <summary>Overlay for a shared item.</summary>
        Share = 28,

        /// <summary>Overlay for a shortcut.</summary>
        Link = 29,

        /// <summary>Overlay for items that are expected to be slow to access.</summary>
        SlowFIleOverlay = 30,

        /// <summary>The Recycle Bin (empty).</summary>
        RecycleBin = 31,

        /// <summary>The Recycle Bin (not empty).</summary>
        RecycleBinFull = 32,

        /// <summary>The server icon for Windows 9x.</summary>
        Server9x = 33,

        /// <summary>The user's desktop.</summary>
        Desktop = 34,

        /// <summary>A printer with a folder behind it.</summary>
        PrinterFolder = 37,

        /// <summary>The fonts folder icon.</summary>
        FontsFolder = 38,

        /// <summary>3 checkboxes and a toolbar at the bottom.</summary>
        CheckBoxes = 39,

        /// <summary>Audio CD media.</summary>
        MediaCDAudio = 40,

        /// <summary>A Windows 9x tree.</summary>
        Tree9x = 41,

        /// <summary>A Windows 9x computer in front of a folder.</summary>
        ComputerFolder9x = 42,

        /// <summary>A star.</summary>
        Favourite = 43,

        /// <summary>The Windows XP sleep icon.</summary>
        SleepXP = 44,

        /// <summary>A folder with a green arrow pointing upwards.</summary>
        UploadFolder = 45,

        /// <summary>A screen with 2 arrows in a circle.</summary>
        ScreenArrows = 46,

        /// <summary>Security lock.</summary>
        Lock = 47,

        /// <summary>A Windows 9x computer with a program window behind.</summary>
        ComputerProgram9x = 48,

        /// <summary>A virtual folder that contains the results of a search.</summary>
        AutoList = 49,

        /// <summary>A network printer.</summary>
        PrinterNetwork = 50,

        /// <summary>A server shared on a network.</summary>
        ServerShare = 51,

        /// <summary>A local fax printer.</summary>
        PrinterFax = 52,

        /// <summary>A network fax printer.</summary>
        PrinterNetworkFax = 53,

        /// <summary>A file that receives the output of a Print to file operation.</summary>
        PrinterFile = 54,

        /// <summary>A category that results from a Stack by command to organize the contents of a folder.</summary>
        Stack = 55,

        /// <summary>Super Video CD (SVCD) media.</summary>
        MediaSVCD = 56,

        /// <summary>A folder that contains only subfolders as child items.</summary>
        StuffedFolder = 57,

        /// <summary>Unknown drive type.</summary>
        DriveUnknwown = 58,

        /// <summary>DVD drive.</summary>
        DriveDvd = 59,

        /// <summary>DVD media.</summary>
        MediaDvd = 60,

        /// <summary>DVD-RAM media.</summary>
        MediaDvdRam = 61,

        /// <summary>DVD-RW media.</summary>
        MediaDvdRw = 62,

        /// <summary>DVD-R media.</summary>
        MediaDvdR = 63,

        /// <summary>DVD-ROM media.</summary>
        MediaDvdRom = 64,

        /// <summary>CD+ (enhanced audio CD) media.</summary>
        MediaCdAudioPlus = 65,

        /// <summary>CD-RW media.</summary>
        MediaCdRw = 66,

        /// <summary>CD-R media.</summary>
        MediaCdR = 67,

        /// <summary>A writable CD in the process of being burned.</summary>
        MediaCdBurn = 68,

        /// <summary>Blank writable CD media.</summary>
        MediaBlankCd = 69,

        /// <summary>CD-ROM media.</summary>
        MediaCdRom = 70,

        /// <summary>An audio file.</summary>
        AudioFile = 71,

        /// <summary>An image file.</summary>
        ImageFile = 72,

        /// <summary>A video file.</summary>
        VideoFile = 73,

        /// <summary>A mixed file.</summary>
        MixedFile = 74,

        /// <summary>Folder back.</summary>
        FolderBack = 75,

        /// <summary>Folder front.</summary>
        FolderFront = 76,

        /// <summary>Security shield. Use for UAC prompts only.</summary>
        Shield = 77,

        /// <summary>Warning.</summary>
        Warning = 78,

        /// <summary>Informational.</summary>
        Info = 79,

        /// <summary>Error.</summary>
        Error = 80,

        /// <summary>Key.</summary>
        Key = 81,

        /// <summary>Software.</summary>
        Software = 82,

        /// <summary>A UI item, such as a button, that issues a rename command.</summary>
        Rename = 83,

        /// <summary>A UI item, such as a button, that issues a delete command.</summary>
        Delete = 84,

        /// <summary>Audio DVD media.</summary>
        MediaAudioDvd = 85,

        /// <summary>Movie DVD media.</summary>
        MediaMovieDvd = 86,

        /// <summary>Enhanced CD media.</summary>
        MediaEnhancedCD = 87,

        /// <summary>Enhanced DVD media.</summary>
        MediaEnhancedDVD = 88,

        /// <summary>High definition DVD media in the HD DVD format.</summary>
        MediaHdDvd = 89,

        /// <summary>High definition DVD media in the Blu-ray Disc™ format.</summary>
        MediaBluRay = 90,

        /// <summary>Video CD (VCD) media.</summary>
        MediaVcd = 91,

        /// <summary>DVD+R media.</summary>
        MediaDvdPlusR = 92,

        /// <summary>DVD+RW media.</summary>
        MediaDvdPlusRw = 93,

        /// <summary>A desktop computer.</summary>
        DesktopPc = 94,

        /// <summary>A mobile computer (laptop).</summary>
        MobilePc = 95,

        /// <summary>The User Accounts Control Panel item.</summary>
        Users = 96,

        /// <summary>Smart media.</summary>
        MediaSmart = 97,

        /// <summary>CompactFlash media.</summary>
        MediaCompactFlash = 98,

        /// <summary>A cell phone.</summary>
        DeviceCellPhone = 99,

        /// <summary>A digital camera.</summary>
        DeviceCamera = 100,

        /// <summary>A digital video camera.</summary>
        DeviceVideoCamera = 101,

        /// <summary>An audio player.</summary>
        DeviceAudioPlayer = 102,

        /// <summary>Connect to network.</summary>
        NetworkConnect = 103,

        /// <summary>The Network and Internet Control Panel item.</summary>
        Internet = 104,

        /// <summary>A compressed file with a .zip file name extension.</summary>
        ZipFile = 105,

        /// <summary>The Additional Options Control Panel item.</summary>
        Settings = 106,

        /// <summary>The current system drive (for instance, C:) with the Windows icon.</summary>
        SystemDrive = 107,

        /// <summary>The music user library</summary>
        MusicLibrary = 109,

        /// <summary>The saved pictures folder</summary>
        SavedPicturesFolder = 110,

        /// <summary>A folder with a magnifying glass</summary>
        FolderFind = 112,

        /// <summary>A printer with a green +</summary>
        AddPrinter = 113,

        /// <summary>A Windows 9x tree view</summary>
        TreeView9x = 114,

        /// <summary>A white canvas for painting.</summary>
        Canvas = 116,

        /// <summary>A printer with a green validation mark.</summary>
        OkPrinter = 117,

        /// <summary>A printer with a green validation mark and a floppy disk.</summary>
        OkPrinterFloppyDisk = 118,

        /// <summary>A network printer with a green validation mark.</summary>
        OkNetworkPrinter = 119,

        /// <summary>A scanner with a green validation mark.</summary>
        OkScanner = 120,

        /// <summary>A photocopier with a green validation mark.</summary>
        OkPhotocopier = 121,

        /// <summary>A text document with a red margin.</summary>
        TextDocumentMargin = 122,

        /// <summary>A mail enveloppe with a timbre.</summary>
        Letter = 123,

        /// <summary>The paysage picture icon in a window.</summary>
        ImageInWindow = 124,

        /// <summary>A music sheet.</summary>
        MusicSheet = 125,

        /// <summary>The user videos library.</summary>
        VideosLibrary = 126,

        /// <summary>2 people.</summary>
        Contacts = 127,

        /// <summary>Help in a shield.</summary>
        ShieldHelp = 128,

        /// <summary>Error in a shield.</summary>
        ShieldError = 129,

        /// <summary>Checkmark in a shield.</summary>
        ShieldChekmark = 130,

        /// <summary>Warning in a shield.</summary>
        SheildWarning = 131,

        /// <summary>High definition DVD drive (any type - HD DVD-ROM, HD DVD-R, HD-DVD-RAM) that uses the HD DVD format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        DriveHdDvd = 132,

        /// <summary>High definition DVD drive (any type - BD-ROM, BD-R, BD-RE) that uses the Blu-ray Disc format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        DriveBd = 133,

        /// <summary>High definition DVD-ROM media in the HD DVD-ROM format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        MediaHdDvdRom = 134,

        /// <summary>High definition DVD-R media in the HD DVD-R format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        MediaHdDvdR = 135,

        /// <summary>High definition DVD-RAM media in the HD DVD-RAM format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        MediaHdDvdRam = 136,

        /// <summary>High definition DVD-ROM media in the Blu-ray Disc BD-ROM format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        MediaBdRom = 137,

        /// <summary>High definition write-once media in the Blu-ray Disc BD-R format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        MediaBdR = 138,

        /// <summary>High definition read/write media in the Blu-ray Disc BD-RE format.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        MediaBdRe = 139,

        /// <summary>A cluster disk array.</summary>
        /// <remarks>Windows Vista with SP1 and later.</remarks>
        ClusteredDrive = 140,

        /// <summary>The highest valid value in the enumeration.</summary>
        /// <remarks>Values over 160 are Windows 7-only icons.</remarks>
        Max = 175,

        /// <summary>The music library icon in a box.</summary>
        MusicBox = 163,

        /// <summary>An unlocked drive that can be locked.</summary>
        UnlockedDrive = 164,

        /// <summary>A locked drive that can be unlocked.</summary>
        LockedDrive = 165,

        /// <summary>An unlocked drive that can be locked, with a warning icon.</summary>
        UnlockedDriveWarning = 166,

        /// <summary>The system drive with the Windows icon, unlocked.</summary>
        UnlockedSystemDrive = 167,

        /// <summary>The system drive with the Windows icon, unlocked with a warning.</summary>
        UnlockedSystemDriveWarning = 168,

        /// <summary>A locked drive with a key inside the lock.</summary>
        LockedDriveKey = 170,

        /// <summary>A library with no file type association.</summary>
        UnspecifiedLibrary = 172,

        /// <summary>A green validation mark.</summary>
        CheckmarkOverlay = 173,

        /// <summary>A white on black play button.</summary>
        Play = 174,

        /// <summary>A lock seen from the front.</summary>
        FlatLock = 178,

        /// <summary>A compressed object.</summary>
        Compressed = 179,

        /// <summary>A briefcase seen from the front.</summary>
        /// <remarks>Maximum value.</remarks>
        Briefcase = 180,
    }

#pragma warning restore CA1720
#pragma warning restore CA1069
#pragma warning restore CA1712
#pragma warning restore CA1707
#pragma warning restore CA1008
#pragma warning restore CA1028
}

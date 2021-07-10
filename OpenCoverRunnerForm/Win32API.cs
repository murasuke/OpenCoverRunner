using System;
using System.IO;
using System.Runtime.InteropServices;


namespace OpenCoverRunnerForm
{
    /**
     * exe,dllにpdbファイルのパスが埋め込まれている場合はそれを返す
     * (IMAGE_DIRECTORY_ENTRY_DEBUG)
     */
    class Win32API
    {
        public const ushort IMAGE_DIRECTORY_ENTRY_DEBUG = 6;   // Debug Directory

        public enum ImageDebugType : uint
        {
            Unknown = 0,
            Coff = 1,

            /// <summary>
            /// Contains PDB info
            /// </summary>
            CodeView = 2,

            FPO = 3,
            Misc = 4,
            Exception = 5,
            Fixup = 6,
            OmapToSrc = 7,
            OmapFromSrc = 8,
            Borland = 9,
            Reserved10 = 10,
            CLSID = 11,
            VcFeature = 12,
            POGO = 13,
            ILTCG = 14,
            MPX = 15,

            /// <summary>
            /// It's a deterministic (reproducible) PE file
            /// </summary>
            Reproducible = 16,

            /// <summary>
            /// Embedded portable PDB data
            /// </summary>
            EmbeddedPortablePdb = 17,

            /// <summary>
            /// Checksum of the PDB file. 0 or more entries allowed.
            /// </summary>
            PdbChecksum = 19,
        }

        [Flags]
        public enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }

        [Flags]
        public enum FileMapAccess : uint
        {
            FileMapCopy = 0x0001,
            FileMapWrite = 0x0002,
            FileMapRead = 0x0004,
            FileMapAllAccess = 0x001f,
            fileMapExecute = 0x0020,
        }

        public struct IMAGE_DEBUG_DIRECTORY
        {
            public uint Characteristics;
            public uint TimeDateStamp;
            public ushort MajorVersion;
            public ushort MinorVersion;
            public ImageDebugType Type;
            public uint SizeOfData;
            public uint AddressOfRawData;
            public uint PointerToRawData;
        }


        struct RSDS_DEBUG_FORMAT
        {
            public uint signature;
            public Guid guid;
            public uint age;
            //public string pdbpath;
        };



        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateFile(
            [MarshalAs(UnmanagedType.LPTStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes, // optional SECURITY_ATTRIBUTES struct or IntPtr.Zero
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping(
            IntPtr hFile,
            IntPtr lpFileMappingAttributes,
            FileMapProtection flProtect,
            uint dwMaximumSizeHigh,
            uint dwMaximumSizeLow,
            [MarshalAs(UnmanagedType.LPStr)] string lpName);

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr MapViewOfFile(
            IntPtr hFileMapping, 
            FileMapAccess dwDesiredAccess, 
            uint dwFileOffsetHigh, 
            uint dwFileOffsetLow, 
            uint dwNumberOfBytesToMap);

        [DllImport("dbghelp.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ImageDirectoryEntryToDataEx(
            IntPtr Base, 
            Byte MappedAsImage, 
            ushort DirectoryEntry,
            out ulong Size, 
            out IntPtr FoundHeader);



        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        public static string GetModuleEmbeddedPdbPath(string filePath)
        {
            var hFile = CreateFile(filePath, FileAccess.Read, FileShare.Read, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
            if (hFile.ToInt32() == -1)
            {
                return "";
            }
            var hFileMapping = CreateFileMapping(hFile, IntPtr.Zero, FileMapProtection.PageReadonly, 0, 0, "");
            var pvBase = MapViewOfFile(hFileMapping, FileMapAccess.FileMapRead, 0, 0, 0);

            try
            {
                IntPtr imgSecHeader;
                ulong dirEntrySize;
                var pDbgDir = ImageDirectoryEntryToDataEx(pvBase, 0,IMAGE_DIRECTORY_ENTRY_DEBUG , out dirEntrySize, out imgSecHeader);

                var dbgDir = Marshal.PtrToStructure<IMAGE_DEBUG_DIRECTORY>(pDbgDir);


                if (ImageDebugType.CodeView == dbgDir.Type)
                {
                    var rsdsPtr = pvBase + (int)dbgDir.PointerToRawData;
                    var pdgFormat = Marshal.PtrToStructure<RSDS_DEBUG_FORMAT>(pvBase + (int)dbgDir.PointerToRawData); 
                    if (pdgFormat.signature == 0x53445352/*"RSDS"*/ )
                    {
                        //RSDSシグネチャが見つかれば、pdfが含まれるので出力する
                        var pathPtr = new IntPtr(rsdsPtr.ToInt64() + Marshal.SizeOf(typeof(RSDS_DEBUG_FORMAT)));
                        var path = Marshal.PtrToStringAnsi(pathPtr);
                        return path;
                    }
                }
            }
            finally
            {
                UnmapViewOfFile(pvBase);
                CloseHandle(hFileMapping);
                CloseHandle(hFile);
            }
            return "";
        }
    }
}

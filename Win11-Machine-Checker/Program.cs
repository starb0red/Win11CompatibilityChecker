using System;
using System.Management;

namespace Win11_Machine_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            var gcMemoryInfo = GC.GetGCMemoryInfo();
            var installedMemory = gcMemoryInfo.TotalAvailableMemoryBytes; //Gets total RAM 
            var physicalMemory = (double)installedMemory / 1048576.0; //Converts total RAM into megabytes
            if (physicalMemory <= 4000) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("[-] Insufficent Ram. Ram Must Be Over 4 GB / 4000 MB. Your Total Ram: " + physicalMemory + "MB" ); count++; }
            else { Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("[+] Sufficent Ram. Ram Must Be Over 4 GB / 4000 MB. Your Total Ram: " + physicalMemory + " MB"); }


            System.IO.DriveInfo info = new System.IO.DriveInfo("C:/"); //Gets the total size of drive C
            if (info.TotalSize <= 64000000000){ Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("[-] Insufficent Disk Size. Disk Size Must Be Over 64 GB / 64,000 MB. Your Total Diskspace On Drive C: " + info.TotalSize + "B"); count++; }
            else { Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("[+] Sufficent Disk Size. Storage Must Be Over 64 GB / 64,000 MB. Your Total Diskspace On Drive C: " + info.TotalSize + "B");  }

            var cores = Environment.ProcessorCount; //Gets amount of cores.
            if (cores <= 2) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine("[-] Insufficent Number Of Cores. You Must Have More Than 2 Cores. Your Total Amount Of Cores: " + cores); count++; }
            else { Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("[+] Sufficent Number Of Cores. You Must Have More Than 2 Cores. Your Total Amount Of Cores: " + cores);  }
            if (count >= 1)
            {
                Console.WriteLine("\nYour Are Not Able To Get Windows 11.");
            }
            else
            {
                Console.WriteLine("\nYou Can Get Windows 11");
            }
            Console.ReadKey();

        }
    }
}

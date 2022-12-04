using System.Diagnostics;
using System.Management;

namespace DeskCopilot
{
    internal class CopilotValue
    {
        public static float GetCpuUsage() => new PerformanceCounter("Processor", "% Processor Time", "_Total").NextValue();

        public static float GetMemoryUsage()
        {
            ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject managementObject in managementClass.GetInstances().Cast<ManagementObject>())
                return (float)(decimal.Parse((string)managementObject["TotalVisibleMemorySize"]) / decimal.Parse((string)managementObject["FreePhysicalMemory"]));
            return 0;
        }
    }
}

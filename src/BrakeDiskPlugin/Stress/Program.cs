using System;
using System.Diagnostics;
using System.IO;
using BrakeDiskPlugin.Model;
using BrakeDiskPlugin.Wrapper;
using NickStrupat;

var builder = new Builder();
var stopWatch = new Stopwatch();
var brakeDisk = new BrakeDisk();
var streamWriter = new StreamWriter("log.txt", true);
Process currentProcess = Process.GetCurrentProcess();
var count = 0;

while (true)
{
    const double gigabyteInByte = 0.000000000931322574615478515625;
    stopWatch.Restart(); // Use Restart instead of Start
    builder.BuildBrakeDisk(brakeDisk);
    stopWatch.Stop();

    var computerInfo = new ComputerInfo();
    var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) * gigabyteInByte;

    streamWriter.WriteLine($"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
    streamWriter.Flush();
}

// The following lines will not be reached in an infinite loop
// streamWriter.Close();
// streamWriter.Dispose();
// Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
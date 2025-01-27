using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using KettlePlugin;
using NickStrupat;

namespace StressTests
{
    /// <summary>
    /// Класс нагрузочного тестирования для проекта KettlePlugin.
    /// </summary>
    public class StressTester
    {
        /// <summary>
        /// Метод для проведения нагрузочного тестирования.
        /// </summary>
        public void StressTesting()
        {
            // Создаем необходимые объекты
            var parameters = new Parameters
            {
                AllParameters = new Dictionary<ParameterType, Parameter>
                {
                    { ParameterType.Volume, new Parameter ( 0.63, 56.55, 0.63) },
                    { ParameterType.HeightBase, new Parameter ( 80, 450, 80 ) },
                    { ParameterType.DiameterLid, new Parameter ( 75, 300, 75 ) },
                    { ParameterType.HeightHandle, new Parameter ( 70, 150, 70 ) },
                    { ParameterType.DiameterBottom, new Parameter ( 100, 400, 100 ) },
                }
            };

            var builder = new Builder();
            var stopWatch = new Stopwatch();

            Process currentProcess = Process.GetCurrentProcess();
            var count = 0;
            var streamWriter = new StreamWriter("log.txt");
            const double gigabyteInByte = 0.000000000931322574615478515625;

            while (true)
            {
                stopWatch.Start();
                builder.Build(parameters, 000000, 0);
                stopWatch.Stop();

                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;

                streamWriter.WriteLine($"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory:F2}");
                streamWriter.Flush();
                stopWatch.Reset();
            }
        }
    }
}

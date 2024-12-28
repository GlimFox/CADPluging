using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using KettlePlugin;

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
                    { ParameterType.Volume, new Parameter { MinValue = 0.63, MaxValue = 56.55, Value = 0.63 } },
                    { ParameterType.HeightBase, new Parameter { MinValue = 80, MaxValue = 450, Value = 80 } },
                    { ParameterType.DiameterLid, new Parameter { MinValue = 75, MaxValue = 300, Value = 100 } },
                    { ParameterType.HeightHandle, new Parameter { MinValue = 70, MaxValue = 150, Value = 120 } },
                    //{ ParameterType.DiameterBottom, new Parameter { MinValue = 100, MaxValue = 400, Value = 100 } },
                }
            };

            var stopWatch = new Stopwatch();
            Process currentProcess = Process.GetCurrentProcess();
            var count = 0;
            var logFilePath = "stress_test_log.txt";
            var streamWriter = new StreamWriter(logFilePath);

            const double gigabyteInByte = 0.000000000931322574615478515625;

            Console.WriteLine("Начало стресс-тестирования. Лог записывается в файл: " + logFilePath);

            while (true)
            {
                try
                {
                    // Запуск таймера
                    stopWatch.Start();

                    // Выполняем целевые действия (вызов метода SetParameter)
                    parameters.SetParameter(ParameterType.DiameterBottom,
                        new Parameter { MinValue = 100, MaxValue = 400, Value = 200 });

                    // Останавливаем таймер
                    stopWatch.Stop();

                    // Рассчитываем используемую память
                    var usedMemory = (currentProcess.WorkingSet64 * gigabyteInByte);

                    // Логируем результаты
                    streamWriter.WriteLine($"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory:F2} ГБ");
                    streamWriter.Flush();

                    // Выводим результаты в консоль для отслеживания
                    Console.WriteLine($"Итерация: {count}, Время выполнения: {stopWatch.Elapsed}, Используемая память: {usedMemory:F2} ГБ");

                    // Сбрасываем таймер
                    stopWatch.Reset();
                }
                catch (Exception ex)
                {
                    // Логируем ошибку и продолжаем
                    streamWriter.WriteLine($"Ошибка на итерации {count}: {ex.Message}");
                    Console.WriteLine($"Ошибка на итерации {count}: {ex.Message}");
                }
            }
        }
    }
}

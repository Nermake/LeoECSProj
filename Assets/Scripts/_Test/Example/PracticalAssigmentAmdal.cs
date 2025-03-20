using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace _Test.Example
{
    public class PracticalAssigmentAmdal : MonoBehaviour
    {
        private const int Size = 100_000_000;
        private readonly int[] _arr = new int[Size];

        private Stopwatch _stopwatch;
        private long _total;
        private long _sequentialTime;
        private double _proportionParallelPart;
        
        private string _message;
        
        private void Start()
        {
            InitArray();

            // Последовательное вычисление
            ConsistentExecution();

            // Параллельное вычисление для разного количества потоков
            int[] threadCounts = { 2, 4, 8 };
            SequentialExecution(threadCounts);
            
            Debug.Log(_message);
        }

        /// <summary>
        /// Последовательное вычисление
        /// </summary>
        private void ConsistentExecution()
        {
            _stopwatch = Stopwatch.StartNew();
            _stopwatch.Start();
            _total = SequentialSum();
            SequentialProcessing();
            _stopwatch.Stop();
            
            _sequentialTime = _stopwatch.ElapsedMilliseconds;
            
            _message += $"Последовательное выполнение: {_sequentialTime} мс \n";
            
            // Измеряем время только параллельной части при N=1 (последовательное выполнение)
            _stopwatch.Restart();
            _total = ParallelSum(1);
            _stopwatch.Stop();
            
            var parallelPartTime = _stopwatch.ElapsedMilliseconds;

            // Рассчитываем долю параллельной части (P)
            _proportionParallelPart = (double)parallelPartTime / _sequentialTime;

            _message += $"Доля параллельной части (P): {_proportionParallelPart:F2} \n \n";
        }
        
        /// <summary>
        /// Параллельное вычисление для разного количества потоков
        /// </summary>
        /// <param name="threadCounts">массив с количеством потоков</param>
        private void SequentialExecution(int[] threadCounts)
        {
            foreach (int numThreads in threadCounts)
            {
                _stopwatch.Restart();
                _total = ParallelSum(numThreads);
                SequentialProcessing();
                _stopwatch.Stop();
                var parallelTime = _stopwatch.ElapsedMilliseconds;

                var realSpeedup = (double)_sequentialTime / parallelTime;

                var theoreticalSpeedupAmdal = 1 / ((1 - _proportionParallelPart) + (_proportionParallelPart / numThreads));

                _message += $"Параллельное выполнение ({numThreads} потоков): {parallelTime} мс \n";
                _message += $"Реальное ускорение: {realSpeedup:F2} \n";
                _message += $"Теоретическое ускорение (Амдал): {theoreticalSpeedupAmdal:F2} \n \n";
            }
        }
        
        /// <summary>
        /// Заполнение массива случайными числами от 1 до 10
        /// </summary>
        private void InitArray()
        {
            for (int i = 0; i < Size; i++)
            {
                _arr[i] = Random.Range(1, 11);
            }
        }

        /// <summary>
        /// Последовательное накопление суммы
        /// </summary>
        /// <returns>итоговая сумма</returns>
        private long SequentialSum()
        {
            long total = 0;
            for (int i = 0; i < Size; i++)
            {
                total += _arr[i];
            }

            return total;
        }

        /// <summary>
        /// Функция последовательной обработки (имитация непараллезуемой задачи)
        /// </summary>
        private void SequentialProcessing()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _arr[j] *= 2;
                }
            }
        }

        /// <summary>
        /// Паралельное вычисление суммы элементов массива
        /// </summary>
        /// <param name="numThreads">количество потоков</param>
        /// <returns>итоговая сумма</returns>
        private long ParallelSum(int numThreads)
        {
            long total = 0;
            var chunkSize = Size / numThreads;
            var tasks = new Task<long>[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                int start = i * chunkSize;
                int end = (i == numThreads - 1) ? Size : (i + 1) * chunkSize;
                tasks[i] = Task.Run(() =>
                {
                    long sum = 0;
                    for (int j = start; j < end; j++)
                    {
                        sum += _arr[j];
                    }

                    return sum;
                });
            }

            Task.WaitAll(tasks);
            total = tasks.Sum(t => t.Result);
            return total;
        }
    }
}
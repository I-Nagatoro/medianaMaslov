using System;
using System.Collections.Generic;

public class MedianFinder
{
    private PriorityQueue<int, int> maxHeap; // для меньшей половины чисел (макс-куча)
    private PriorityQueue<int, int> minHeap; // для большей половины чисел (мин-куча)

    public MedianFinder()
    {
        maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        minHeap = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        if (maxHeap.Count == 0 || num <= maxHeap.Peek())
        {
            maxHeap.Enqueue(num, num);
        }
        else
        {
            minHeap.Enqueue(num, num);
        }

        if (maxHeap.Count > minHeap.Count + 1)
        {
            minHeap.Enqueue(maxHeap.Dequeue(), maxHeap.Peek());
        }
        else if (minHeap.Count > maxHeap.Count)
        {
            maxHeap.Enqueue(minHeap.Dequeue(), minHeap.Peek());
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
        {
            return maxHeap.Peek();
        }
        else
        {
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
    }
    static void Main()
    {
        MedianFinder medianFinder = new MedianFinder();

        Console.WriteLine("Введите числа для расчета медианы. Введите 'exit' для завершения.");

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            if (int.TryParse(input, out int num))
            {
                medianFinder.AddNum(num);
                Console.WriteLine($"Медиана: {medianFinder.FindMedian()}");
            }
            else
            {
                Console.WriteLine("Введите целое число.");
            }
        }
    }
}
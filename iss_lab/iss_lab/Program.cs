using System.Numerics;

namespace iss_lab
{

    interface SortingAlgorithm<T>
        where T : IComparable<T>
    {
        void sortArray(IList<T> arrayToBeSorted, int lengthOfArray);
    }

    class MergeSort<T> : SortingAlgorithm<T>
        where T : IComparable<T>
    {

        // Merges two subarrays of []arrayToBeSorted.
        // First subarray is arrayToBeSorted[indexOfLeftBound..indexOfMiddleElement]
        // Second subarray is arrayToBeSorted[indexOfMiddleElement+1..indexOfRightBound]
        // Parameters:
        //ArrayToBeSorted: The array to be sorted.
        //indexOfLeftBound: The index of the leftmost element of the subarray.
        //indexOfMiddleElement: The index of the middle element of the subarray.
        //indexOfRightBound: The index of the rightmost element of the subarray.
        static void merge(IList<T> arrayToBeSorted, int indexOfLeftBound, int indexOfMiddleElement, int indexOfRightBound)
        {
            // Find sizes of two
            // subarrays to be merged
            int lengthOfLeftSubArray = indexOfMiddleElement - indexOfLeftBound + 1;
            int lengthOfRightSubArray = indexOfRightBound - indexOfMiddleElement;

            // Create temp arrays
            List<T> leftSubArray = new List<T>(lengthOfLeftSubArray);
            List<T> rightSubArray = new List<T>(lengthOfRightSubArray);
            int indexOfLeftSubArray, indexOfRightSubArray;

            // Copy data to temp arrays
            for (indexOfLeftSubArray = 0; indexOfLeftSubArray < lengthOfLeftSubArray; indexOfLeftSubArray++)
            {
                leftSubArray.Add(arrayToBeSorted[indexOfLeftBound + indexOfLeftSubArray]);
            }
            for (indexOfRightSubArray = 0; indexOfRightSubArray < lengthOfRightSubArray; indexOfRightSubArray++)
                rightSubArray.Add(arrayToBeSorted[indexOfMiddleElement + 1 + indexOfRightSubArray]);

            // Merge the temp arrays

            // Initial indexes of left
            // and right subarrays
            indexOfLeftSubArray = 0;
            indexOfRightSubArray = 0;

            // Initial index of merged
            // subarray array
            int indexOfMergedArray = indexOfLeftBound;
            while (indexOfLeftSubArray < lengthOfLeftSubArray && indexOfRightSubArray < lengthOfRightSubArray)
            {
                if (leftSubArray[indexOfLeftSubArray].CompareTo(rightSubArray[indexOfRightSubArray]) <= 0)
                {
                    arrayToBeSorted[indexOfMergedArray] = leftSubArray[indexOfLeftSubArray];
                    indexOfLeftSubArray++;
                }
                else
                {
                    arrayToBeSorted[indexOfMergedArray] = rightSubArray[indexOfRightSubArray];
                    indexOfRightSubArray++;
                }
                indexOfMergedArray++;
            }

            // Copy remaining elements
            // of leftSubArray[] if any
            while (indexOfLeftSubArray < lengthOfLeftSubArray)
            {
                arrayToBeSorted[indexOfMergedArray] = leftSubArray[indexOfLeftSubArray];
                indexOfLeftSubArray++;
                indexOfMergedArray++;
            }

            // Copy remaining elements
            // of rightSubArray[] if any
            while (indexOfRightSubArray < lengthOfRightSubArray)
            {
                arrayToBeSorted[indexOfMergedArray] = rightSubArray[indexOfRightSubArray];
                indexOfRightSubArray++;
                indexOfMergedArray++;
            }
        }

        // Main function that
        // sorts ArrayToBeSorted[indexOfLeftBound..indexOfRightBound] using
        // merge()
        // Parameters:
        //ArrayToBeSorted: The array to be sorted.
        //indexOfLeftBound: The index of the leftmost element of the array.
        //indexOfRightBound: The index of the rightmost element of the array.
        void mergeSort(IList<T> ArrayToBeSorted, int indexOfLeftBound, int indexOfRightBound)
        {
            if (indexOfLeftBound < indexOfRightBound)
            {

                // Find the middle point
                int indexOfMiddleElement = indexOfLeftBound + (indexOfRightBound - indexOfLeftBound) / 2;

                // Sort first and second halves
                mergeSort(ArrayToBeSorted, indexOfLeftBound, indexOfMiddleElement);
                mergeSort(ArrayToBeSorted, indexOfMiddleElement + 1, indexOfRightBound);

                // Merge the sorted halves
                merge(ArrayToBeSorted, indexOfLeftBound, indexOfMiddleElement, indexOfRightBound);
            }
            return;
        }

        public void sortArray(IList<T> ArrayToBeSorted, int lengthOfArray)
        {
            mergeSort(ArrayToBeSorted, 0, lengthOfArray - 1);
        }
    }


    class BubbleSort<T> : SortingAlgorithm<T>
      where T : IComparable<T>
    {
        // Method to sort the given array using the bubble sort algorithm.
        // Parameters:
        //ArrayToBeSorted: The array to be sorted.
        //lengthOfArray: The number of elements in the array.
        public void sortArray(IList<T> ArrayToBeSorted, int lengthOfArray)
        {
            int numberOfTimesTheArrayHasBeenPassed, index;
            T temp;
            bool swapped;

            // Outer loop iterates over the array elements.
            // It will perform (lengthOfArray - 1) passes to ensure all elements are sorted.
            for (numberOfTimesTheArrayHasBeenPassed = 0; numberOfTimesTheArrayHasBeenPassed < lengthOfArray - 1; numberOfTimesTheArrayHasBeenPassed++)
            {
                // Initialize swapped to false at the start of each pass.
                swapped = false;

                // Inner loop iterates over the array elements, comparing adjacent elements.
                // It swaps elements if they are in the wrong order.
                // The loop runs up to (lengthOfArray - numberOfTimesTheArrayHasBeenPassed - 1) as the last (numberOfTimesTheArrayHasBeenPassed) elements are already sorted.
                for (index = 0; index < lengthOfArray - numberOfTimesTheArrayHasBeenPassed - 1; index++)
                {
                    // Compare adjacent elements using the CompareTo method.
                    // If the current element is greater than the next element, swap them.
                    if (ArrayToBeSorted[index].CompareTo(ArrayToBeSorted[index + 1]) > 0)
                    {
                        temp = ArrayToBeSorted[index];
                        ArrayToBeSorted[index] = ArrayToBeSorted[index + 1];
                        ArrayToBeSorted[index + 1] = temp;
                        // Set swapped to true indicating that a swap has occurred.
                        swapped = true;
                    }
                }

                // If no elements were swapped in the inner loop, the array is already sorted.
                // Break out of the outer loop to avoid unnecessary iterations.
                if (swapped == false)
                    break;
            }
        }
    }


    class GnomeSort<T> : SortingAlgorithm<T>
        where T : IComparable<T>
    {

        // Method to sort the given array using the gnome sort algorithm.
        // Parameters:
        //ArrayToBeSorted: The array to be sorted.
        //lengthOfArray: The number of elements in the array.
        public void sortArray(IList<T> ArrayToBeSorted, int lengthOfArray)
        {
            int index = 0;

            // The gnome sort algorithm iterates over the array elements.
            while (index < lengthOfArray)
            {
                // If the current element is greater than or equal to the previous element, move to the next element.
                if (index == 0)
                    index++;
                if (ArrayToBeSorted[index].CompareTo(ArrayToBeSorted[index - 1]) >= 0)
                    index++;
                // If the current element is less than the previous element, swap the elements and move to the previous element.
                else
                {
                    T temp = ArrayToBeSorted[index];
                    ArrayToBeSorted[index] = ArrayToBeSorted[index - 1];
                    ArrayToBeSorted[index - 1] = temp;
                    index--;
                }
            }
        }
    }
    public class SortingModule<T>
        where T : IComparable<T>
    {
        private SortingAlgorithm<T> sortingAlgorithm;
        private int index_sorting_algorithm;

        // Constructor to initialize the sorting algorithm based on the index.
        // Parameters:
        //index_sorting_algorithm: The index of the sorting algorithm to be used.
        // 0 - MergeSort
        // 1 - BubbleSort
        // 2 - GnomeSort
        public SortingModule(int index_sorting_algorithm=0)
        {
            switch (index_sorting_algorithm)
            {
                case 0:
                    sortingAlgorithm = new MergeSort<T>();
                    break;
                case 1:
                    sortingAlgorithm = new BubbleSort<T>();
                    break;
                case 2:
                    sortingAlgorithm = new GnomeSort<T>();
                    break;
                default:
                    sortingAlgorithm = new MergeSort<T>();
                    break;
            }
        }

        // Method to set the sorting algorithm based on the index.
        // Parameters:
        //index_sorting_algorithm: The index of the sorting algorithm to be used.
        // 0 - MergeSort
        // 1 - BubbleSort
        // 2 - GnomeSort
        public void setSortingAlgorithm(int index_sorting_algorithm)
        {
            switch (index_sorting_algorithm)
            {
                case 0:
                    sortingAlgorithm = new MergeSort<T>();
                    break;
                case 1:
                    sortingAlgorithm = new BubbleSort<T>();
                    break;
                case 2:
                    sortingAlgorithm = new GnomeSort<T>();
                    break;
                default:
                    sortingAlgorithm = new MergeSort<T>();
                    break;
            }
        }

        public void sortArray(IList<T> arrayToBeSorted, int lengthOfArray)
        {
            sortingAlgorithm.sortArray(arrayToBeSorted, lengthOfArray);
        }

        public string getNameOfCurrentSortingAlgorithm()
        {
            switch (index_sorting_algorithm)
            {
                case 0:
                    return "MergeSort";
                case 1:
                    return "BubbleSort";
                case 2:
                    return "GnomeSort";
                default:
                    return "MergeSort";
            }
        }
    }


    internal class Program
    {     
        static void Main(string[] args)
        {
            SortingModule<int> sortingModule = new SortingModule<int>(0);
            int[] arrayToBeSorted = { 12, 11, 13, 5, 6, 7 };
            int lengthArray = arrayToBeSorted.Length;
            sortingModule.getNameOfCurrentSortingAlgorithm();
            sortingModule.sortArray(arrayToBeSorted, lengthArray);
            for (int i = 0; i < lengthArray; i++)
            {
                System.Console.Write(arrayToBeSorted[i] + " ");
            }
            sortingModule.setSortingAlgorithm(1);
            sortingModule.getNameOfCurrentSortingAlgorithm();
            arrayToBeSorted = new int[] { 12, 11, 13, 5, 6, 7 };
            lengthArray = arrayToBeSorted.Length;
            sortingModule.sortArray(arrayToBeSorted, lengthArray);
            System.Console.WriteLine();
            for (int i = 0; i < lengthArray; i++)
            {
                System.Console.Write(arrayToBeSorted[i] + " ");
            }
            sortingModule.setSortingAlgorithm(2);
            sortingModule.getNameOfCurrentSortingAlgorithm();
            arrayToBeSorted = new int[] { 12, 11, 13, 5, 6, 7 };
            lengthArray = arrayToBeSorted.Length;
            sortingModule.sortArray(arrayToBeSorted, lengthArray);
            System.Console.WriteLine();
            for (int i = 0; i < lengthArray; i++)
            {
                System.Console.Write(arrayToBeSorted[i] + " ");
            }
            sortingModule.setSortingAlgorithm(3);
            sortingModule.getNameOfCurrentSortingAlgorithm();
        }
    }
}

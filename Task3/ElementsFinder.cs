namespace Task3;

public class ElementsFinder
{

    // This method uses so called Sliding Window Algorithm
    public static void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
    {
        // Initialize the start and end indices to 0
        // If no indices will be found, those values will be returned
        start = 0;
        end = 0;

        if (list == null || list.Count == 0)
        {
            return;
        }

        // Initialization of the current sum and the start index of the window
        ulong currentSum = 0;
        int startIndex = 0;

        // Iterate through the list 
        for (int endIndex = 0; endIndex < list.Count; endIndex++)
        {
            // Adding the current element to the current sum
            currentSum += list[endIndex];

            // Shrink the window from the left if the current sum exceeds the target sum
            while (currentSum > sum)
            {
                currentSum -= list[startIndex];
                startIndex++;
            }

            // If the current sum equals the target sum, store the start and end indices      
            if (currentSum == sum)
            {
                start = startIndex;
                end = endIndex;

                return;
            }
        }
    }
}

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new array of doubles with the given length.
        // This array will store the multiples of the given number.
        double[] result = new double[length];

        // Step 2: Loop from 0 to length - 1.
        // Each position in the array will be filled with a multiple of 'number'.
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple.
            // Since arrays start at index 0, we use (i + 1) to get:
            // number, 2*number, 3*number, etc.
            result[i] = number * (i + 1);
        }

        // Step 4: Return the filled array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Understand the goal.
        // Rotating right means the last 'amount' elements will move to the front.
        // Example:
        // data = {1,2,3,4,5,6,7,8,9}, amount = 3
        // lastPart  = {7,8,9}
        // firstPart = {1,2,3,4,5,6}
        // result    = {7,8,9,1,2,3,4,5,6}

        // Step 2: Find where to split the list.
        // The split index is: data.Count - amount
        int splitIndex = data.Count - amount;

        // Step 3: Get the last 'amount' elements (the part that moves to the front).
        List<int> lastPart = data.GetRange(splitIndex, amount);

        // Step 4: Get the first part (everything before the split index).
        List<int> firstPart = data.GetRange(0, splitIndex);

        // Step 5: Clear the original list because we are modifying it, not returning a new one.
        data.Clear();

        // Step 6: Add the last part first.
        data.AddRange(lastPart);

        // Step 7: Add the first part after it.
        data.AddRange(firstPart);

    }
}

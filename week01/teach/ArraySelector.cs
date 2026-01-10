public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        // Create an array to store the result
        int[] result = new int[select.Length];

        // These will track the current position in each list
        int l1Idx = 0;
        int l2Idx = 0;

        // Loop through every value in the selector array
        for (int i = 0; i < select.Length; i++)
        {
            // If selector is 1, take next value from list1
            if (select[i] == 1)
            {
                result[i] = list1[l1Idx];
                l1Idx = l1Idx + 1;
            }
            // If selector is 2, take next value from list2
            else if (select[i] == 2)
            {
                result[i] = list2[l2Idx];
                l2Idx = l2Idx + 1;
            }
        }

        // Return the combined array
        return result;
    }
}
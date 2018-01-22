class Random {
    public static int[] CreateRandomArr(int start = 0, int length = 1)
    {
        if (start < 1)
            start = 0;

        if (length < 1)
            length = 1;

        if (length <= 1)
            return new int[1] { start };

        int[] array = Enumerable.Range(start, length).ToArray();

        int first = 0;
        while (true)
        {
            if (first > length - 1)
                break;

            var rand = new Random(DateTime.Now.Millisecond);
            var next = rand.Next(first, length - 1);
            var next2 = rand.Next(0, first > length / 2 ? first : length / 2);

            int tmp = array[first];
            array[first] = array[next];
            array[next] = tmp;

            tmp = array[next];
            array[next] = array[next2];
            array[next2] = tmp;

            first++;
        }
        return array;
    }
}

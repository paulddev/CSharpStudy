# Array

## Array
1. 배열은 `reference type`
2. 배열을 생성하고 초기화 하는 방법이 여러가지가 있다.
3. 모든 배열은 `System.Array`로부터 파생된다. => 다양한 메소드를 지원한다.
```C#
class Program
{
    static void Main()
    {
        int[] arr1; // 참조변수만
        int[] arr2 = new int[5]; // 자동으로 0으로 초기화
        int[] arr3 = new int[5] { 1, 2, 3, 4, 5 };
        int[] arr4 = new int[] { 1, 2, 3, 4, 5 };
        int[] arr5 = { 1, 2, 3, 4, 5 };

        Type t = arr5.GetType();
        Console.WriteLine(t.FullName); // System.Int32[]
        Console.WriteLine(t.BaseType); // System.Array
        Console.WriteLine(t.BaseType.BaseType.FullName); // System.Object

        Console.WriteLine(arr5.Length);           // 5
        Console.WriteLine(arr5.GetLength(0));     // 5
        Console.WriteLine(arr5.GetValue(3));      // 4
        Console.WriteLine(arr5.GetLowerBound(0)); // 0 (배열에 지정된 첫번째 요소의 인덱스)
        Console.WriteLine(arr5.GetUpperBound(0)); // 4 (배열에 지정된 마지막 요소의 인덱스)

        int[] arr6 = { 1, 2, 3, 4, 5 };
        int[] arr7 = arr6; // 얕은 복사 (주소값만 복사)
        int[] arr8 = (int[])arr6.Clone(); // 깊은 복사

        Console.WriteLine(arr6 == arr7); // true
        Console.WriteLine(arr6 == arr8); // false
    }
}
```

## 다차원 배열
```C#
class Program
{
    static void Main()
    {
        int[] arr = new int[3];

        int[,] arr1 = new int[3, 2];
        int[,] arr2 = new int[3, 2] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
        int[,] arr3 = new int[,] { { 1, 1 }, { 2, 2 }, { 3, 3 } };

        arr1[0, 0] = 5;
        arr1[1, 0] = 4;

        // 차례대로 꺼내서 출력한다.
        foreach(int n in arr1)
            Console.WriteLine(n);

        int[,,] arr4 = new int[2, 2, 2];
    }
}
```

## 가변 배열 (Jagged Array)
```C#
class Program
{
    static void Main()
    {
        int[][] arr = new int[3][];
        arr[0] = new int[3] { 1, 2, 3 };
        arr[1] = new int[2] { 1, 2 };
        arr[2] = new int[1] { 1 };

        int[] temp = arr[0];

        arr[0][1] = 10;

        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write($"{arr[i][j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        int[][] arr2 = new int[3][] { new int[3], new int[2], new int[1] };
    }
}
```

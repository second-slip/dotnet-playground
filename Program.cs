// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;


// (-1, 2) --> 2 (-1 + 0 + 1 + 2 = 2)

// GetSum(0, -1);

int GetSum(int a, int b)
{
    if (a == b) return a;

    var range = GenerateSequenceInRange(Math.Min(a, b), Math.Max(a, b));

    return range.Sum();
}

static IEnumerable<int> GenerateSequenceInRange(int min, int max)
{
    while (min <= max)
    {
        yield return min++;
    }
}


// yield return - again
foreach (int i in ProduceEvenNumbers(9))
{
    Console.Write(i);
    Console.Write(" ");
    System.Threading.Thread.Sleep(2000);
}
// Output: 0 2 4 6 8

IEnumerable<int> ProduceEvenNumbers(int upto)
{
    for (int i = 0; i <= upto; i += 2)
    {
        // if (i > 4) yield return i;
        yield return i;
    }
}

static IEnumerable<string> OpenOrSenior(int[][] data)
{
    var results = data.Select(x => CheckMembershipCategory(x)).ToList();

    //or.............

    // var results = new List<string>();

    // foreach (var item in data)
    // {
    //     results.Add(CheckMembershipCategory(item));
    // }

    return results;
}

static string CheckMembershipCategory(int[] memberData) => (memberData[0] > 54 & memberData[1] > 7) ? "Senior" : "Open";




// Given a string of words, you need to find the highest scoring word.
// Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.
// For example, the score of abad is 8 (1 + 2 + 1 + 4).
// You need to return the highest scoring word as a string.
// If two words score the same, return the word that appears earliest in the original string.
// All letters will be lowercase and all inputs will be valid.

// High("man i need a taxi up to ubud"); //.Returns("semynak");

static int Grow(int[] x)
{
    var p = x.OrderBy(x => x).Aggregate(1, (accumulator, next) => accumulator * next);
    return p;
}

static string High(string s)
{
    // Note the test cases use yield return!
    var words = s.ToLower().Split(" ");
    var word = words.MaxBy(x => GetWordPoints(x));
    return word;
}

static int GetWordPoints(string word)
{
    int ANSII_OFFSET = 96;

    int points = 0;

    foreach (char c in word)
    {
        points += (int)c - ANSII_OFFSET;
    }

    return points;
}


static bool IsValidWalk(string[] walk)
{
    if (walk.Length != 10) return false;

    var eastWestEqual = walk.Count(d => d == "e") == walk.Count(d => d == "w");
    var northSouthEqual = walk.Count(d => d == "n") == walk.Count(d => d == "s");

    return eastWestEqual && northSouthEqual;
}

// Count the number of Duplicates
// Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits 
// that occur more than once in the input string. The input string can be assumed to contain only alphabets 
// (both uppercase and lowercase) and numeric digits.

static int DuplicateCount(string str)
{
    // return str.ToLower().GroupBy(c => c).Count(c => c.Count() > 1);
    var dupCharCount = str.ToLower()
                    .GroupBy(c => c)
                    .Select(x => new
                    {
                        Char = x.Key,
                        Count = x.Count()
                    })
                    .Where(x => x.Count > 1);

    return dupCharCount.Count();
}


// remove first & last characters
static string Remove_char(string s)
{
    return s.Substring(1, (s.Length - 2));
}

static string Bmi(double weight, double height)
{
    var bmi = weight / Math.Pow(height, 2);

    if (bmi > 30) return "Obese";
    if (bmi > 25) return "Overweight";
    if (bmi > 18.5) return "Normal";
    else return "Underweight";
}

static double[] Tribonacci(double[] signature, int n)
{
    if (n < 4)
    {
        return signature.Take(n).ToArray();
    }

    List<double> sequence = new List<double>(signature);

    while (sequence.Count() < n)
    {
        sequence.Add(SumLastThree(sequence));
    }

    return sequence.ToArray();
}

static double SumLastThree(List<double> values) => values.Skip(Math.Max(0, values.Count() - 3)).Sum();


static bool ZeroFuel(uint distanceToPump, uint mpg, uint fuelLeft)
{
    return mpg * fuelLeft >= distanceToPump;
    // var milesLeft = mpg * fuelLeft;
    // return (distanceToPump >= milesLeft);
}

static int FindShort(string s)
{
    return s.Split(" ").ToArray().Select(g => g.Length).Min();

    // better: return s.Split(' ').Min(x => x.Length);
    // look to use Array methods before Linq
}


static string Longest(string s1, string s2)
{
    var combo = string.Concat(s1, s2).Distinct().OrderBy(s => s);
    return new string(combo.ToArray());
}

static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
{
    return listOfItems.OfType<int>();
}

static string FakeBin(string x)
{

    // return string.Concat(x.Select(a => a < '5' ? "0" : "1"));

    var digitArray = x.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();

    var returnString = "";

    for (int i = 0; i < digitArray.Length; i++)
    {
        if (digitArray[i] < 5)
        {
            returnString = returnString + '0';
        }
        else
        {
            returnString = returnString + '1';
        }
    }

    return returnString;
}

static string RepeatStr(int n, string s)
{
    var list = Enumerable.Repeat(s, n);
    return string.Concat(list);
}

static int Opposite(int number)
{
    return -number;
}

static bool XO(string input)
{
    var x = input.ToLower().Count(x => x == 'x');
    var o = input.ToLower().Count(x => x == 'o');
    return x == o;
}

static bool lovefunc(int flower1, int flower2)
{
    // return int.IsEvenInteger(flower1) && int.IsEvenInteger(flower2);
    return (flower1 + flower2) % 2 == 1;
}

static int Litres(double time)
{
    //The fun begins here.
    var litres = Math.Floor(time * 0.5);
    return Convert.ToInt32(litres);
}

static string NoSpace(string input)
{
    var result = input.Replace(" ", string.Empty);
    return result;
}

static bool IsTriangle(int a, int b, int c)
{
    if (a + b <= c || a + c <= b || b + c <= a)
        return false;
    else
        return true;
}

static bool ValidatePin(string pin)
{
    var rgx = new Regex(@"^\d{4}(?:\d{2})?$", RegexOptions.ECMAScript);
    return rgx.IsMatch(pin.Trim());
}

static long[] Digitize(long n)
{
    var t = n.ToString().Select(o => Convert.ToInt64(o) - 48).Reverse().ToArray();
    Array.Reverse(t);
    return t;
}


// Console.WriteLine(FindNeedle(["hay", "junk", "hay", "hay", "moreJunk", "needle", "randomJunk"]));

static string FindNeedle(object[] haystack)
{
    var index = Array.IndexOf(haystack, "needle");

    return string.Format("found the needle at position {0}", index);
}

// Console.WriteLine(summation(8));

static int summation(int num)
{
    var sum = Enumerable.Range(1, num).Sum();

    // int sum = 0;
    // for (int i = 1; i <= num; i++)
    // {
    //     sum += i;
    // }

    // public static int summation(int n) => n * ++n / 2;

    return sum;
}


static int SquareSum(int[] numbers)
{
    return numbers.Sum(n => n * n);
}


// Task:
// Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence, 
// which is the number of times you must multiply the digits in num until you reach a single digit.

// Example
// 39 --> 3 (because 3*9 = 27, 2*7 = 14, 1*4 = 4 and 4 has only one digit)
// 999 --> 4 (because 9*9*9 = 729, 7*2*9 = 126, 1*2*6 = 12, and finally 1*2 = 2)
// 4 --> 0 (because 4 is already a one-digit number)

// Console.WriteLine(Persistence(999));

static int Persistence(long n)
{
    int times = 0;
    while (n.ToString().Length > 1)
    {
        // split the number into an array, then use aggregate function to multiply the digits
        n = n.ToString().Select(c => int.Parse(c.ToString())).Aggregate(1, (acc, val) => acc * val);
        times++;
    }
    return times;
}

static int Persistence1(long n)
{
    var result = ToIntArray(n);
    var product = CalculateProduct(result);

    if (product <= 9) return 0;

    int times = 1;

    while (product >= 9)
    {
        result = ToIntArray(product);
        product = CalculateProduct(result);
        // Console.WriteLine(product);
        times++;
    }

    return times;
}

static int[] ToIntArray(long value) => value.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();

static int CalculateProduct(int[] value) => value.Aggregate(1, (accumulator, next) => accumulator * next);



// static bool Narcissistic(int value)
// {
//     var str = value.ToString();
//     return str.Sum(c => Math.Pow(Convert.ToInt16(c.ToString()), str.Length)) == value;
// }

// // SumStringDigits("555");

// static void SumStringDigits(string s)
// {
//     int? a = s.Sum(c => Convert.ToInt32(c.ToString()));
//     Console.WriteLine(a);
// }



// var y = DeleteNth([1, 2, 3, 1, 2, 1, 2, 3], 2);

// y.ForEach(i => Console.Write("{0}\t", i));



// Given a list and a number, create a new list that contains each number of lst at most N times without reordering. 
// For example if the input number is 2, and the input list is [1,2,3,1,2,1,2,3], you take [1,2,3,1,2], 
// drop the next [1,2] since this would lead to 1 and 2 being in the result 3 times, 
// and then take 3, which leads to [1,2,3,1,2,3]. With list [20,37,20,21] and number 1, the result would be [20,37,21].
static List<int> DeleteNth(int[] arr, int x)
{
    var newList = new List<int>();

    foreach (var item in arr)
    {
        var count = newList.Count(i => i == item);
        if (count >= x)
        {
            continue;
        }
        else
        {
            newList.Add(item);
        }
    }
    return newList;
}


static int[] DeleteNth2(int[] arr, int x)
{
    List<int> list = [];

    for (int i = 0; i < arr.Length; i++)
    {
        var t = arr[i];
        int count = 0;

        foreach (var s in arr.Take(i + 1))
        {
            if (s == t) count++;
        }

        if (count <= x)
            list.Add(t);
    }

    return list.ToArray();
}









static bool Narcissistic(int value)
{
    var str = value.ToString();
    return str.Sum(c => Math.Pow(Convert.ToInt16(c.ToString()), str.Length)) == value;
}

// SumStringDigits("555");

static void SumStringDigits(string s)
{
    int? a = s.Sum(c => Convert.ToInt32(c.ToString()));
    Console.WriteLine(a);
}


var result = Find([2, 4, 0, 100, 4, 11, 2602, 36]);
// Console.WriteLine(result);

static int Find(int[] integers)
{
    return integers.Count(IsEven) > 1 ? integers.First(IsOdd) : integers.First(IsEven);
}

static bool IsOdd(int value) => value % 2 != 0;

static bool IsEven(int value) => value % 2 == 0;


// Implement the function unique_in_order which takes as argument a sequence 
// and returns a list of items without any elements with the same 
// value next to each other and preserving the original order of elements.

// https://www.codewars.com/kata/54e6533c92449cc251001667/csharp

static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
{
    var current = default(T);  // default should come to mind when working with generic type T

    foreach (var item in iterable)
    {
        if (item.Equals(current))
            continue;

        current = item;

        yield return item; // 
    }
}

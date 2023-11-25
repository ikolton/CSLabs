using System;

namespace Zad5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class ConnectStrings
    {
        public string Connect(string first, string second)
        {
            if (first == null || second == null)
                return null;

            return first + second;
        }
    }

    public class ConnectStringsWithException
    {
        public string Connect(string first, string second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();

            return first + second;
        }
    }
    
    /**
* Interfejs obiektu który sprawdza czy dane słowa są anagramami. * Anagram
jest słowem lub frazą, która powstała
* przez zmianę kolejności liter w oryginalnym słowie lub frazie.
* Zobacz kilka przykładów na http://www.wordsmith.org/anagram/hof.html
*/
    public interface IAnagramChecker
    {
/*Sprawdza czy jedno slowo jest anagramem drugiego.
 * Wszystkie niealfanumeryczne znaki są ignorowane.
 * Wielkość liter nie ma znaczenia.
 * word1 - dowolny niepusty string różny od null.
 * word2 - dowolny niepusty string różny od null.
 * Zwraca true wtedy i tylko wtedy gdy word1 jest anagramem word2.
 */
        bool IsAnagram(string word1, string word2);
    }
    
    public class AnagramChecker : IAnagramChecker
    {
        public bool IsAnagram(string word1, string word2)
        {
            if (word1 == null || word2 == null)
                return false;
            word1 = word1.ToLower();
            word2 = word2.ToLower();
            //remove all non-alphanumeric characters
            word1 = word1.Replace(" ", "");
            word2 = word2.Replace(" ", "");
            
            if (word1.Length != word2.Length)
                return false;
            var word1Array = word1.ToCharArray();
            var word2Array = word2.ToCharArray();
            Array.Sort(word1Array);
            Array.Sort(word2Array);
            for (var i = 0; i < word1Array.Length; i++)
            {
                if (word1Array[i] != word2Array[i])
                    return false;
            }
            return true;
        }
    }
    
}
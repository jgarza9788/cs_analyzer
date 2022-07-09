using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_6
    {
        public string CompressText(string text)
        {
            // To save time.
            if (string.IsNullOrWhiteSpace(text) || text.Length == 1) return text;

            string[] compressed = new string[text.Length];

            // Set initial text to $prevChar
            // for reach $currChar in $text
            // if $prevChar == $currChar, then 
            //      increase $charCount
            // else 
            //      Add $prevChar to $compressed with $charCount
            //      Set $prevChar to $currChar
            //      reset $charCount to 1
            //
            // After the loop is over, add the $prevChar to $compressed with $charCount
            // return stringified $compressed

            char prevChar = text[0];
            int compressedIndex = 0;
            int charCount = 1;
            // we are adding two strings into array, current character and the number of occurrences.
            const int indexOffset = 2;

            // Skip the first character.
            foreach (char currChar in text.Skip(1))
            {
                if (prevChar == currChar)
                {
                    charCount++;
                }
                else
                {
                    if (compressedIndex + indexOffset > text.Length) return text;

                    compressed[compressedIndex] = prevChar.ToString();
                    compressed[compressedIndex + 1] = charCount.ToString();

                    prevChar = currChar;
                    charCount = 1;

                    compressedIndex += indexOffset;
                }
            }

            // Set the last character's data
            compressed[compressedIndex] = prevChar.ToString();
            compressed[compressedIndex + 1] = charCount.ToString();

            return string.Join("", compressed);
        }
    }
}
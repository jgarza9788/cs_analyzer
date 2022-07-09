using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_3
    {
        public string UrlifyString(string text, int trueLength)
        {
            // Algorithm:
            // Get substring "s" upto trueLength.
            // Count the number of empty strings in "s"
            // Create a new character array "result" where length = non-space character count + (space count * 3)

            // foreach character "c" in "s"
            // if "c" == space, then insert "%20" into "result" taking up three indexes.
            // else insert "c" into "result".


            char[] upto = text.Substring(0, trueLength).ToCharArray();

            int spaceCount = upto.Where(c => c == ' ').Count();
            int nonSpaceCount = upto.Length - spaceCount;

            char[] encodedSpace = { '%', '2', '0' };
            int resultLength = nonSpaceCount + (spaceCount * encodedSpace.Length);
            char[] result = new char[resultLength];

            // offset caused by adding "%20" instead of space.
            int offset = 0;
            for (int i = 0; i < upto.Length; i++)
            {
                var c = upto[i];

                if (c == ' ')
                {
                    result[i + offset] = '%';
                    result[i + 1 + offset] = '2';
                    result[i + 2 + offset] = '0';

                    offset += 2;
                }
                else
                {
                    result[i + offset] = c;
                }
            }

            return new string(result);
        }
    }
}
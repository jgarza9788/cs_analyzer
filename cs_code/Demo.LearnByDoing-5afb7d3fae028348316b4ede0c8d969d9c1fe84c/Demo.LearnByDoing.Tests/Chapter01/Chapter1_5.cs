using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.Chapter01
{
    public class Chapter1_5
    {
        public bool IsOneEditAway(string text1, string text2)
        {
            List<char> c1, c2;

            if (text1.Length <= text2.Length)
            {
                c1 = text1.ToCharArray().ToList();
                c2 = text2.ToCharArray().ToList();
            }
            else
            {
                c1 = text2.ToCharArray().ToList();
                c2 = text1.ToCharArray().ToList();
            }

            List<char> temp1 = new List<char>(c1);
            string c2Text = new string(c2.ToArray());

            for (int i = 0; i < c1.Count; i++)
            {

                if (c1[i] != c2[i])
                {
                    //*** Insert check
                    temp1.Insert(i, c2[i]);
                    if (c2Text == new string(temp1.ToArray()))
                        return true;

                    // reset the list.
                    temp1 = new List<char>(c1);

                    //*** Remove check
                    temp1.RemoveAt(i);
                    if (c2Text == new string(temp1.ToArray()))
                        return true;

                    // reset the list.
                    temp1 = new List<char>(c1);

                    //*** Replace check
                    temp1[i] = c2[i];
                    if (c2Text == new string(temp1.ToArray()))
                        return true;
                }
            }

            // Insert the rest of c2 to temp1 and compare.
            if (c2.Count - c1.Count == 1)
            {
                // reset the list.
                temp1 = new List<char>(c1);

                //** insert the rest
                temp1.Insert(c1.Count, c2[c1.Count]);

                if (c2Text == new string(temp1.ToArray()))
                    return true;
            }


            return false;
        }
    }
}
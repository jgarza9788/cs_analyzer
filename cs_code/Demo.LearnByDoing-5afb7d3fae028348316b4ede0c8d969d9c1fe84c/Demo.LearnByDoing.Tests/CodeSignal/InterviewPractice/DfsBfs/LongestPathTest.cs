using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.Tests.CodeSignal.InterviewPractice.DfsBfs
{
    public class LongestPathTest
    {
    }

    public class Program
    {
        public static void Main()
        {
            string line = "user\n\tpictures\n\t\tphoto.png\n\t\tcamera\n\tdocuments\n\t\tlectures\n\t\t\tnotes.txt";
            var split = line.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // foreach (var c in split) Console.WriteLine(c);

            var root = new Tree { Value = split[0] };
            var head = BuildTree(root, split.Skip(1).ToList(), 0);

            Console.WriteLine(head);
        }

        public static Tree BuildTree(Tree parent, List<string> rest, int depth)
        {
            if (rest.Count == 0) return parent;

            for (int i = 0; i < rest.Count; i++)
            {
                var current = rest[i];
                var currentTree = new Tree { Value = current };
                var currentDepth = current.ToArray().Count(c => c == '\t');

                if (currentDepth == depth)
                {
                    rest.RemoveAt(i);
                    i--;
                    parent.Children.Add(currentTree);
                }
                else if (currentDepth - 1 == depth)
                {
                    rest.RemoveAt(i);
                    i--;
                    var children = BuildTree(currentTree, rest, currentDepth + 1);
                    parent.Children.Add(children);
                }
                else if (currentDepth < depth)
                {
                    return parent;
                }
            }

            return parent;
        }
    }

    public class Tree
    {
        public string Value { get; set; }
        public List<Tree> Children { get; set; } = new List<Tree>();
    }
}

namespace Demo.LearnByDoing.General.Tree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
        }

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

	    public static bool operator==(TreeNode<T> left, TreeNode<T> right)
	    {
		    if (ReferenceEquals(left, right)) return true;
		    if (ReferenceEquals(left, null)) return false;
		    if (ReferenceEquals(null, right)) return false;

		    return left.Value.Equals(right.Value);
	    }

	    public static bool operator !=(TreeNode<T> left, TreeNode<T> right)
	    {
		    return !(left == right);
	    }

	    public override bool Equals(object obj)
	    {
		    return Value.Equals(obj as TreeNode<T>);
	    }
    }
}
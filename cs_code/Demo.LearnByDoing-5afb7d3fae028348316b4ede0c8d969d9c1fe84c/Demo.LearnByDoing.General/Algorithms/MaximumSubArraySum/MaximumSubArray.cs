namespace Demo.LearnByDoing.General.Algorithms.MaximumSubArraySum
{
	public class MaximumSubArray
	{
		public int From { get; set; }
		public int To { get; set; }
		public int Sum { get; set; }

		public MaximumSubArray(int @from, int to, int sum)
		{
			From = @from;
			To = to;
			Sum = sum;
		}
	}
}
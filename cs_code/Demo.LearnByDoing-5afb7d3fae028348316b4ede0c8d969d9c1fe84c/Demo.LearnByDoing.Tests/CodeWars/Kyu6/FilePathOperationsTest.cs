using System.IO;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/file-path-operations/train/csharp
	/// </summary>
	[TestFixture]
	public class FilePathOperationsTest
	{
		[Test]
		public void ExampleTest()
		{
			FileMaster FM = new FileMaster("/Users/person1/Pictures/house.png");
			Assert.AreEqual("png", FM.extension());
			Assert.AreEqual("house", FM.filename());
			Assert.AreEqual("/Users/person1/Pictures/", FM.dirpath());
		}
	}

	class FileMaster
	{
		private readonly string _filepath;

		public FileMaster(string filepath)
		{
			_filepath = filepath;
		}

		public string extension()
		{
			return Path.GetExtension(_filepath).Substring(1);
		}

		public string filename()
		{
			return Path.GetFileNameWithoutExtension(_filepath);
		}

		public string dirpath()
		{
			return Path.GetDirectoryName(_filepath).Replace(@"\", "/") + '/';
		}
	}
}

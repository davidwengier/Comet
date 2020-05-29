using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace GeneratorTests
{
	public class BaseTest
	{
		public static IEnumerable<object[]> GetAllTestData()
		{
			foreach (string file in Directory.EnumerateFiles("CodeParsingSamples"))
			{
				var testName = Path.GetFileNameWithoutExtension(file);
				var data = GetTestData(testName);
				yield return new object[] { testName, data.Source, data.JsonExpectedResult };
			}
		}

		public static (string Source, string JsonExpectedResult) GetTestData(string file) =>
			(File.ReadAllText(Path.Combine("CodeParsingSamples", $"{file}.cs")),
			File.ReadAllText(Path.Combine("CodeParsingSamples", $"{file}.txt")));
	}
}

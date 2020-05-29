using System.Linq;
using Comet.SourceGenerators;
using Newtonsoft.Json;
using Xunit;

namespace GeneratorTests {
	public class CometViewParserTests :BaseTest {
		[Theory]
		[MemberData(nameof(GetAllTestData))]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1026:Theory methods should use all of their parameters", Justification = "Used to get a nice display in Test Explorer")]
		void TestCodeSample(string testName, string source, string jsonExpectedResult)
		{
			var codeParser = new CometViewParser();
			var parse = codeParser.ParseCode(source).ToList();
			var text = JsonConvert.SerializeObject(parse);

			Assert.Equal(jsonExpectedResult, text);
		}
	}
}

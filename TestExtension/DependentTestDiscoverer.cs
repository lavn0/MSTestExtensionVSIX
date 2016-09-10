using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace TestExtension
{
	[DefaultExecutorUri(DependentTestContainerDiscoverer.UriString)]
	[FileExtension(".dll")]
	public class DependentTestDiscoverer : ITestDiscoverer
	{
		public void DiscoverTests(
			IEnumerable<string> sources,
			IDiscoveryContext discoveryContext,
			IMessageLogger logger,
			ITestCaseDiscoverySink discoverySink)
		{
			GetTests(sources, discoverySink);
		}

		public static List<TestCase> GetTests(
			IEnumerable<string> sources,
			ITestCaseDiscoverySink discoverySink)
		{
			foreach (string source in sources)
			{
				Console.WriteLine($"DebugOutput:: {source}"); // vstest.console.exeでの実行時、出力できることを確認
			}

			return new List<TestCase>();
		}
	}
}

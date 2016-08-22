using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;

namespace TestExtension
{
	[DefaultExecutorUri(DependentTestContainerDiscoverer.UriString)]
	[FileExtension(".xml")]
	public class DependentTestDiscoverer : ITestDiscoverer
	{
		public void DiscoverTests(
			IEnumerable<string> sources,
			IDiscoveryContext discoveryContext,
			IMessageLogger logger,
			ITestCaseDiscoverySink discoverySink)
		{

		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestWindow.Extensibility;

namespace TestExtension
{
	[Export(typeof(ITestContainerDiscoverer))]
	public class DependentTestContainerDiscoverer : ITestContainerDiscoverer
	{
		internal const string UriString = "executor://DependentTestExecutor/v1";

		public event EventHandler TestContainersUpdated;
		private readonly IServiceProvider serviceProvider;
		private readonly ILogger logger;

		public Uri ExecutorUri { get; } = new Uri(UriString);
		public IEnumerable<ITestContainer> TestContainers { get; } = Enumerable.Empty<ITestContainer>();

		[ImportingConstructor]
		public DependentTestContainerDiscoverer(
			[Import(typeof(SVsServiceProvider))] IServiceProvider serviceProvider,
			ILogger logger)
		{
			this.serviceProvider = serviceProvider;
			this.logger = logger;

			var sbm = ServiceProvider.GlobalProvider.GetService(typeof(SVsSolutionBuildManager)) as IVsSolutionBuildManager2;
			if (sbm != null)
			{
				var solutionEventListener = new SolutionEventListener(this.serviceProvider);
				uint updateSolutionEventsCookie;
				sbm.AdviseUpdateSolutionEvents(solutionEventListener, out updateSolutionEventsCookie);
			}
		}
	}
}

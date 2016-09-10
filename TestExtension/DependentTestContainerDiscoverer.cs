using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestWindow;
using Microsoft.VisualStudio.TestWindow.Controller;
using Microsoft.VisualStudio.TestWindow.Extensibility;

namespace TestExtension
{
	[Export(typeof(ITestContainerDiscoverer))]
	public class DependentTestContainerDiscoverer : ITestContainerDiscoverer
	{
		internal const string UriString = "executor://DependentTestExecutor/v1";

		public event EventHandler TestContainersUpdated;
		private readonly IServiceProvider serviceProvider;
		private readonly SafeDispatcher safeDispatcher;
		private readonly ILogger logger;

		public Uri ExecutorUri { get; } = new Uri(UriString);
		public IEnumerable<ITestContainer> TestContainers
		{
			get
			{
				var projects = ((IVsSolution)this.serviceProvider.GetService(typeof(SVsSolution))).EnumerateLoadedProjects().ToList();
				var outputPaths = projects.Select(p => VSProjectExtensions.GetProjectOutputPath(p, this.serviceProvider, this.safeDispatcher, logger)).ToList();
				foreach (var outputPath in outputPaths)
				{
					Debug.WriteLine($"Output File Found. Path= '{outputPath}'");
				}

				return Enumerable.Empty<ITestContainer>();
			}
		}

		[ImportingConstructor]
		public DependentTestContainerDiscoverer(
			[Import(typeof(SVsServiceProvider))] IServiceProvider serviceProvider,
			SafeDispatcher safeDispatcher,
			ILogger logger)
		{
			this.serviceProvider = serviceProvider;
			this.safeDispatcher = safeDispatcher;
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

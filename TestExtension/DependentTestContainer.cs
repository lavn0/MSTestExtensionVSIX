using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestWindow.Extensibility;
using Microsoft.VisualStudio.TestWindow.Extensibility.Model;

namespace TestExtension
{
	internal class DependentTestContainer : ITestContainer
	{
		public DependentTestContainer(
			ITestContainerDiscoverer dependentTestContainerDiscoverer,
			string source)
		{
			this.Discoverer = dependentTestContainerDiscoverer;
			this.Source = source;
		}

		public IEnumerable<Guid> DebugEngines { get; } = Enumerable.Empty<Guid>();
		public ITestContainerDiscoverer Discoverer { get; }
		public bool IsAppContainerTestContainer { get { return false; } }
		public string Source { get; }
		public FrameworkVersion TargetFramework { get; } = FrameworkVersion.None;
		public Architecture TargetPlatform { get; } = Architecture.AnyCPU;
		public int CompareTo(ITestContainer other) => ((other as DependentTestContainer)?.Source.CompareTo(this.Source)).GetValueOrDefault(-1);
		public IDeploymentData DeployAppContainer() => null;
		public ITestContainer Snapshot() => new DependentTestContainer(this.Discoverer, this.Source);
		public override string ToString() => nameof(DependentTestContainer) + "/" + this.Source;
	}
}

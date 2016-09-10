using System;
using System.Diagnostics;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

namespace TestExtension
{
	internal class SolutionEventListener : IVsUpdateSolutionEvents
	{
		private readonly IServiceProvider serviceProvider;

		public SolutionEventListener(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public int OnActiveProjectCfgChange(IVsHierarchy pIVsHierarchy) => VSConstants.S_OK;

		public int UpdateSolution_Begin(ref int pfCancelUpdate) => VSConstants.S_OK;

		public int UpdateSolution_Cancel() => VSConstants.S_OK;

		public int UpdateSolution_Done(int fSucceeded, int fModified, int fCancelCommand)
		{
			if (fModified != 0)
			{
				Debug.WriteLine($"{DateTime.Now.TimeOfDay}\tfModified={fModified}");
			}
			else if (fSucceeded != 0)
			{
				Debug.WriteLine($"{DateTime.Now.TimeOfDay}\tfSucceeded={fSucceeded}");
			}
			else if (fCancelCommand != 0)
			{
				Debug.WriteLine($"{DateTime.Now.TimeOfDay}\tfCancelCommand={fCancelCommand}");
			}

			return VSConstants.S_OK;
		}

		public int UpdateSolution_StartUpdate(ref int pfCancelUpdate) => VSConstants.S_OK;
	}
}

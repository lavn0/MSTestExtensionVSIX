using System;

namespace TestExtension
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class DependentTestMethodAttribute : System.Attribute
	{
	}
}

using System;

namespace TestExtension
{
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class DependentTestClassAttribute : Attribute
	{
	}
}

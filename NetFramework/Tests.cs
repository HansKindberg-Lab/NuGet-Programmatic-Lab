using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet;

namespace NetFramework
{
	[TestClass]
	public class Tests
	{
		#region Fields

		private static string _packageReferenceFilePath;

		#endregion

		#region Properties

		// ReSharper disable PossibleNullReferenceException
		protected internal virtual string PackageReferenceFilePath => _packageReferenceFilePath ?? (_packageReferenceFilePath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, Constants.PackageReferenceFile));
		// ReSharper restore PossibleNullReferenceException

		#endregion

		#region Methods

		[TestMethod]
		public void GetPackagesFromPackagesConfig()
		{
			var packageReferenceFile = new PackageReferenceFile(this.PackageReferenceFilePath);

			var packageReferences = packageReferenceFile.GetPackageReferences().ToArray();

			var version = packageReferences.First().Version;

			Assert.AreEqual(34, packageReferences.Length);
		}

		#endregion
	}
}
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Sandbox.Properties
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					ResourceManager temp = (resourceMan = new ResourceManager("Sandbox.Properties.Resources", typeof(Resources).Assembly));
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap Copy
		{
			get
			{
				object obj = ResourceManager.GetObject("Copy", resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal static Bitmap Copy1
		{
			get
			{
				object obj = ResourceManager.GetObject("Copy1", resourceCulture);
				return (Bitmap)obj;
			}
		}

		internal Resources()
		{
		}
	}
}

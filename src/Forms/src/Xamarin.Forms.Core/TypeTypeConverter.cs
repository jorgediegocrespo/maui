using System;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms
{
	[ProvideCompiled("Xamarin.Forms.Core.XamlC.TypeTypeConverter")]
	[TypeConversion(typeof(Type))]
	public sealed class TypeTypeConverter : TypeConverter, IExtendedTypeConverter
	{
		object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException(nameof(serviceProvider));
			if (!(serviceProvider.GetService(typeof(IXamlTypeResolver)) is IXamlTypeResolver typeResolver))
				throw new ArgumentException("No IXamlTypeResolver in IServiceProvider");

			return typeResolver.Resolve(value, serviceProvider);
		}

		public override object ConvertFromInvariantString(string value) => throw new NotImplementedException();

		public override string ConvertToInvariantString(object value) => throw new NotSupportedException();
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class ObservableAndEnumerable
	{
		public async Task Snippet()
		{
			var enumerable = Enumerable.Range(0, 100)
				.Where(n => n % 2 == 0)
				.Select(n => n * n);

			var observable = Observable.Range(0, 100)
				.Where(n => n % 2 == 0)
				.Select(n => n * n);

			foreach (var n in enumerable)
				Console.WriteLine(n);

			observable.Subscribe(n => Console.WriteLine(n));
			await observable.ForEachAsync(n => Console.WriteLine(n));
		}
	}
}

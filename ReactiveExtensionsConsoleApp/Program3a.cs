using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class Program3a
	{
		static void Main(string[] args)
		{
			IObservable<DateTime> timeSequence = Observable
				.Interval(TimeSpan.FromMinutes(1))
				.Select(_ => DateTime.Now);

			Task t = timeSequence.ForEachAsync(now => Console.WriteLine(now));

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();

		}
		
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class Program3
	{
		static void Main()
		{
			var t = new System.Timers.Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
			t.Elapsed += (sender, e) =>
			{
				Console.WriteLine("The time is now: " + DateTime.Now);
			};
			t.Start();

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
		}

	}
}

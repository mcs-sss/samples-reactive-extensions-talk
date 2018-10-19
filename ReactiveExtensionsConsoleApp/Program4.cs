using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class Program4
	{
		static void Main(string[] args)
		{
			Task t = new TemperatureSensor().IObservableExampleRollingMaximum();

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();
			
		}
	}
}

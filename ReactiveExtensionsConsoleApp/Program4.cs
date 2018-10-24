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
			Task t = MainAsync();

			Console.WriteLine("Press enter to exit");
			Console.ReadLine();

		}

		private static async Task MainAsync()
		{
			TemperatureSensor temperatureSensor = new TemperatureSensor();

			Console.WriteLine(nameof(temperatureSensor.IEnumerableExample));
			temperatureSensor.IEnumerableExample();

			Console.WriteLine(nameof(temperatureSensor.IObservableExample));
			await temperatureSensor.IObservableExample();

			Console.WriteLine(nameof(temperatureSensor.IObservableExampleRollingMaximum));
			await temperatureSensor.IObservableExampleRollingMaximum();
		}
	}
}

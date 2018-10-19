using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	public class TemperatureSensor
	{
		float[] Temperatures { get; } = new float[] { 65, 68, 66, 72, 70, 71, 75, 70, 68 };

		public void IEnumerableExample()
		{
			IEnumerable<float> temperatureReadings = Temperatures;
			foreach (float reading in temperatureReadings)
				Console.WriteLine("Reading: " + reading);
		}

		public async Task IObservableExample()
		{
			IObservable<float> temperatureReadings = Temperatures.ToObservable();

			await temperatureReadings.ForEachAsync(reading =>
				Console.WriteLine("Reading: " + reading)
			);

			//note that this iterates the sequence again
			float max = await temperatureReadings.Max();
			Console.WriteLine("Maximum: " + max);
		}

		public async Task IObservableExampleRollingMaximum()
		{
			IObservable<float> temperatureReadings = Temperatures.ToObservable();

			IObservable<float> rollingMaximum = temperatureReadings
				.Scan((accumulated, next) => Math.Max(accumulated, next))
				.DistinctUntilChanged();

			await rollingMaximum.ForEachAsync(reading =>
				Console.WriteLine("New maximum: " + reading)
			);
		}


	}
}

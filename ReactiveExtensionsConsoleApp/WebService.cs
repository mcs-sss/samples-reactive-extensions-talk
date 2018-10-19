using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class WebService
	{
		async Task ReadFromWebAsync()
		{
			string url = String.Empty;

			IObservable<string> lineSource = CreateObservableForLines(url);

			await lineSource.ForEachAsync(line => Console.WriteLine(line));
		}

		private static IObservable<string> CreateObservableForLines(string url)
		{
			return Observable.Create<string>(async (IObserver<string> observer, CancellationToken ct) =>
			{
				using (var client = new HttpClient())
				{
					using (var response = await client.GetAsync(url, ct))
					{
						using (var stream = await response.Content.ReadAsStreamAsync())
						{
							using (var streamReader = new StreamReader(stream))
							{
								while (!streamReader.EndOfStream && !ct.IsCancellationRequested)
								{
									string line = await streamReader.ReadLineAsync();
									observer.OnNext(line);
								}
							}
						}
					}
				}
			});
		}
	}
}

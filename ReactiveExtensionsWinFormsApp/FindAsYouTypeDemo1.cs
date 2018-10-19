using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveExtensionsWinFormsApp
{
	public partial class FindAsYouTypeDemo1 : StatusBarExample
	{
		
		public FindAsYouTypeDemo1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			IObservable<string> queries = CreateQueriesObservable();
			IObservable<IObservable<string>> results = queries.Select(q => GetSearchResults(q));

			Subscribe(results);

		}

		protected IObservable<string> CreateQueriesObservable()
		{
			return Observable.FromEventPattern(
					handler => textBoxSearchQuery.TextChanged += handler,
					handler => textBoxSearchQuery.TextChanged -= handler
				)
				.Select(eventInfo => textBoxSearchQuery.Text)
				.Throttle(TimeSpan.FromSeconds(.5));
		}

		private IObservable<string> GetSearchResults(string queryText)
		{
			//simply return each letter in the string as a result, with an artificial delay
			return Observable.Create<string>(async (observer, cancel) =>
			{
				var results = queryText
					.AsEnumerable()
					.Select((c, i) => String.Format("Letter [{0}]: '{1}'", i, c));

				foreach (string result in results)
				{
					await Task.Delay(TimeSpan.FromSeconds(.25), cancel);
					observer.OnNext(result);
				}
			});
		}

		private IObservable<string> GetSearchResults2(string q)
		{
			//simply return each letter in the string as a result
			return q.AsEnumerable()
				.ToObservable()
				.Select((c, i) => Observable.FromAsync(async cancel =>
				{
					await Task.Delay(TimeSpan.FromSeconds(.25), cancel);
					return String.Format("Letter [{0}]: '{1}'", i, c);
				})
				).Concat();
		}

		protected virtual void Subscribe(IObservable<IObservable<string>> resultSets)
		{
			resultSets
				.ObserveOn(listBoxResults)
				.Subscribe(newResultSet =>
				{
					listBoxResults.Items.Clear();
					newResultSet
						.ObserveOn(listBoxResults)
						.Subscribe(result =>
						{
							listBoxResults.Items.Add(result);
						});
				});
		}

		

	}
}

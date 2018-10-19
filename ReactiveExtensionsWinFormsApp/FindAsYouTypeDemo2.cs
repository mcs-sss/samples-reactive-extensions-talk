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
	public partial class FindAsYouTypeDemo2 : FindAsYouTypeDemo1
	{
		public FindAsYouTypeDemo2()
		{
			InitializeComponent();
		}

		protected override void Subscribe(IObservable<IObservable<string>> resultSets)
		{
			Subscribe2(resultSets);
		}

		private void Subscribe1(IObservable<IObservable<string>> resultSets)
		{
			resultSets
				.ObserveOn(listBoxResults)
				.Do(resultSet => listBoxResults.Items.Clear())
				.Select(resultSet => resultSet.Buffer(TimeSpan.FromSeconds(1), 10))
				.Switch()
				.ObserveOn(listBoxResults)
				.Subscribe(results =>
				{
					foreach (string result in results)
						listBoxResults.Items.Add(result);
				});
		}

		private void Subscribe2(IObservable<IObservable<string>> resultSets)
		{
			var resultSetsMultiple = resultSets
				.Publish()
				.RefCount();

			resultSetsMultiple
				.ObserveOn(listBoxResults)
				.Subscribe(resultSet => listBoxResults.Items.Clear());

			resultSetsMultiple
				.Select(resultSet => resultSet.Buffer(TimeSpan.FromSeconds(1), 10))
				.Switch()
				.ObserveOn(listBoxResults)
				.Subscribe(results =>
				{
					foreach (string result in results)
						listBoxResults.Items.Add(result);
				});
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	class ObservableCreateExample
	{
		private static IObservable<int> CreateObservableForNumbers()
		{
			return Observable.Create<int>((IObserver<int> observer) => {
				observer.OnNext(1);
				observer.OnNext(2);

				for (int i = 3; i <= 10; i++)
				{
					observer.OnNext(i);
				}

				return Disposable.Empty;
			});
		}
	}
}

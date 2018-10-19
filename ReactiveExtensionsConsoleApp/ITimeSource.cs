using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsConsoleApp
{
	interface ITimeSource
	{
		event EventHandler<TimeAvailableEventArgs> TimeAvailable;
	}

	class TimeAvailableEventArgs : EventArgs
	{
		public DateTime CurrentTime
		{
			get;
		}
	}

	interface ITimeSource2
	{
		void SetHandler(Action<DateTime> timeAvailableAction);
	}

}

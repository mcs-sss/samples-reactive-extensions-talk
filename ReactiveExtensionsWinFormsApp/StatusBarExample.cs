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
	public partial class StatusBarExample : Form
	{
		public StatusBarExample()
		{
			Font =  SystemFonts.DialogFont;

			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			IObservable<string> mousePositions = CreateMousePositionObservable()
				//note that if I'm going to do logic to generate text, it's better to put it in the Observable itself so it can be tested!
				.Select(p => String.Format("{0} @ {1}", p.ToString(), DateTime.Now))
				//also that lets us start with a blank label easily!
				.StartWith(String.Empty);

			mousePositions.Subscribe(text => this.toolStripStatusLabel1.Text = text);
		}

		private IObservable<Point> CreateMousePositionObservable()
		{
			return Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
				handler => this.MouseMove += handler,
				handler => this.MouseMove -= handler
			).Select(eventInfo => eventInfo.EventArgs.Location)

			.Sample(TimeSpan.FromSeconds(1));
			//.Throttle(TimeSpan.FromSeconds(.5));

		}
	}
}

namespace ReactiveExtensionsWinFormsApp
{
	partial class FindAsYouTypeDemo1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxSearchQuery = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.listBoxResults = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search for:";
			// 
			// textBoxSearchQuery
			// 
			this.textBoxSearchQuery.Location = new System.Drawing.Point(13, 30);
			this.textBoxSearchQuery.Name = "textBoxSearchQuery";
			this.textBoxSearchQuery.Size = new System.Drawing.Size(167, 20);
			this.textBoxSearchQuery.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Results:";
			// 
			// listBoxResults
			// 
			this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxResults.FormattingEnabled = true;
			this.listBoxResults.Location = new System.Drawing.Point(12, 73);
			this.listBoxResults.Name = "listBoxResults";
			this.listBoxResults.Size = new System.Drawing.Size(712, 329);
			this.listBoxResults.TabIndex = 3;
			// 
			// FindAsYouTypeDemo1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 445);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.listBoxResults);
			this.Controls.Add(this.textBoxSearchQuery);
			this.Controls.Add(this.label1);
			this.Name = "FindAsYouTypeDemo1";
			this.Text = "FindAsYouTypeDemo1";
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.textBoxSearchQuery, 0);
			this.Controls.SetChildIndex(this.listBoxResults, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxSearchQuery;
		private System.Windows.Forms.Label label2;
		protected System.Windows.Forms.ListBox listBoxResults;
	}
}


namespace LiveSplit.UI.Components {
	partial class RaceSettings {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.layout = new System.Windows.Forms.TableLayoutPanel();
			this.grpText = new System.Windows.Forms.GroupBox();
			this.layout2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnTextColor = new System.Windows.Forms.Button();
			this.chkOverrideTextColor = new System.Windows.Forms.CheckBox();
			this.lblColor = new System.Windows.Forms.Label();
			this.grpTime = new System.Windows.Forms.GroupBox();
			this.layout3 = new System.Windows.Forms.TableLayoutPanel();
			this.grpAccuracy = new System.Windows.Forms.GroupBox();
			this.layout5 = new System.Windows.Forms.TableLayoutPanel();
			this.rdoSeconds = new System.Windows.Forms.RadioButton();
			this.rdoTenths = new System.Windows.Forms.RadioButton();
			this.rdoHundredths = new System.Windows.Forms.RadioButton();
			this.grpColor = new System.Windows.Forms.GroupBox();
			this.layout4 = new System.Windows.Forms.TableLayoutPanel();
			this.btnTimeColor = new System.Windows.Forms.Button();
			this.chkOverrideTimeColor = new System.Windows.Forms.CheckBox();
			this.lblColorOverride = new System.Windows.Forms.Label();
			this.cboGradientType = new System.Windows.Forms.ComboBox();
			this.btnColor2 = new System.Windows.Forms.Button();
			this.btnColor1 = new System.Windows.Forms.Button();
			this.lblBackgroundColor = new System.Windows.Forms.Label();
			this.lblRacers = new System.Windows.Forms.Label();
			this.numRacers = new System.Windows.Forms.NumericUpDown();
			this.lblComparison = new System.Windows.Forms.Label();
			this.cboComparison = new System.Windows.Forms.ComboBox();
			this.layout.SuspendLayout();
			this.grpText.SuspendLayout();
			this.layout2.SuspendLayout();
			this.grpTime.SuspendLayout();
			this.layout3.SuspendLayout();
			this.grpAccuracy.SuspendLayout();
			this.layout5.SuspendLayout();
			this.grpColor.SuspendLayout();
			this.layout4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRacers)).BeginInit();
			this.SuspendLayout();
			// 
			// layout
			// 
			this.layout.ColumnCount = 4;
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout.Controls.Add(this.grpText, 0, 3);
			this.layout.Controls.Add(this.grpTime, 0, 4);
			this.layout.Controls.Add(this.cboGradientType, 3, 2);
			this.layout.Controls.Add(this.btnColor2, 2, 2);
			this.layout.Controls.Add(this.btnColor1, 1, 2);
			this.layout.Controls.Add(this.lblBackgroundColor, 0, 2);
			this.layout.Controls.Add(this.lblRacers, 0, 0);
			this.layout.Controls.Add(this.numRacers, 3, 0);
			this.layout.Controls.Add(this.lblComparison, 0, 1);
			this.layout.Controls.Add(this.cboComparison, 3, 1);
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(7, 7);
			this.layout.Name = "layout";
			this.layout.RowCount = 5;
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
			this.layout.Size = new System.Drawing.Size(462, 324);
			this.layout.TabIndex = 0;
			// 
			// grpText
			// 
			this.layout.SetColumnSpan(this.grpText, 4);
			this.grpText.Controls.Add(this.layout2);
			this.grpText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpText.Location = new System.Drawing.Point(3, 87);
			this.grpText.Name = "grpText";
			this.grpText.Size = new System.Drawing.Size(456, 77);
			this.grpText.TabIndex = 8;
			this.grpText.TabStop = false;
			this.grpText.Text = "Text";
			// 
			// layout2
			// 
			this.layout2.ColumnCount = 3;
			this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
			this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
			this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
			this.layout2.Controls.Add(this.btnTextColor, 1, 1);
			this.layout2.Controls.Add(this.chkOverrideTextColor, 0, 0);
			this.layout2.Controls.Add(this.lblColor, 0, 1);
			this.layout2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout2.Location = new System.Drawing.Point(3, 16);
			this.layout2.Name = "layout2";
			this.layout2.RowCount = 2;
			this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.layout2.Size = new System.Drawing.Size(450, 58);
			this.layout2.TabIndex = 0;
			// 
			// btnTextColor
			// 
			this.btnTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnTextColor.Location = new System.Drawing.Point(156, 32);
			this.btnTextColor.Name = "btnTextColor";
			this.btnTextColor.Size = new System.Drawing.Size(23, 23);
			this.btnTextColor.TabIndex = 2;
			this.btnTextColor.UseVisualStyleBackColor = false;
			this.btnTextColor.Click += new System.EventHandler(this.ColorButtonClick);
			// 
			// chkOverrideTextColor
			// 
			this.chkOverrideTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chkOverrideTextColor.AutoSize = true;
			this.layout2.SetColumnSpan(this.chkOverrideTextColor, 3);
			this.chkOverrideTextColor.Location = new System.Drawing.Point(7, 6);
			this.chkOverrideTextColor.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
			this.chkOverrideTextColor.Name = "chkOverrideTextColor";
			this.chkOverrideTextColor.Size = new System.Drawing.Size(440, 17);
			this.chkOverrideTextColor.TabIndex = 0;
			this.chkOverrideTextColor.Text = "Override Layout Settings";
			this.chkOverrideTextColor.UseVisualStyleBackColor = true;
			this.chkOverrideTextColor.CheckedChanged += new System.EventHandler(this.chkOverrideTextColor_CheckedChanged);
			// 
			// lblColor
			// 
			this.lblColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColor.AutoSize = true;
			this.lblColor.Location = new System.Drawing.Point(3, 37);
			this.lblColor.Name = "lblColor";
			this.lblColor.Size = new System.Drawing.Size(147, 13);
			this.lblColor.TabIndex = 1;
			this.lblColor.Text = "Color:";
			// 
			// grpTime
			// 
			this.layout.SetColumnSpan(this.grpTime, 4);
			this.grpTime.Controls.Add(this.layout3);
			this.grpTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpTime.Location = new System.Drawing.Point(3, 170);
			this.grpTime.Name = "grpTime";
			this.grpTime.Size = new System.Drawing.Size(456, 151);
			this.grpTime.TabIndex = 9;
			this.grpTime.TabStop = false;
			this.grpTime.Text = "Time";
			// 
			// layout3
			// 
			this.layout3.ColumnCount = 2;
			this.layout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.layout3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.layout3.Controls.Add(this.grpAccuracy, 0, 1);
			this.layout3.Controls.Add(this.grpColor, 0, 0);
			this.layout3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout3.Location = new System.Drawing.Point(3, 16);
			this.layout3.Name = "layout3";
			this.layout3.RowCount = 2;
			this.layout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
			this.layout3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
			this.layout3.Size = new System.Drawing.Size(450, 132);
			this.layout3.TabIndex = 0;
			// 
			// grpAccuracy
			// 
			this.layout3.SetColumnSpan(this.grpAccuracy, 2);
			this.grpAccuracy.Controls.Add(this.layout5);
			this.grpAccuracy.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpAccuracy.Location = new System.Drawing.Point(3, 86);
			this.grpAccuracy.Name = "grpAccuracy";
			this.grpAccuracy.Size = new System.Drawing.Size(444, 43);
			this.grpAccuracy.TabIndex = 1;
			this.grpAccuracy.TabStop = false;
			this.grpAccuracy.Text = "Accuracy";
			// 
			// layout5
			// 
			this.layout5.ColumnCount = 3;
			this.layout5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.layout5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.layout5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.layout5.Controls.Add(this.rdoSeconds, 0, 0);
			this.layout5.Controls.Add(this.rdoTenths, 1, 0);
			this.layout5.Controls.Add(this.rdoHundredths, 2, 0);
			this.layout5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout5.Location = new System.Drawing.Point(3, 16);
			this.layout5.Name = "layout5";
			this.layout5.RowCount = 1;
			this.layout5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.layout5.Size = new System.Drawing.Size(438, 24);
			this.layout5.TabIndex = 0;
			// 
			// rdoSeconds
			// 
			this.rdoSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rdoSeconds.AutoSize = true;
			this.rdoSeconds.Location = new System.Drawing.Point(3, 3);
			this.rdoSeconds.Name = "rdoSeconds";
			this.rdoSeconds.Size = new System.Drawing.Size(140, 17);
			this.rdoSeconds.TabIndex = 0;
			this.rdoSeconds.TabStop = true;
			this.rdoSeconds.Text = "Seconds";
			this.rdoSeconds.UseVisualStyleBackColor = true;
			this.rdoSeconds.CheckedChanged += new System.EventHandler(this.rdoSeconds_CheckedChanged);
			// 
			// rdoTenths
			// 
			this.rdoTenths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rdoTenths.AutoSize = true;
			this.rdoTenths.Location = new System.Drawing.Point(149, 3);
			this.rdoTenths.Name = "rdoTenths";
			this.rdoTenths.Size = new System.Drawing.Size(140, 17);
			this.rdoTenths.TabIndex = 1;
			this.rdoTenths.TabStop = true;
			this.rdoTenths.Text = "Tenths";
			this.rdoTenths.UseVisualStyleBackColor = true;
			// 
			// rdoHundredths
			// 
			this.rdoHundredths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rdoHundredths.AutoSize = true;
			this.rdoHundredths.Location = new System.Drawing.Point(295, 3);
			this.rdoHundredths.Name = "rdoHundredths";
			this.rdoHundredths.Size = new System.Drawing.Size(140, 17);
			this.rdoHundredths.TabIndex = 2;
			this.rdoHundredths.TabStop = true;
			this.rdoHundredths.Text = "Hundredths";
			this.rdoHundredths.UseVisualStyleBackColor = true;
			this.rdoHundredths.CheckedChanged += new System.EventHandler(this.rdoHundredths_CheckedChanged);
			// 
			// grpColor
			// 
			this.layout3.SetColumnSpan(this.grpColor, 2);
			this.grpColor.Controls.Add(this.layout4);
			this.grpColor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpColor.Location = new System.Drawing.Point(3, 3);
			this.grpColor.Name = "grpColor";
			this.grpColor.Size = new System.Drawing.Size(444, 77);
			this.grpColor.TabIndex = 0;
			this.grpColor.TabStop = false;
			this.grpColor.Text = "Color";
			// 
			// layout4
			// 
			this.layout4.ColumnCount = 3;
			this.layout4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
			this.layout4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
			this.layout4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
			this.layout4.Controls.Add(this.btnTimeColor, 1, 1);
			this.layout4.Controls.Add(this.chkOverrideTimeColor, 0, 0);
			this.layout4.Controls.Add(this.lblColorOverride, 0, 1);
			this.layout4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout4.Location = new System.Drawing.Point(3, 16);
			this.layout4.Name = "layout4";
			this.layout4.RowCount = 2;
			this.layout4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.layout4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.layout4.Size = new System.Drawing.Size(438, 58);
			this.layout4.TabIndex = 0;
			// 
			// btnTimeColor
			// 
			this.btnTimeColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnTimeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnTimeColor.Location = new System.Drawing.Point(150, 32);
			this.btnTimeColor.Name = "btnTimeColor";
			this.btnTimeColor.Size = new System.Drawing.Size(23, 23);
			this.btnTimeColor.TabIndex = 2;
			this.btnTimeColor.UseVisualStyleBackColor = false;
			this.btnTimeColor.Click += new System.EventHandler(this.ColorButtonClick);
			// 
			// chkOverrideTimeColor
			// 
			this.chkOverrideTimeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.chkOverrideTimeColor.AutoSize = true;
			this.layout4.SetColumnSpan(this.chkOverrideTimeColor, 2);
			this.chkOverrideTimeColor.Location = new System.Drawing.Point(7, 6);
			this.chkOverrideTimeColor.Margin = new System.Windows.Forms.Padding(7, 3, 3, 3);
			this.chkOverrideTimeColor.Name = "chkOverrideTimeColor";
			this.chkOverrideTimeColor.Size = new System.Drawing.Size(234, 17);
			this.chkOverrideTimeColor.TabIndex = 0;
			this.chkOverrideTimeColor.Text = "Override Layout Settings";
			this.chkOverrideTimeColor.UseVisualStyleBackColor = true;
			this.chkOverrideTimeColor.CheckedChanged += new System.EventHandler(this.chkOverrideTimeColor_CheckedChanged);
			// 
			// lblColorOverride
			// 
			this.lblColorOverride.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblColorOverride.AutoSize = true;
			this.lblColorOverride.Location = new System.Drawing.Point(3, 37);
			this.lblColorOverride.Name = "lblColorOverride";
			this.lblColorOverride.Size = new System.Drawing.Size(141, 13);
			this.lblColorOverride.TabIndex = 1;
			this.lblColorOverride.Text = "Color:";
			// 
			// cboGradientType
			// 
			this.cboGradientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cboGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboGradientType.FormattingEnabled = true;
			this.cboGradientType.Items.AddRange(new object[] {
            "Plain",
            "Vertical",
            "Horizontal",
            "Alternating"});
			this.cboGradientType.Location = new System.Drawing.Point(220, 59);
			this.cboGradientType.Name = "cboGradientType";
			this.cboGradientType.Size = new System.Drawing.Size(239, 21);
			this.cboGradientType.TabIndex = 7;
			this.cboGradientType.SelectedIndexChanged += new System.EventHandler(this.cmbGradientType_SelectedIndexChanged);
			// 
			// btnColor2
			// 
			this.btnColor2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnColor2.Location = new System.Drawing.Point(191, 59);
			this.btnColor2.Name = "btnColor2";
			this.btnColor2.Size = new System.Drawing.Size(23, 22);
			this.btnColor2.TabIndex = 6;
			this.btnColor2.UseVisualStyleBackColor = false;
			this.btnColor2.Click += new System.EventHandler(this.ColorButtonClick);
			// 
			// btnColor1
			// 
			this.btnColor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnColor1.Location = new System.Drawing.Point(162, 59);
			this.btnColor1.Name = "btnColor1";
			this.btnColor1.Size = new System.Drawing.Size(23, 22);
			this.btnColor1.TabIndex = 5;
			this.btnColor1.UseVisualStyleBackColor = false;
			this.btnColor1.Click += new System.EventHandler(this.ColorButtonClick);
			// 
			// lblBackgroundColor
			// 
			this.lblBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblBackgroundColor.AutoSize = true;
			this.lblBackgroundColor.Location = new System.Drawing.Point(3, 63);
			this.lblBackgroundColor.Name = "lblBackgroundColor";
			this.lblBackgroundColor.Size = new System.Drawing.Size(153, 13);
			this.lblBackgroundColor.TabIndex = 4;
			this.lblBackgroundColor.Text = "Background Color:";
			// 
			// lblRacers
			// 
			this.lblRacers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRacers.AutoSize = true;
			this.lblRacers.Location = new System.Drawing.Point(3, 7);
			this.lblRacers.Name = "lblRacers";
			this.lblRacers.Size = new System.Drawing.Size(153, 13);
			this.lblRacers.TabIndex = 0;
			this.lblRacers.Text = "Racers:";
			// 
			// numRacers
			// 
			this.numRacers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.numRacers.Location = new System.Drawing.Point(220, 4);
			this.numRacers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numRacers.Name = "numRacers";
			this.numRacers.Size = new System.Drawing.Size(239, 20);
			this.numRacers.TabIndex = 1;
			this.numRacers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// lblComparison
			// 
			this.lblComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblComparison.AutoSize = true;
			this.lblComparison.Location = new System.Drawing.Point(3, 35);
			this.lblComparison.Name = "lblComparison";
			this.lblComparison.Size = new System.Drawing.Size(153, 13);
			this.lblComparison.TabIndex = 2;
			this.lblComparison.Text = "Compare Against:";
			// 
			// cboComparison
			// 
			this.cboComparison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cboComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboComparison.FormattingEnabled = true;
			this.cboComparison.Items.AddRange(new object[] {
            "First",
            "Yourself"});
			this.cboComparison.Location = new System.Drawing.Point(220, 31);
			this.cboComparison.Name = "cboComparison";
			this.cboComparison.Size = new System.Drawing.Size(239, 21);
			this.cboComparison.TabIndex = 3;
			this.cboComparison.SelectedIndexChanged += new System.EventHandler(this.cboComparison_SelectedIndexChanged);
			// 
			// RaceSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.layout);
			this.Name = "RaceSettings";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.Size = new System.Drawing.Size(476, 338);
			this.Load += new System.EventHandler(this.Settings_Load);
			this.layout.ResumeLayout(false);
			this.layout.PerformLayout();
			this.grpText.ResumeLayout(false);
			this.layout2.ResumeLayout(false);
			this.layout2.PerformLayout();
			this.grpTime.ResumeLayout(false);
			this.layout3.ResumeLayout(false);
			this.grpAccuracy.ResumeLayout(false);
			this.layout5.ResumeLayout(false);
			this.layout5.PerformLayout();
			this.grpColor.ResumeLayout(false);
			this.layout4.ResumeLayout(false);
			this.layout4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numRacers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel layout;
		private System.Windows.Forms.GroupBox grpText;
		private System.Windows.Forms.TableLayoutPanel layout2;
		private System.Windows.Forms.Button btnTextColor;
		private System.Windows.Forms.CheckBox chkOverrideTextColor;
		private System.Windows.Forms.Label lblColor;
		private System.Windows.Forms.GroupBox grpTime;
		private System.Windows.Forms.TableLayoutPanel layout3;
		private System.Windows.Forms.GroupBox grpColor;
		private System.Windows.Forms.TableLayoutPanel layout4;
		private System.Windows.Forms.Button btnTimeColor;
		private System.Windows.Forms.CheckBox chkOverrideTimeColor;
		private System.Windows.Forms.Label lblColorOverride;
		private System.Windows.Forms.GroupBox grpAccuracy;
		private System.Windows.Forms.TableLayoutPanel layout5;
		private System.Windows.Forms.RadioButton rdoSeconds;
		private System.Windows.Forms.RadioButton rdoTenths;
		private System.Windows.Forms.RadioButton rdoHundredths;
		private System.Windows.Forms.ComboBox cboGradientType;
		private System.Windows.Forms.Button btnColor2;
		private System.Windows.Forms.Button btnColor1;
		private System.Windows.Forms.Label lblBackgroundColor;
		private System.Windows.Forms.Label lblRacers;
		private System.Windows.Forms.NumericUpDown numRacers;
		private System.Windows.Forms.Label lblComparison;
		private System.Windows.Forms.ComboBox cboComparison;
	}
}
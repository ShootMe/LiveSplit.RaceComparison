using LiveSplit.TimeFormatters;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
namespace LiveSplit.UI.Components {
	public enum ExtendedGradientType {
		Plain,
		Vertical,
		Horizontal,
		Alternating
	}
	public enum RacerComparison {
		First,
		Yourself
	}
	public partial class RaceSettings : UserControl {
		public Color TextColor { get; set; }
		public bool OverrideTextColor { get; set; }
		public Color TimeColor { get; set; }
		public bool OverrideTimeColor { get; set; }
		public int RacerCount { get; set; }
		public TimeAccuracy Accuracy { get; set; }
		public Color BackgroundColor { get; set; }
		public Color BackgroundColor2 { get; set; }
		public RacerComparison CompareAgainst { get; set; }
		public string CompareString {
			get { return CompareAgainst.ToString(); }
			set { CompareAgainst = (RacerComparison)Enum.Parse(typeof(RacerComparison), value); }
		}
		public ExtendedGradientType BackgroundGradient { get; set; }
		public string GradientString {
			get { return BackgroundGradient.ToString(); }
			set { BackgroundGradient = (ExtendedGradientType)Enum.Parse(typeof(ExtendedGradientType), value); }
		}
		public LayoutMode Mode { get; set; }

		public RaceSettings() {
			InitializeComponent();

			TextColor = Color.FromArgb(255, 255, 255);
			OverrideTextColor = false;
			TimeColor = Color.FromArgb(255, 255, 255);
			OverrideTimeColor = false;
			RacerCount = 2;
			Accuracy = TimeAccuracy.Tenths;
			BackgroundColor = Color.Transparent;
			BackgroundColor2 = Color.Transparent;
			BackgroundGradient = ExtendedGradientType.Plain;
			CompareAgainst = RacerComparison.First;

			chkOverrideTextColor.DataBindings.Add("Checked", this, "OverrideTextColor", false, DataSourceUpdateMode.OnPropertyChanged);
			btnTextColor.DataBindings.Add("BackColor", this, "TextColor", false, DataSourceUpdateMode.OnPropertyChanged);
			chkOverrideTimeColor.DataBindings.Add("Checked", this, "OverrideTimeColor", false, DataSourceUpdateMode.OnPropertyChanged);
			btnTimeColor.DataBindings.Add("BackColor", this, "TimeColor", false, DataSourceUpdateMode.OnPropertyChanged);
			btnColor1.DataBindings.Add("BackColor", this, "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
			btnColor2.DataBindings.Add("BackColor", this, "BackgroundColor2", false, DataSourceUpdateMode.OnPropertyChanged);
			cboGradientType.DataBindings.Add("SelectedItem", this, "GradientString", false, DataSourceUpdateMode.OnPropertyChanged);
			cboComparison.DataBindings.Add("SelectedItem", this, "CompareString", false, DataSourceUpdateMode.OnPropertyChanged);
			numRacers.DataBindings.Add("Value", this, "RacerCount", false, DataSourceUpdateMode.OnPropertyChanged);
		}
		private void chkOverrideTimeColor_CheckedChanged(object sender, EventArgs e) {
			lblColorOverride.Enabled = btnTimeColor.Enabled = chkOverrideTimeColor.Checked;
		}
		private void chkOverrideTextColor_CheckedChanged(object sender, EventArgs e) {
			lblColor.Enabled = btnTextColor.Enabled = chkOverrideTextColor.Checked;
		}
		private void Settings_Load(object sender, EventArgs e) {
			chkOverrideTextColor_CheckedChanged(null, null);
			chkOverrideTimeColor_CheckedChanged(null, null);
			rdoSeconds.Checked = Accuracy == TimeAccuracy.Seconds;
			rdoTenths.Checked = Accuracy == TimeAccuracy.Tenths;
			rdoHundredths.Checked = Accuracy == TimeAccuracy.Hundredths;
		}
		private void cmbGradientType_SelectedIndexChanged(object sender, EventArgs e) {
			btnColor1.Visible = cboGradientType.SelectedItem.ToString() != "Plain";
			btnColor2.DataBindings.Clear();
			btnColor2.DataBindings.Add("BackColor", this, btnColor1.Visible ? "BackgroundColor2" : "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
			GradientString = cboGradientType.SelectedItem.ToString();
		}
		private void cboComparison_SelectedIndexChanged(object sender, EventArgs e) {
			CompareString = cboComparison.SelectedItem.ToString();
		}
		private void rdoHundredths_CheckedChanged(object sender, EventArgs e) {
			UpdateAccuracy();
		}
		private void rdoSeconds_CheckedChanged(object sender, EventArgs e) {
			UpdateAccuracy();
		}
		private void UpdateAccuracy() {
			if (rdoSeconds.Checked) {
				Accuracy = TimeAccuracy.Seconds;
			} else if (rdoTenths.Checked) {
				Accuracy = TimeAccuracy.Tenths;
			} else {
				Accuracy = TimeAccuracy.Hundredths;
			}
		}
		public void SetSettings(XmlNode node) {
			var element = (XmlElement)node;
			TextColor = SettingsHelper.ParseColor(element["TextColor"]);
			OverrideTextColor = SettingsHelper.ParseBool(element["OverrideTextColor"]);
			TimeColor = SettingsHelper.ParseColor(element["TimeColor"]);
			RacerCount = SettingsHelper.ParseInt(element["RacerCount"]);
			OverrideTimeColor = SettingsHelper.ParseBool(element["OverrideTimeColor"]);
			Accuracy = SettingsHelper.ParseEnum<TimeAccuracy>(element["Accuracy"]);
			BackgroundColor = SettingsHelper.ParseColor(element["BackgroundColor"]);
			BackgroundColor2 = SettingsHelper.ParseColor(element["BackgroundColor2"]);
			GradientString = SettingsHelper.ParseString(element["BackgroundGradient"]);
			CompareString = SettingsHelper.ParseString(element["CompareAgainst"]);
		}
		public XmlNode GetSettings(XmlDocument document) {
			var parent = document.CreateElement("Settings");
			CreateSettingsNode(document, parent);
			return parent;
		}
		public int GetSettingsHashCode() {
			return CreateSettingsNode(null, null);
		}
		private int CreateSettingsNode(XmlDocument document, XmlElement parent) {
			return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
			SettingsHelper.CreateSetting(document, parent, "TextColor", TextColor) ^
			SettingsHelper.CreateSetting(document, parent, "OverrideTextColor", OverrideTextColor) ^
			SettingsHelper.CreateSetting(document, parent, "TimeColor", TimeColor) ^
			SettingsHelper.CreateSetting(document, parent, "OverrideTimeColor", OverrideTimeColor) ^
			SettingsHelper.CreateSetting(document, parent, "Accuracy", Accuracy) ^
			SettingsHelper.CreateSetting(document, parent, "BackgroundColor", BackgroundColor) ^
			SettingsHelper.CreateSetting(document, parent, "BackgroundColor2", BackgroundColor2) ^
			SettingsHelper.CreateSetting(document, parent, "RacerCount", RacerCount) ^
			SettingsHelper.CreateSetting(document, parent, "BackgroundGradient", BackgroundGradient) ^
			SettingsHelper.CreateSetting(document, parent, "CompareAgainst", CompareAgainst);
		}
		private void ColorButtonClick(object sender, EventArgs e) {
			SettingsHelper.ColorButtonClick((Button)sender, this);
		}
	}
}
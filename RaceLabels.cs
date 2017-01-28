using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace LiveSplit.UI.Components {
	public class RaceLabels : IComponent {
		public int RaceIndex { get; set; }
		public RaceComponent Parent { get; set; }
		public RaceSettings Settings { get; set; }
		public RaceSplit Split { get; set; }
		public string ComponentName => "Race Labels";
		public Control GetSettingsControl(LayoutMode mode) { throw new NotSupportedException(); }
		public void SetSettings(System.Xml.XmlNode settings) { throw new NotSupportedException(); }
		public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document) { throw new NotSupportedException(); }
		public string UpdateName { get { throw new NotSupportedException(); } }
		public string XMLURL { get { throw new NotSupportedException(); } }
		public string UpdateURL { get { throw new NotSupportedException(); } }
		public Version Version { get { throw new NotSupportedException(); } }
		protected ITimeFormatter TimeFormatter { get; set; }
		protected ITimeFormatter DeltaTimeFormatter { get; set; }
		protected TimeAccuracy CurrentAccuracy { get; set; }
		public GraphicsCache Cache { get; set; }
		private SimpleLabel RacerName { get; set; }
		private SimpleLabel RacerSplit { get; set; }
		private SimpleLabel RacerTime { get; set; }
		private SimpleLabel RacerDelta { get; set; }
		public float PaddingTop => 0f;
		public float PaddingLeft => 0f;
		public float PaddingBottom => 0f;
		public float PaddingRight => 0f;
		public float VerticalHeight { get; set; }
		public float HorizontalWidth => Math.Max(RacerName.ActualWidth, RacerSplit.ActualWidth) + Math.Max(RacerTime.ActualWidth, RacerDelta.ActualWidth) + 10;
		public float MinimumWidth { get; set; }
		public float MinimumHeight { get; set; }
		public IDictionary<string, Action> ContextMenuControls => null;
		public RaceLabels(RaceComponent component, int index, RaceSettings settings, RaceSplit split) {
			Parent = component;
			RaceIndex = index;
			Split = split;
			Settings = settings;
			MinimumHeight = 10;
			VerticalHeight = 31;

			TimeFormatter = new RegularSplitTimeFormatter(Settings.Accuracy);
			DeltaTimeFormatter = new DeltaSplitTimeFormatter(Settings.Accuracy, false);

			Cache = new GraphicsCache();
			RacerName = new SimpleLabel() {
				HorizontalAlignment = StringAlignment.Near,
				VerticalAlignment = StringAlignment.Near
			};
			RacerSplit = new SimpleLabel() {
				HorizontalAlignment = StringAlignment.Near,
				VerticalAlignment = StringAlignment.Far
			};
			RacerTime = new SimpleLabel() {
				HorizontalAlignment = StringAlignment.Far,
				VerticalAlignment = StringAlignment.Far
			};
			RacerDelta = new SimpleLabel() {
				HorizontalAlignment = StringAlignment.Far,
				VerticalAlignment = StringAlignment.Near
			};
		}

		private void DrawGeneral(Graphics g, LiveSplitState state, float width, float height, LayoutMode mode) {
			if (Settings.BackgroundGradient == ExtendedGradientType.Alternating) {
				g.FillRectangle(new SolidBrush((RaceIndex & 1) == 0 ? Settings.BackgroundColor2 : Settings.BackgroundColor), 0, 0, width, height);
			}

			if (Settings.Accuracy != CurrentAccuracy) {
				TimeFormatter = new RegularSplitTimeFormatter(Settings.Accuracy);
				DeltaTimeFormatter = new DeltaSplitTimeFormatter(Settings.Accuracy, false);
				CurrentAccuracy = Settings.Accuracy;
			}

			VerticalHeight = 1.9f * g.MeasureString("A", RacerName.Font).Height;

			RacerName.SetActualWidth(g);
			RacerName.ShadowColor = state.LayoutSettings.ShadowsColor;
			RacerName.Y = 0;
			RacerName.X = 0;
			RacerName.Height = height;
			RacerName.Width = width;
			RacerName.Font = state.LayoutSettings.TextFont;
			RacerName.HasShadow = state.LayoutSettings.DropShadows;
			RacerName.Draw(g);

			RacerSplit.SetActualWidth(g);
			RacerSplit.ShadowColor = state.LayoutSettings.ShadowsColor;
			RacerSplit.Y = 0;
			RacerSplit.X = 0;
			RacerSplit.Height = height;
			RacerSplit.Width = width;
			RacerSplit.Font = state.LayoutSettings.TextFont;
			RacerSplit.HasShadow = state.LayoutSettings.DropShadows;
			RacerSplit.Draw(g);

			RacerTime.SetActualWidth(g);
			RacerTime.ShadowColor = state.LayoutSettings.ShadowsColor;
			RacerTime.Y = 0;
			RacerTime.X = 0;
			RacerTime.Height = height;
			RacerTime.Width = width;
			RacerTime.Font = state.LayoutSettings.TextFont;
			RacerTime.HasShadow = state.LayoutSettings.DropShadows;
			RacerTime.Draw(g);

			RacerDelta.SetActualWidth(g);
			RacerDelta.ShadowColor = state.LayoutSettings.ShadowsColor;
			RacerDelta.Y = 0;
			RacerDelta.X = 0;
			RacerDelta.Height = height;
			RacerDelta.Width = width;
			RacerDelta.Font = state.LayoutSettings.TextFont;
			RacerDelta.HasShadow = state.LayoutSettings.DropShadows;
			RacerDelta.Draw(g);

			MinimumWidth = 200f;
		}
		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {
			DrawGeneral(g, state, width, VerticalHeight, LayoutMode.Vertical);
		}
		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {
			DrawGeneral(g, state, HorizontalWidth, height, LayoutMode.Horizontal);
		}
		protected void UpdateAll(LiveSplitState state) {
			if (Split == null) {
				RacerName.Text = RaceIndex + ": N/A";
				RacerSplit.Text = "";
				RacerTime.Text = TimeFormatter.Format(null);
			} else {
				RacerName.Text = RaceIndex + ": " + Split.Name;
				RacerSplit.Text = Split.SplitName + (Split.SubSplitIndex == int.MaxValue ? Split.SplitIndex == state.Run.Count - 1 ? " - Finished" : "" : " - " + Split.SubSplitIndex);
				RacerTime.Text = TimeFormatter.Format(Split.SplitTime.RealTime);
			}
			RacerName.ForeColor = Settings.TextColor;
			RacerSplit.ForeColor = Settings.TextColor;
			RacerTime.ForeColor = Settings.TextColor;

			TimeSpan? delta = null;
			Color color = state.LayoutSettings.TextColor;
			if (Split != null && Split != Parent.Comparison && Split.SplitTime.RealTime.HasValue && state.CurrentTime.RealTime.HasValue) {
				if (Split.SplitIndex == Parent.Comparison.SplitIndex && Split.SubSplitIndex == Parent.Comparison.SubSplitIndex) {
					delta = Split.SplitTime.RealTime.Value - Parent.Comparison.SplitTime.RealTime.GetValueOrDefault(state.CurrentTime.RealTime.Value);
				} else if (Split.SplitIndex > Parent.Comparison.SplitIndex || (Split.SplitIndex == Parent.Comparison.SplitIndex && Split.SubSplitIndex > Parent.Comparison.SubSplitIndex)) {
					RaceSplit history = null;
					if (Parent.Watcher.RaceSplits.TryGetValue(Split.Name + "|" + Parent.Comparison.SplitIndex + "|" + Parent.Comparison.SubSplitIndex, out history)) {
						delta = history.SplitTime.RealTime.Value - Parent.Comparison.SplitTime.RealTime.Value;
					}
				} else if (Split.SplitIndex < Parent.Comparison.SplitIndex || (Split.SplitIndex == Parent.Comparison.SplitIndex && Split.SubSplitIndex < Parent.Comparison.SubSplitIndex)) {
					RaceSplit history = null;
					if (Parent.Watcher.RaceSplits.TryGetValue(Parent.Comparison.Name + "|" + Split.SplitIndex + "|" + Split.SubSplitIndex, out history)) {
						delta = Split.SplitTime.RealTime.Value - history.SplitTime.RealTime.Value;
					}
				}
				if (delta != null) {
					if (delta.Value.Ticks < 0) {
						color = state.LayoutSettings.AheadGainingTimeColor;
					} else {
						color = state.LayoutSettings.BehindLosingTimeColor;
					}
				}
			}
			RacerDelta.Text = DeltaTimeFormatter.Format(delta);
			int currentIndex = 0;
			for (int i = 0; i < state.Run.Count; i++) {
				if (state.Run[i] == state.CurrentSplit) {
					currentIndex = i;
				}
			}
			if (currentIndex > 0) { currentIndex--; }

			RacerDelta.ForeColor = color;
		}
		public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) {
			UpdateAll(state);

			Cache.Restart();
			Cache["RacerName"] = RacerName.Text;
			Cache["RacerSplit"] = RacerSplit.Text;
			Cache["RacerTime"] = RacerTime.Text;
			Cache["RacerDelta"] = RacerDelta.Text;

			if (invalidator != null && Cache.HasChanged) {
				invalidator.Invalidate(0, 0, width, height);
			}
		}
		public void Dispose() { }
	}
	public class RegularSplitTimeFormatter : ITimeFormatter {
		public TimeAccuracy Accuracy { get; set; }
		public RegularSplitTimeFormatter(TimeAccuracy accuracy) {
			Accuracy = accuracy;
		}
		public string Format(TimeSpan? time) {
			var formatter = new RegularTimeFormatter(Accuracy);
			if (time == null) {
				return "-";
			} else {
				return formatter.Format(time);
			}
		}
	}
	public class DeltaSplitTimeFormatter : ITimeFormatter {
		public TimeAccuracy Accuracy { get; set; }
		public bool DropDecimals { get; set; }
		public DeltaSplitTimeFormatter(TimeAccuracy accuracy, bool dropDecimals) {
			Accuracy = accuracy;
			DropDecimals = dropDecimals;
		}
		public string Format(TimeSpan? time) {
			var deltaTime = new DeltaTimeFormatter();
			deltaTime.Accuracy = Accuracy;
			deltaTime.DropDecimals = DropDecimals;
			var formattedTime = deltaTime.Format(time);
			if (time == null) {
				return "-";
			} else {
				return formattedTime;
			}
		}
	}
	public enum ColumnType {
		RacerName,
		RacerSplit,
		Delta,
		SplitTime,
		DeltaorSplitTime,
		SegmentDelta,
		SegmentTime,
		SegmentDeltaorSegmentTime
	}
}
using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace LiveSplit.UI.Components {
	public class RaceComponent : IComponent {
		protected ComponentRendererComponent InternalComponent { get; set; }
		public RaceSettings Settings { get; set; }
		protected LiveSplitState CurrentState { get; set; }
		public float HorizontalWidth { get { return InternalComponent.HorizontalWidth; } }
		public float VerticalHeight { get { return InternalComponent.VerticalHeight; } }
		public float MinimumHeight { get { return InternalComponent.MinimumHeight; } }
		public float MinimumWidth { get { return InternalComponent.MinimumWidth; } }
		public float PaddingTop { get { return 0; } }
		public float PaddingLeft { get { return 0; } }
		public float PaddingBottom { get { return 0; } }
		public float PaddingRight { get { return 0; } }
		public string ComponentName => "Race Comparisons";
		public RaceWatcher Watcher = new RaceWatcher();
		public IDictionary<string, Action> ContextMenuControls => null;
		public List<IComponent> Components = new List<IComponent>();
		public RaceSplit Comparison { get; set; }
		public RaceComponent(LiveSplitState state) {
			Settings = new RaceSettings();
			Comparison = new RaceSplit();
			InternalComponent = new ComponentRendererComponent();
			InternalComponent.VisibleComponents = Components;

			CurrentState = state;
		}
		private void DrawBackground(Graphics g, LiveSplitState state, float width, float height) {
			if (Settings.BackgroundGradient != ExtendedGradientType.Alternating && (Settings.BackgroundColor.ToArgb() != Color.Transparent.ToArgb() || Settings.BackgroundGradient != ExtendedGradientType.Plain) && Settings.BackgroundColor2.ToArgb() != Color.Transparent.ToArgb()) {
				var gradientBrush = new LinearGradientBrush(
							new PointF(0, 0),
							Settings.BackgroundGradient == ExtendedGradientType.Horizontal
							? new PointF(width, 0)
							: new PointF(0, height),
							Settings.BackgroundColor,
							Settings.BackgroundGradient == ExtendedGradientType.Plain
							? Settings.BackgroundColor
							: Settings.BackgroundColor2);
				g.FillRectangle(gradientBrush, 0, 0, width, height);
			}
		}
		public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {
			DrawBackground(g, state, width, VerticalHeight);

			InternalComponent.DrawVertical(g, state, width, clipRegion);
		}
		public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {
			DrawBackground(g, state, HorizontalWidth, height);

			InternalComponent.DrawHorizontal(g, state, height, clipRegion);
		}
		public Control GetSettingsControl(LayoutMode mode) {
			Settings.Mode = mode;
			return Settings;
		}
		public void SetSettings(System.Xml.XmlNode settings) {
			Settings.SetSettings(settings);
		}
		public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document) {
			return Settings.GetSettings(document);
		}
		public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) {
			if (Settings.RacerCount != Components.Count) {
				Components.Clear();
				for (int i = 0; i < Settings.RacerCount; i++) {
					Components.Add(new RaceLabels(this, i + 1, Settings, null));
				}
			}

			if (state.Run.Count == 0) { return; }

			Watcher.CheckRace();

			List<RaceSplit> raceComparisons = new List<RaceSplit>();
			bool inRace = false;

			foreach (string comp in state.Run.Comparisons) {
				if (comp.StartsWith("[Race] ")) {
					string racerName = comp.Substring(7);
					RaceSplit split = null;
					if (!Watcher.RaceSplits.TryGetValue(racerName, out split)) {
						split = new RaceSplit() { Name = racerName, SplitIndex = -1, SplitName = string.Empty, SplitTime = new Time(), SubSplitIndex = int.MaxValue };
						Watcher.RaceSplits.Add(racerName, split);
					}
					raceComparisons.Add(split);
					inRace = true;
				}
			}

			if (Watcher.UserName != null) {
				RaceSplit split = null;
				if (!Watcher.RaceSplits.TryGetValue(Watcher.UserName, out split)) {
					split = new RaceSplit() { Name = Watcher.UserName, SplitIndex = -1, SplitName = string.Empty, SplitTime = new Time(), SubSplitIndex = int.MaxValue };
					Watcher.RaceSplits.Add(Watcher.UserName, split);
				}
				raceComparisons.Add(split);

				if (Settings.CompareAgainst == RacerComparison.Yourself) {
					Comparison = split;
				}
				inRace = true;
			}

			if (!inRace) {
				Watcher.Clear();
				Comparison.Clear();
			}

			raceComparisons.Sort(delegate (RaceSplit one, RaceSplit two) {
				return one.SplitIndex > two.SplitIndex ? -1
					: one.SplitIndex < two.SplitIndex ? 1
					: one.SubSplitIndex > two.SubSplitIndex ? -1
					: one.SubSplitIndex < two.SubSplitIndex ? 1
					: !one.SplitTime.RealTime.HasValue ? 1
					: !two.SplitTime.RealTime.HasValue ? -1
					: one.SplitTime.RealTime.Value.CompareTo(two.SplitTime.RealTime.Value);
			});

			if (Settings.CompareAgainst == RacerComparison.First && raceComparisons.Count > 0) {
				Comparison = raceComparisons[0];
			}

			for (int i = 0; i < Settings.RacerCount; i++) {
				RaceLabels labels = Components[i] as RaceLabels;
				if (i < raceComparisons.Count) {
					labels.Split = raceComparisons[i];
				} else {
					labels.Split = null;
				}
			}

			InternalComponent.Update(invalidator, state, width, height, mode);
		}
		public void Dispose() { }
		public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
		public ISegment GetSplit(string name) {
			for (int i = 0; i < CurrentState.Run.Count; i++) {
				if (CurrentState.Run[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase)) {
					return CurrentState.Run[i];
				}
			}
			return null;
		}
	}
}
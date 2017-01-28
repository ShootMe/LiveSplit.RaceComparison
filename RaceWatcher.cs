using IrcDotNet;
using LiveSplit.Model;
using LiveSplit.TimeFormatters;
using LiveSplit.View;
using LiveSplit.Web.SRL;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
namespace LiveSplit.UI.Components {
	public class RaceWatcher {
		private SpeedRunsLiveIRC raceIRC = null;
		private IrcChannel liveSplitChannel = null;
		private IrcClient raceClient = null;
		private SpeedRunsLiveForm srl = null;
		private RegularTimeFormatter timeFormatter = new RegularTimeFormatter(TimeAccuracy.Hundredths);
		private bool hooked = false;
		public Dictionary<string, RaceSplit> RaceSplits = new Dictionary<string, RaceSplit>();
		public string UserName;
		public void Clear() {
			srl = null;
			raceIRC = null;
			if (liveSplitChannel != null) {
				liveSplitChannel.MessageReceived -= LiveSplitChannel_MessageReceived;
			}
			UserName = null;
			liveSplitChannel = null;
			if (raceClient != null) {
				raceClient.LocalUser.MessageSent -= LiveSplitChannel_MessageReceived;
			}
			raceClient = null;
			RaceSplits.Clear();
			hooked = false;
		}
		public void CheckRace() {
			try {
				if ((srl != null && (srl.IsDisposed || !srl.Visible))) {
					Clear();
				}

				if (raceIRC == null || liveSplitChannel == null || raceClient == null) {
					foreach (var form in Application.OpenForms) {
						SpeedRunsLiveForm srlForm = form as SpeedRunsLiveForm;

						if (srlForm != null && !srlForm.IsDisposed && srlForm.Visible) {
							srl = srlForm;

							PropertyInfo[] fields = typeof(SpeedRunsLiveForm).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
							PropertyInfo field = null;
							for (int i = 0; i < fields.Length; i++) {
								if (fields[i].Name.IndexOf("SRLClient", StringComparison.OrdinalIgnoreCase) >= 0 && fields[i].PropertyType == typeof(SpeedRunsLiveIRC)) {
									field = fields[i];
									break;
								}
							}

							if (field != null) {
								raceIRC = (SpeedRunsLiveIRC)field.GetValue(srl);
							}

							if (raceIRC != null) {
								fields = typeof(SpeedRunsLiveIRC).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic);
								field = null;
								for (int i = 0; i < fields.Length; i++) {
									if (fields[i].Name.IndexOf("LiveSplitChannel", StringComparison.OrdinalIgnoreCase) >= 0 && fields[i].PropertyType == typeof(IrcChannel)) {
										field = fields[i];
										break;
									}
								}
								if (field != null) {
									liveSplitChannel = (IrcChannel)field.GetValue(raceIRC);
								}

								field = null;
								for (int i = 0; i < fields.Length; i++) {
									if (fields[i].Name.IndexOf("Client", StringComparison.OrdinalIgnoreCase) >= 0 && fields[i].PropertyType == typeof(IrcClient)) {
										field = fields[i];
										break;
									}
								}
								if (field != null) {
									raceClient = (IrcClient)field.GetValue(raceIRC);
								}
							}
							break;
						}
					}
				}

				if (raceIRC != null && liveSplitChannel != null && raceClient != null) {
					UserName = raceIRC.Username;
					if (!hooked) {
						liveSplitChannel.MessageReceived += LiveSplitChannel_MessageReceived;
						raceClient.LocalUser.MessageSent += LiveSplitChannel_MessageReceived;
					}
					hooked = true;
				}
			} catch { }
		}
		private void LiveSplitChannel_MessageReceived(object sender, IrcMessageEventArgs e) {
			if (e.Targets.Count > 0 && e.Targets[0] == liveSplitChannel) {
				if (raceIRC.RaceState == RaceState.RaceStarted || raceIRC.RaceState == RaceState.RaceEnded) {
					if (e.Text.StartsWith("!time ") || e.Text.StartsWith("!done ")) {
						var method = e.Text.Substring("!time ".Length).StartsWith("GameTime") ? TimingMethod.GameTime : TimingMethod.RealTime;
						var cutOff = e.Text.Substring("!time RealTime ".Length);
						var index = cutOff.LastIndexOf("\"");
						var timeString = cutOff.Substring(index > -1 ? index + 2 : 0);
						var time = ParseTime(timeString);

						string splitName = null;
						if (index >= 0) {
							splitName = Unescape(cutOff.Substring(1, index - 1));
						} else {
							splitName = raceIRC.Model.CurrentState.Run[raceIRC.Model.CurrentState.Run.Count - 1].Name;
						}

						string[] splitAndSub = splitName.Split('|');
						bool found = false;
						if (splitAndSub.Length == 2) {
							splitName = splitAndSub[0].Trim();
							for (int i = raceIRC.Model.CurrentState.Run.Count - 1; i >= 0; i--) {
								ISegment seg = raceIRC.Model.CurrentState.Run[i];
								string segName = seg.Name.Trim();
								if (segName.Equals(splitName, StringComparison.OrdinalIgnoreCase)) {
									found = true;
									RaceSplit split = null;
									if (!RaceSplits.TryGetValue(e.Source.Name, out split)) {
										split = new RaceSplit() { Name = e.Source.Name, SplitIndex = i, SplitName = segName, SplitTime = new Time(method, time), SubSplitIndex = int.Parse(splitAndSub[1]) };
									} else {
										string historyName = e.Source.Name + "|" + split.SplitIndex + "|" + split.SubSplitIndex;
										string newHistoryName = e.Source.Name + "|" + i + "|" + int.Parse(splitAndSub[1]);
										if (!historyName.Equals(newHistoryName, StringComparison.OrdinalIgnoreCase)) {
											if (!RaceSplits.ContainsKey(historyName)) {
												RaceSplits.Add(historyName, split.Clone());
											}
										}

										split.SplitIndex = i;
										split.SplitName = segName;
										if (method == TimingMethod.RealTime) {
											split.SplitTime = new Time(time, split.SplitTime.GameTime);
										} else {
											split.SplitTime = new Time(split.SplitTime.RealTime, time);
										}
										split.SubSplitIndex = int.Parse(splitAndSub[1]);
									}
								}
							}
						} else {
							for (int i = raceIRC.Model.CurrentState.Run.Count - 1; i >= 0; i--) {
								ISegment seg = raceIRC.Model.CurrentState.Run[i];
								string segName = seg.Name.Trim();
								if (segName.Equals(splitName, StringComparison.OrdinalIgnoreCase)) {
									found = true;
									RaceSplit split = null;
									if (!RaceSplits.TryGetValue(e.Source.Name, out split)) {
										split = new RaceSplit() { Name = e.Source.Name, SplitIndex = i, SplitName = segName, SplitTime = new Time(method, time), SubSplitIndex = int.MaxValue };
									} else {
										string historyName = e.Source.Name + "|" + split.SplitIndex + "|" + split.SubSplitIndex;
										string newHistoryName = e.Source.Name + "|" + i + "|" + int.MaxValue;
										if (!historyName.Equals(newHistoryName, StringComparison.OrdinalIgnoreCase)) {
											if (!RaceSplits.ContainsKey(historyName)) {
												RaceSplits.Add(historyName, split.Clone());
											}
										}

										split.SplitIndex = i;
										split.SplitName = segName;
										if (method == TimingMethod.RealTime) {
											split.SplitTime = new Time(time, split.SplitTime.GameTime);
										} else {
											split.SplitTime = new Time(split.SplitTime.RealTime, time);
										}
										split.SubSplitIndex = int.MaxValue;
									}
								}
							}
						}

						if (!found) {
							RaceSplit split = null;
							if (splitAndSub.Length == 2) {
								splitName = splitAndSub[0].Trim();
							}
							if (!RaceSplits.TryGetValue(e.Source.Name, out split)) {
								split = new RaceSplit() { Name = e.Source.Name, SplitIndex = raceIRC.Model.CurrentState.CurrentSplitIndex, SplitName = splitName, SplitTime = new Time(method, time), SubSplitIndex = int.MaxValue };
							} else {
								string historyName = e.Source.Name + "|" + split.SplitIndex + "|" + split.SubSplitIndex;
								string newHistoryName = e.Source.Name + "|" + raceIRC.Model.CurrentState.CurrentSplitIndex + "|" + int.MaxValue;
								if (!historyName.Equals(newHistoryName, StringComparison.OrdinalIgnoreCase)) {
									if (!RaceSplits.ContainsKey(historyName)) {
										RaceSplits.Add(historyName, split.Clone());
									}
								}

								split.SplitIndex = raceIRC.Model.CurrentState.CurrentSplitIndex;
								split.SplitName = splitName;
								if (method == TimingMethod.RealTime) {
									split.SplitTime = new Time(time, split.SplitTime.GameTime);
								} else {
									split.SplitTime = new Time(split.SplitTime.RealTime, time);
								}
								split.SubSplitIndex = int.MaxValue;
							}
						}
					}
				}
			}
		}
		protected TimeSpan? ParseTime(string timeString) {
			if (timeString == "-")
				return null;
			return TimeSpanParser.Parse(timeString);
		}
		private static string Unescape(string value) {
			return value.Replace("\\.", "\"").Replace("\\\\", "\\");
		}
	}
}
using LiveSplit.Model;
namespace LiveSplit.UI.Components {
	public class RaceSplit {
		public string Name { get; set; }
		public string SplitName { get; set; }
		public int SplitIndex { get; set; }
		public int SubSplitIndex { get; set; }
		public Time SplitTime { get; set; }

		public void Clear() {
			if (Name != null) {
				Name = null;
				SplitName = null;
				SplitIndex = 0;
				SubSplitIndex = int.MaxValue;
				SplitTime = default(Time);
			}
		}
		public RaceSplit Clone() {
			return new RaceSplit() {
				Name = this.Name,
				SplitName = this.SplitName,
				SplitIndex = this.SplitIndex,
				SubSplitIndex = this.SubSplitIndex,
				SplitTime = this.SplitTime
			};
		}
		public override string ToString() {
			return Name + ": " + SplitName + " " + SplitTime.ToString();
		}
	}
}
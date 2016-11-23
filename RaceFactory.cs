using LiveSplit.Model;
using System;
using System.Reflection;
namespace LiveSplit.UI.Components {
	public class RaceFactory : IComponentFactory {
		public string ComponentName => "Race Comparisons";
		public string Description => "Displays race comparisons";
		public ComponentCategory Category => ComponentCategory.Information;
		public IComponent Create(LiveSplitState state) => new RaceComponent(state);
		public string UpdateName => ComponentName;
		public string XMLURL { get { return this.UpdateURL + "Components/LiveSplit.RaceComparison.Updates.xml"; } }
		public string UpdateURL => "https://raw.githubusercontent.com/ShootMe/LiveSplit.RaceComparison/master/";
		public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
	}
}
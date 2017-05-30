using System.Collections;
using System.Collections.Generic;

namespace Kanonji.DebugUtil.LogOnGUI {
	public class LogOnGUITimer {

		private static LogOnGUITimerInstance instance;
		private static LogOnGUITimerInstance Instance {
			get { return instance ?? (instance = new LogOnGUITimerInstance()); }
			set { instance = null; }
		}

		public static void Begin() {
			Destroy();
			Instance.Log("Timer began.");
		}

		public static void Log(string str = "") {
			Instance.Log(str);
		}

		public static void Destroy() {
			Instance = null;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kanonji.DebugUtil.LogOnCanvas {

	public static class LogOnCanvas {

		public static LogOnCanvasInstance Instance {
			get { return LogOnCanvasInstance.Instance; }
		}

		public static void Log(string logText) {
			LogOnCanvas.Log(0, logText);
		}

		public static void Log(int panelIndex, string logText) {
			LogOnCanvas.Instance.Log(panelIndex, logText);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kanonji.DebugUtil.LogOnGUI {
	public class LogOnGUITimerInstance {

		protected float beginingTime;

		public LogOnGUITimerInstance() {
			this.beginingTime = Time.realtimeSinceStartup;
		}

		public void Log(string str = "") {
			var time = Time.realtimeSinceStartup - this.beginingTime;
			str = String.Format("{0} : {1} sec", str, time.ToString());
			LogOnGUI.Instance.Log(str);
		}
	}
}

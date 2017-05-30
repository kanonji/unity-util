using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kanonji.Util.Behaviour;

namespace Kanonji.DebugUtil.LogOnGUI {
	public class LogOnGUI : UndestroyableMonoBehaviour<LogOnGUI> {

		private Text logText;
		public Text LogText {
			get { return logText ?? (logText = GetComponentInChildren<Text>()); }
		}

		public void Log(string str = "") {
			this.LogText.text += string.Format("{0}{1}", str, Environment.NewLine);
		}
	}
}

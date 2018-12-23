using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kanonji.Util.Extensions;
using UnityEngine.UI;

namespace Kanonji.DebugUtil.LogOnCanvas {

	public class LogPanel : MonoBehaviour {

		private RectTransform rectTransform;
		private RectTransform RectTransform {
			get { return this.rectTransform ?? (this.rectTransform = GetComponent<RectTransform>()); }
		}

		private Text text;
		private Text Text {
			get { return this.text ?? (this.text = this.GetComponentInChildren<Text>()); }
		}

		public void Display(List<string> logTextList) {
			this.Text.text = string.Join(System.Environment.NewLine, logTextList.ToArray());
		}

		public void Layout(float inset, float width) {
			this.RectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, inset, width);
		}
	}
}

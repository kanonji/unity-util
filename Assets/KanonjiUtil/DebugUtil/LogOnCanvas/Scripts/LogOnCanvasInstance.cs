using Kanonji.Util.Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kanonji.DebugUtil.LogOnCanvas {

	public class LogOnCanvasInstance : UndestroyableMonoBehaviour<LogOnCanvasInstance> {

		[SerializeField] private LogPanel logPanelPrefab;
		private LogPanel LogPanelPrefab {
			get { return this.logPanelPrefab; }
		}

		private Canvas canvas;
		private Canvas Canvas {
			get { return this.canvas ?? (this.canvas = this.GetComponent<Canvas>()); }
		}

		private RectTransform canvasRectTransform;
		private RectTransform CanvasRectTransform {
			get { return this.canvasRectTransform ?? (this.canvasRectTransform = this.Canvas.GetComponent<RectTransform>()); }
		}

		private float CanvasWidth {
			get { return this.CanvasRectTransform.sizeDelta.x; }
		}

		private List<LogPanel> logPanelList = new List<LogPanel>();
		private List<LogPanel> LogPanelList {
			get { return this.logPanelList; }
		}

		private Dictionary<LogPanel, List<string>> logTextList = new Dictionary<LogPanel, List<string>>();
		private Dictionary<LogPanel, List<string>> LogTextList {
			get { return this.logTextList; }
		}

		public void CreateLogPanel() {
			LogPanel newLogPanel = Object.Instantiate(this.LogPanelPrefab, this.Canvas.transform);
			this.LogPanelList.Add(newLogPanel);
			this.LogTextList.Add(newLogPanel, new List<string>());
			this.ReLayout();
		}

		public void Show() {
			this.Canvas.enabled = true;
		}

		public void Hide() {
			this.Canvas.enabled = false;
		}

		public void Log(int panelIndex, string logText) {
			LogPanel logPanel = this.LogPanelList[panelIndex];
			this.LogTextList[logPanel].Add(logText);
			logPanel.Display(this.LogTextList[logPanel]);
		}

		private void Start() {
			this.Init();
		}

		private void Init() {
			this.LogPanelList.Clear();
			this.LogTextList.Clear();
			this.CreateLogPanel();
		}

		private void ReLayout() {
			float panelWidth = this.CanvasWidth / this.LogPanelList.Count;

			foreach(LogPanel logPanel in this.LogPanelList) {
				int index = this.LogPanelList.IndexOf(logPanel);
				logPanel.Layout(panelWidth * index, panelWidth);
			}
		}
	}
}

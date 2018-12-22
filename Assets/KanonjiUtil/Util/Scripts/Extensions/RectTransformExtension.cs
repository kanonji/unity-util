using UnityEngine;

namespace Kanonji.Util.Extensions {

	public static class RectTransformExtension {

		public static bool IsStretchedX(this RectTransform rectTransform) {
			return 0 == rectTransform.anchorMin.x && 1 == rectTransform.anchorMax.x;
		}

		public static bool IsStretchedY(this RectTransform rectTransform) {
			return 0 == rectTransform.anchorMin.y && 1 == rectTransform.anchorMax.y;
		}

		public static bool IsStretchedBoth(this RectTransform rectTransform) {
			return rectTransform.IsStretchedX() && rectTransform.IsStretchedY();
		}
	}
}

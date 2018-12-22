using UnityEngine;

namespace Kanonji.Util.Extensions {

	public static class RectTransformExtension {

		[System.Serializable]
		public struct RectTransformOffsets {
			public float left;
			public float top;
			public float right;
			public float bottom;

			public RectTransformOffsets(float left, float top, float right, float bottom) {
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}

			public override string ToString() {
				return string.Format("left: {0}, top: {1}, right: {2}, bottom: {3}", this.left, this.top, this.right, this.bottom);
			}
		}

		public static bool IsStretchedX(this RectTransform rectTransform) {
			return 0 == rectTransform.anchorMin.x && 1 == rectTransform.anchorMax.x;
		}

		public static bool IsStretchedY(this RectTransform rectTransform) {
			return 0 == rectTransform.anchorMin.y && 1 == rectTransform.anchorMax.y;
		}

		public static bool IsStretchedBoth(this RectTransform rectTransform) {
			return rectTransform.IsStretchedX() && rectTransform.IsStretchedY();
		}

		public static RectTransformOffsets GetOffsets(this RectTransform rectTransform) {
			float left = rectTransform.offsetMin.x;
			float top = rectTransform.offsetMax.y * (rectTransform.IsStretchedY() ? -1 : 1);
			float right = rectTransform.offsetMax.x * (rectTransform.IsStretchedX() ? -1 : 1);
			float bottom = rectTransform.offsetMin.y;
			return new RectTransformOffsets(left, top, right, bottom);
		}

		public static void SetLeft(this RectTransform rectTransform, float left) {
			RectTransformOffsets offsets = rectTransform.GetOffsets();
			rectTransform.SetOffsets(left, offsets.top, offsets.right, offsets.bottom);
		}

		public static void SetTop(this RectTransform rectTransform, float top) {
			RectTransformOffsets offsets = rectTransform.GetOffsets();
			rectTransform.SetOffsets(offsets.left, top, offsets.right, offsets.bottom);
		}

		public static void SetRight(this RectTransform rectTransform, float right) {
			RectTransformOffsets offsets = rectTransform.GetOffsets();
			rectTransform.SetOffsets(offsets.left, offsets.top, right, offsets.bottom);
		}

		public static void SetBottom(this RectTransform rectTransform, float bottom) {
			RectTransformOffsets offsets = rectTransform.GetOffsets();
			rectTransform.SetOffsets(offsets.left, offsets.top, offsets.right, bottom);
		}

		public static void SetOffsets(this RectTransform rectTransform, float left, float top, float right, float bottom) {
			rectTransform.offsetMin = new Vector2(left, bottom);
			right = right * (rectTransform.IsStretchedX() ? -1 : 1);
			top = top * (rectTransform.IsStretchedY() ? -1 : 1);
			rectTransform.offsetMax = new Vector2(right, top);
		}
	}
}

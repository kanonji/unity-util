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

		public static bool IsStretchedX(this RectTransform self) {
			return 0 == self.anchorMin.x && 1 == self.anchorMax.x;
		}

		public static bool IsStretchedY(this RectTransform self) {
			return 0 == self.anchorMin.y && 1 == self.anchorMax.y;
		}

		public static bool IsStretchedBoth(this RectTransform self) {
			return self.IsStretchedX() && self.IsStretchedY();
		}

		public static RectTransformOffsets GetOffsets(this RectTransform rectTransform) {
			float left = rectTransform.offsetMin.x;
			float top = rectTransform.offsetMax.y * (rectTransform.IsStretchedY() ? -1 : 1);
			float right = rectTransform.offsetMax.x * (rectTransform.IsStretchedX() ? -1 : 1);
			float bottom = rectTransform.offsetMin.y;
			return new RectTransformOffsets(left, top, right, bottom);
		}

		public static void SetLeft(this RectTransform self, float left) {
			RectTransformOffsets offsets = self.GetOffsets();
			self.SetOffsets(left, offsets.top, offsets.right, offsets.bottom);
		}

		public static void SetTop(this RectTransform self, float top) {
			RectTransformOffsets offsets = self.GetOffsets();
			self.SetOffsets(offsets.left, top, offsets.right, offsets.bottom);
		}

		public static void SetRight(this RectTransform self, float right) {
			RectTransformOffsets offsets = self.GetOffsets();
			self.SetOffsets(offsets.left, offsets.top, right, offsets.bottom);
		}

		public static void SetBottom(this RectTransform self, float bottom) {
			RectTransformOffsets offsets = self.GetOffsets();
			self.SetOffsets(offsets.left, offsets.top, offsets.right, bottom);
		}

		public static void SetOffsets(this RectTransform self, float left, float top, float right, float bottom) {
			self.offsetMin = new Vector2(left, bottom);
			right = right * (self.IsStretchedX() ? -1 : 1);
			top = top * (self.IsStretchedY() ? -1 : 1);
			self.offsetMax = new Vector2(right, top);
		}

		public static float GetWidth(this RectTransform self) {
			return self.sizeDelta.x;
		}

		public static float GetHeight(this RectTransform self) {
			return self.sizeDelta.y;
		}

		public static void SetWidth(this RectTransform self, float width) {
			var size = self.sizeDelta;
			size.x = width;
			self.sizeDelta = size;
		}

		public static void SetHeight(this RectTransform self, float height) {
			var size = self.sizeDelta;
			size.y = height;
			self.sizeDelta = size;
		}

		public static void SetSize(this RectTransform self, float width, float height) {
			self.sizeDelta = new Vector2(width, height);
		}
	}
}

namespace Kanonji.Util.Extension {

	public static class StringAsUnityRichTextExtension {

		public static string Color(this string str, string color) {
			return string.Format("<color={0}>{1}</color>", color, str);
		}
		public static string Primary(this string str) {
			return str.Color("#9b479f");
		}
		public static string Success(this string str) {
			return str.Color("#279a27");
		}
		public static string Info(this string str) {
			return str.Color("#1080ff");
		}
		public static string Warning(this string str) {
			return str.Color("#ed7600");
		}
		public static string Danger(this string str) {
			return str.Color("#e51c23");
		}

		public static string Size(this string str, int size) {
			return string.Format("<size={0}>{1}</size>", size, str);
		}
		public static string H1(this string str) {
			return str.Size(18);
		}
		public static string H2(this string str) {
			return str.Size(16);
		}
		public static string H3(this string str) {
			return str.Size(14);
		}

		public static string Bold(this string str) {
			return string.Format("<b>{0}</b>", str);
		}
		public static string Italic(this string str) {
			return string.Format("<i>{0}</i>", str);
		}
	}
}

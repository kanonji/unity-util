using UnityEngine;

namespace Kanonji.Util.Extension {
	public static class BoundsExtension {

		public static Vector3 GetRandomVector3Within(this Bounds self) {
			var x = Random.Range(self.min.x, self.max.x);
			var y = Random.Range(self.min.y, self.max.y);
			var z = Random.Range(self.min.z, self.max.z);
			return new Vector3(x, y, z);
		}
	}
}

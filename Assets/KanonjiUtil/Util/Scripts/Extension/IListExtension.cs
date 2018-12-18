using System.Collections.Generic;
using UnityEngine;

namespace Kanonji.Util.Extension {
	public static class IListExtension {

		public static T GetRandom<T>(this IList<T> list) {
			return list[Random.Range(0, list.Count)];
		}
	}
}

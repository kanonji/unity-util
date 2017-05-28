using UnityEngine;

namespace Kanonji.Util.Behaviour {

	[DisallowMultipleComponent]
	public class UndestroyableMonoBehaviour<T> : SingletonMonoBehaviour<T> where T : UndestroyableMonoBehaviour<T> {

		protected new void Awake() {
			base.Awake();
			if (this != Instance) {
				Destroy(gameObject);
				return;
			}
			DontDestroyOnLoad(gameObject);
		}
	}
}

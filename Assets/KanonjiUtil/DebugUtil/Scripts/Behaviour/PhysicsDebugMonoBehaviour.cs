using UnityEngine;

namespace Kanonji.DebugUtil.Behaviour {

	public class PhysicsDebugMonoBehaviour : MonoBehaviour {

		protected Color originalColor;
		protected bool isSleepingInLast;

		private Rigidbody _rigidbody;
		public Rigidbody Rigidbody {
			get { return _rigidbody ?? (_rigidbody = GetComponent<Rigidbody>()); }
		}

		private Renderer _renderer;
		public Renderer Renderer {
			get { return _renderer ?? (_renderer = GetComponent<Renderer>()); }
		}

		private void Start() {
			originalColor = Renderer.material.color;
			isSleepingInLast = Rigidbody.IsSleeping();
		}

		void Update() {
			bool isSleeping = Rigidbody.IsSleeping();
			if (!IsChanged(isSleeping)) return;
			if (isSleeping) {
				Renderer.material.color = GetSleepingColor();
			} else {
				Renderer.material.color = originalColor;
			}
		}

		protected Color GetSleepingColor() {
			Color color = originalColor;
			color -= Color.gray;
			return color;
		}

		protected bool IsChanged(bool current) {
			bool isChanged = isSleepingInLast != current;
			isSleepingInLast = current;
			return isChanged;
		}
	}
}

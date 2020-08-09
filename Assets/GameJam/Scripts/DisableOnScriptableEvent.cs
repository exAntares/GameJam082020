using UnityEngine;

namespace HalfBlind.ScriptableVariables {
    public class DisableOnScriptableEvent : MonoBehaviour {
        [SerializeField] private ScriptableGameEvent _event;

        private void Awake() {
            _event.AddListener(OnEvent);
        }

        private void OnDestroy() {
            _event.RemoveListener(OnEvent);
        }

        private void OnEvent() {
            gameObject.SetActive(false);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace HalfBlind {
    public class ButtonPlayAudio : MonoBehaviour {
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private Button _button;
        [SerializeField] private float volume = 1.0f;
        [SerializeField] private AudioSource _source;

        private void Awake() {
            if (_source == null) {
                var main = Camera.main;
                if (main != null) {
                    _source = main.GetComponent<AudioSource>();
                }
            }
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDestroy() {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void Reset() {
            _button = GetComponent<Button>();
        }
        
        private void OnClicked() {
            if (_source != null) {
                _source.PlayOneShot(_audioClip, volume);
            }
        }
    }
}
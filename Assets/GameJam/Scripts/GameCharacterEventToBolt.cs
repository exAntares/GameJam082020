using Bolt;
using UnityEngine;

public class GameCharacterEventToBolt : MonoBehaviour {
    [SerializeField] private GameCharacterData _data;

    private void Awake() {
        if (_data) {
            _data.OnSuccess.AddListener(OnSuccess);
            _data.OnFail.AddListener(OnFail);            
        }
        else {
            Debug.LogError($"{name} does not have {nameof(GameCharacterData)}");
        }
    }

    private void OnDestroy() {
        _data.OnSuccess.RemoveListener(OnSuccess);
        _data.OnFail.RemoveListener(OnFail);        
    }

    private void OnFail() {
        CustomEvent.Trigger(gameObject, _data.OnFail.name);
    }

    private void OnSuccess() {
        CustomEvent.Trigger(gameObject, _data.OnSuccess.name);
    }
}

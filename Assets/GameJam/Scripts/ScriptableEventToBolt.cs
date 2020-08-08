using Bolt;
using HalfBlind.ScriptableVariables;
using UnityEngine;

public class ScriptableEventToBolt : MonoBehaviour {
    [SerializeField] private ScriptableGameEvent _gameEvent;
    private void Awake()
    {
        _gameEvent.AddListener(OnGameEvent);
    }

    private void OnGameEvent() {
        CustomEvent.Trigger(gameObject, _gameEvent.name);
    }

    private void OnDestroy()
    {
        _gameEvent.RemoveListener(OnGameEvent);
    }
}

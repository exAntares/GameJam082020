using Bolt;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCharacter : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameCharacterData MyData;

    public void OnPointerClick(PointerEventData eventData) {
        _gameController.OnCharacterClicked(MyData);
    }

    public void OnPointerDown(PointerEventData eventData) {
    }

    public void OnPointerUp(PointerEventData eventData) {
    }
    
    private void Awake() {
        if (MyData) {
            MyData.OnSuccess.AddListener(OnSuccess);
            MyData.OnFail.AddListener(OnFail);            
        }
        else {
            Debug.LogError($"{name} does not have {nameof(GameCharacterData)}");
        }
    }

    private void OnDestroy() {
        MyData.OnSuccess.RemoveListener(OnSuccess);
        MyData.OnFail.RemoveListener(OnFail);        
    }

    private void OnFail() {
        CustomEvent.Trigger(gameObject, MyData.OnFail.name);
    }

    private void OnSuccess() {
        CustomEvent.Trigger(gameObject, MyData.OnSuccess.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
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
}

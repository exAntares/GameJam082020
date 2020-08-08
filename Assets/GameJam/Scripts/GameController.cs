using System.Collections.Generic;
using HalfBlind.ScriptableVariables;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameController), menuName = "ScriptableObjects/GameJam/"+nameof(GameController))]
public class GameController : ScriptableObject {
    [SerializeField] private GameCharacterData[] Characters;
    [SerializeField] private ScriptableGameEvent OnGameWin;
    private List<GameCharacterData> _result;

    public void StartGame() {
        var list = new List<GameCharacterData>(Characters);
        _result = new List<GameCharacterData>(Characters.Length);
        
        for (int i = 0; i < 3; i++) {
            var index = Random.Range(0, list.Count);
            _result.Add(list[index]);
            list.RemoveAt(index);
        }
    }

    public GameCharacterData[] GetCharacters() {
        if (_result.Count != 3) {
            StartGame();
        }
        return _result.ToArray();
    }

    public void OnCharacterClicked(GameCharacterData myData) {
        if (myData == null) {
            return;
        }
        
        if (_result.Contains(myData)) {
            _result.Remove(myData);
            Debug.Log($"{myData.name} found!!");
            myData.OnSuccess.SendEvent();
        }
        else {
            Debug.Log($"{myData.name} wrong selected");
            myData.OnFail.SendEvent();
        }

        if (_result.Count == 0) {
            Debug.Log("YOU WON!!!");
            OnGameWin.SendEvent();
        }
    }
}

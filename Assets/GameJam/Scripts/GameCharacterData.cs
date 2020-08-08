using HalfBlind.ScriptableVariables;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(GameCharacterData), menuName = "ScriptableObjects/GameJam/"+nameof(GameCharacterData))]
public class GameCharacterData : ScriptableObject {
    public Sprite Icon;
    public ScriptableGameEvent OnSuccess;
    public ScriptableGameEvent OnFail;
}

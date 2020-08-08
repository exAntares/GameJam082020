using UnityEngine;
using UnityEngine.UI;

public class CharacterSetter : MonoBehaviour {
    public GameController Controller;
    public Image[] _images;

    void Start() {
        var selectedCharacters = Controller.GetCharacters();
        for (var i = 0; i < selectedCharacters.Length; i++) {
            _images[i].sprite = selectedCharacters[i].Icon;
        }
    }
}

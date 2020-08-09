using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetter : MonoBehaviour {
    public GameController Controller;
    public Image[] _images;
    public bool ShouldDisableOnFound;
    public Ease OutEase;

    void Start() {
        var selectedCharacters = Controller.GetCharacters();
        for (var i = 0; i < selectedCharacters.Length; i++) {
            var gameCharacterData = selectedCharacters[i];
            var image = _images[i];
            void LocalFunc() {
                OutEase = Ease.OutSine;
                image.DOFade(0.0f, 1.0f)
                    .SetEase(OutEase);
                gameCharacterData.OnSuccess.RemoveListener(LocalFunc);
            }
            image.sprite = gameCharacterData.Icon;
            if (ShouldDisableOnFound) {
                gameCharacterData.OnSuccess.AddListener(LocalFunc);
            }
        }
    }
}

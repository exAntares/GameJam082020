using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    void Awake() {
        if (SceneManager.sceneCount < 2) {
            SceneManager.LoadScene(sceneBuildIndex: 1, LoadSceneMode.Additive);    
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    void Awake() {
        SceneManager.LoadScene(sceneBuildIndex: 1, LoadSceneMode.Additive);
    }
}

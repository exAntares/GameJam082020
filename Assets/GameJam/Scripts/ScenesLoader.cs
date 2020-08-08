using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    void Awake() {
        SceneManager.LoadScene(sceneBuildIndex: 1, LoadSceneMode.Additive);
        SceneManager.LoadScene(sceneBuildIndex: 2, LoadSceneMode.Additive);
    }

    private void Start() {
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class RetrySceneButton : MonoBehaviour
{
    // This function will reload the current scene
    public void RetryScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();
        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }
}

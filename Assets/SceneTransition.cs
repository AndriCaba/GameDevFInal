using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string scnenename;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player triggered the collider
        if (collision.CompareTag("Player"))
        {
            // Load the second scene
            SceneManager.LoadScene(scnenename);
        }
    }
}

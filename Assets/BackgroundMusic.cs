using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
   public static BackgroundMusic instance;

    void Awake()
    {
        // If there is already an instance of the music, destroy this one
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Add any music setup here, for example, play the music at the start
        GetComponent<AudioSource>().Play();
    }
}

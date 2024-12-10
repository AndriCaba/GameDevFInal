using UnityEngine;

public class ActivateScriptsOnTrigger : MonoBehaviour
{
    // References to the scripts to be activated
    public MonoBehaviour script1;
    public MonoBehaviour script2;
    public MonoBehaviour script3;

    void Start(){

         script1.enabled = false;
           script2.enabled = false;
            script3.enabled = false;


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Activate the scripts
            if (script1 != null) script1.enabled = true;
            if (script2 != null) script2.enabled = true;
            if (script3 != null) script3.enabled = true;

            Debug.Log("Scripts activated!");
        }
    }
}

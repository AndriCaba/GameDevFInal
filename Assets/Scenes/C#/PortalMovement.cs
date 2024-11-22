using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalMovement : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject LoadingScreen;
   // public  float  LoadingScreenTransform;
    public string levelname;

    void Start()
    {
      //  LoadingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Loadlvl1());
        }

    }

     IEnumerator Loadlvl1()
    {
        Debug.Log("aaa");
       yield return new WaitForSeconds(1);
      SceneManager.LoadScene(levelname);
       // Debug.Log("aaa");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] float reloadTime = 1.5f;
    [SerializeField] ParticleSystem finishLineParticle;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log($"{collision.gameObject.transform.position}");
            Debug.Log($"{transform.position}");
            Debug.Log("This is finish script");
            finishLineParticle.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadLevel", reloadTime);            
        }        
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}

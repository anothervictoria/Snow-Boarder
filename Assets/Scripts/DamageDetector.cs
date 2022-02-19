using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] float reloadTime = 1f;
    [SerializeField] ParticleSystem headDamageParticle;
    [SerializeField] AudioClip crashSFX;

    //CircleCollider2D playerHead;
    //void Start()
    //{
    //    playerHead = GetComponent<CircleCollider2D>();
    //}
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground") && playerHead.IsTouching(other.collider))
    //    {
    //        headDamageParticle.Play();
    //        Invoke("ReloadLevel", reloadTime);
    //    }
    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            headDamageParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadLevel", reloadTime);
        }
    }

    private void ReloadLevel()
    {
        Debug.Log("1");
        SceneManager.LoadScene(0);
    }
}
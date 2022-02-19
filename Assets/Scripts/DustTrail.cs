using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowParticle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            snowParticle.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       snowParticle.Stop();
        
    }

}

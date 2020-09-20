using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalTrigger : MonoBehaviour
{
    public Animator anim;
    public AudioSource crystalAudio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crystal")
        {
            anim.SetTrigger("IsNearCrystal");
            crystalAudio.Play();
        }
    }
}

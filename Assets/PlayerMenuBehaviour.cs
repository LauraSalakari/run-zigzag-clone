using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuBehaviour : MonoBehaviour
{
    private int counter = 0;
    public Animator anim;

    private void Awake()
    {
        InvokeRepeating("PlayAttack", 2, 4);
    }

    void PlayAttack()
    {
        float attackChance = Random.Range(0, 100);

        if(attackChance < 50)
        {
            anim.SetTrigger("PlayAttack1");
            counter++;
        }
        else
        {
            anim.SetTrigger("PlayAttack2");
            counter++;
        }
    }
}

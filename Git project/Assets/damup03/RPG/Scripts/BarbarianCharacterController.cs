using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianCharacterController : MonoBehaviour
{
    public Animator animator; 
    bool dead = false; 
    bool die = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>() as Animator;

    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            if (die)
            {
                die = !die;
                animator.SetBool("Die", die);
            }
            return;
        }
        
    }
}

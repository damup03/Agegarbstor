using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianCharacterController : MonoBehaviour
{
    public Animator animator;
    public float directionDampTime;
    public float speed = 6.0f;
    public float h = 0.0f;
    public float v = 0.0f;
    private bool attack = false;
    private bool punch = false;
    private bool run = false;
    private bool jump = false;
    bool die = false;
    bool dead = false;
    
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

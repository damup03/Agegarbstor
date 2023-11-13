using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFB : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    public float speed = 2f;
    public Transform groundCheckerTransform;
    public LayerMask groundLayer;
    public float jumpForce = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(h, 0, v);
        if (directionVector.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector),
                Time.deltaTime * rotationSpeed);

        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, 1) * speed;
        rigidbody.velocity = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.z);
        rigidbody.angularVelocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
 
        /*if (Physics.CheckSphere(groundCheckerTransform.position, 0.2f, notPlayerMask))
        {
            animator.SetBool("isInAir", false);
        }
        else
        {
            animator.SetBool("isInAir", true);
        }*/
 
    }
 
    void Jump()
    {
        //RaycastHit hit;
        if (Physics.Raycast(groundCheckerTransform.position, Vector3.down, 10f, groundLayer))
        {
            //animator.SetTrigger("Jump");
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        /*else
        {
            Debug.Log("Did not find ground layer");
        }*/
    }
}

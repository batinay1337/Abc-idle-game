using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        //change.x = Input.GetAxisRaw("Horizontal");
        // change.y = Input.GetAxisRaw("Vertical");
        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        UpdateAnimationAndMove();
        if (change != Vector3.zero)
        
        {
            transform.Translate(new Vector3(change.x, change.y));
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY",change.y);
            animator.SetBool("moving", true);
        }else{
            animator.SetBool("moving", false);
        }
        
        
    //if (change != Vector3.zero)
    // {        {
    //   MoveCharacter();
    //}

}
    void UpdateAnimationAndMove()
    {

    }
    
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
    );

}
}
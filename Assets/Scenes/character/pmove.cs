using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour

{
    [SerializeField] private float Speed;
    private Rigidbody2D body;
    public Animator animator;
    public float jump;
    Vector2 movement;




    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnMovement()
    {

    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, body.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * Speed));

        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))//(Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, Speed);
        }


        if (movement.x != 0)
        {
            body.AddForce(new Vector2(movement.x * Speed, 0f));
        }

        if (movement.x > 0)
        {
            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
        if (movement.x < 0)
        {
            // body.transform.localScale = new Vector3(-0.4626735f, 0.4683398f, 1);

            Vector3 scaler = transform.localScale;
            scaler.x *= -1;
            transform.localScale = scaler;
        }



    }
}
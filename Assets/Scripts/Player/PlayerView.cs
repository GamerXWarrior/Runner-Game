using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private float speed;
    private float gravity;
    private float health;
    private CharacterController c_Controller;
    private PlayerController p_Controller;
    private PlayerModel p_model;
    Vector3 velocity;
    public bool swipeLeft, swipeRight, swipeDown, swipeUp, inJump,inSlide;
    public bool jump;
    public SIDE p_Side;
    private float newXPos = 0f;
    public float p_xValue;
    private Animator animator;
    private float x;
    public float dodgeSpeed;
    public float jumpForce =5f;
    private float y;

    void Start()
    {
        p_Side = SIDE.Mid;
        c_Controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        EventService.Instance.OnPlayerSpawn();
    }

    void Update()
    {
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        if (swipeUp)
        {
            Jump();
        }
        if (swipeDown)
        {
            animator.Play("Slide");
        }
        if (swipeLeft)
        {
            if (p_Side == SIDE.Mid)
            {
                newXPos = p_xValue;
                p_Side = SIDE.Left;
                animator.Play("Left");
            }
            else if (p_Side == SIDE.Right)
            {
                newXPos = 0;
                p_Side = SIDE.Mid;
                animator.Play("Left");
            }
        }
        else if (swipeRight)
        {
            if (p_Side == SIDE.Mid)
            {
                newXPos = -p_xValue;
                p_Side = SIDE.Right;
                animator.Play("Right");
            }
            else if (p_Side == SIDE.Left)
            {
                newXPos = 0;
                p_Side = SIDE.Mid;
                animator.Play("Right");
            }
        }
        Vector3 moveVector = new Vector3(x - transform.position.x, y*Time.deltaTime, 0);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * dodgeSpeed);
        c_Controller.Move(moveVector);
        //c_Controller.Move((x - transform.position.x) * Vector3.right);

        Vector3 move = transform.forward * speed;
        c_Controller.Move(move * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        c_Controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log(c_Controller.isGrounded);
        if (c_Controller.isGrounded)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {   

                animator.Play("Run");
                inJump = false;
            }
            if (swipeUp)
            {
                y = jumpForce;
                animator.CrossFadeInFixedTime("Jump",0.1f);
                inJump = true;
            }
            else
            {
                y -= jumpForce * 2 * Time.deltaTime;
                if(c_Controller.velocity.y < -0.1f)
                animator.Play("Run");
            }
        }

    }
       

    public void InitialiseController(PlayerController controller)
    {
        p_Controller = controller;
    }

    public PlayerView GetView()
    {
        return this;
    }

    public void SetViewDetails()
    {
        p_model = p_Controller.playerModel;
        speed = p_model.MovingSpeed;
        gravity = p_model.Gravity;
        health = p_model.Health;
    }
}

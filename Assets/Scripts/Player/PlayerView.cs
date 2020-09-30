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
    [HideInInspector]
    public bool swipeLeft, swipeRight, swipeDown, swipeUp, inJump, inSlide;
    [SerializeField]
    private Vector3 playerCurrPos;
    public bool jump;
    public SIDE p_Side;
    private float newXPos = 0f;
    public float p_xValue;
    private Animator animator;
    private float x;
    public float dodgeSpeed;
    public float jumpForce = 5f;
    private float y;
    private float slideCounter;
    private float colHeight;
    private float colCenterY;
    private float colRadius;
    private float spawnerPos;
    public Renderer playerRenderer;


    void Start()
    {
        spawnerPos = transform.position.z;
        p_Side = SIDE.Mid;
        c_Controller = GetComponent<CharacterController>();
        c_Controller.detectCollisions = true;
        animator = GetComponent<Animator>();
        EventService.Instance.OnPlayerSpawn();
        colCenterY = c_Controller.center.y;
        colHeight = c_Controller.height;
        colRadius = c_Controller.radius;
    }

    void Update()
    {
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

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
        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, -speed * Time.deltaTime);
        x = Mathf.Lerp(x, newXPos, Time.deltaTime * dodgeSpeed);
        c_Controller.Move(moveVector);
        Jump();
        Slide();
        playerCurrPos = transform.position;
    }

    public void Slide()
    {
        if (swipeDown)
        {
            Debug.Log(inJump);
            if (!inJump)
            {
                animator.CrossFadeInFixedTime("Slide", 0.1f);
                //animator.Play("Slide");
                SetSlideParameters();
                inSlide = true;
            }
            else
            {
                y -= gravity;
                if (c_Controller.velocity.y < -0.1f)
                    animator.Play("Run");
                inJump = false;
            }
        }
    }
    public void Jump()
    {
        if (c_Controller.isGrounded)
        {
            inJump = false;
            if (swipeUp)
            {
                y = jumpForce;
                animator.CrossFadeInFixedTime("Jump", 0.1f);
                inJump = true;
            }
        }
        else
        {
            y -= gravity * 2 * Time.deltaTime;
            if (c_Controller.velocity.y < -0.1f)
                animator.Play("Run");
        }
    }

    public void TakeDamage()
    {
        Invoke("ResetPlayer", 0.02f);
        playerRenderer.enabled = false;
        Time.timeScale = 0.01f;
    }

    private void ResetPlayer()
    {
        Time.timeScale = 1;
        playerRenderer.enabled = true;

    }

    public void DestroyView()
    {
        Destroy(gameObject);
    }

    public float GetPlayerInitPos()
    {
        return spawnerPos;
    }

    public float GetPlayerLastPos()
    {
        return playerCurrPos.z;
    }

    private void SetSlideParameters()
    {
        c_Controller.center = new Vector3(0, 18f, 0);
        c_Controller.radius = 10f;
        c_Controller.height = 30f;
        StartCoroutine(ResetSlideParameters());
    }

    IEnumerator ResetSlideParameters()
    {
        yield return new WaitForSeconds(1f);
        c_Controller.center = new Vector3(0, colCenterY, 0);
        c_Controller.radius = colRadius;
        c_Controller.height = colHeight;
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

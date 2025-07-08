using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
   public Rigidbody2D myRigidbody;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f,0);
    public float speed;
    public float speedRun;
    public float forceJump = 25f;

    [Header("Animation Setup")]
    public float jumpScaley = 1.5f;
    public float jumpScalex = 1.5f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public Animator animator;
    public float playerSwipeDuration = .1f;
    private float _currentSpeed;
    public HealthBase _healthBase;

    public void Awake()
    {
        if (_healthBase != null) 
        {
            _healthBase.OnKill += OnPlayerKill;
        }

    }

    private void OnPlayerKill()
    {
        _healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }

    public void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
            animator.speed = 1.5f;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity *Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
            }
            //myRigidbody.transform.localScale = new Vector3(-1,1,1);
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity *Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
            }
            //myRigidbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(boolRun, true);
        }
        else
        { 
            animator.SetBool(boolRun,false); 
        }
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity -= friction;
        }
        else if (myRigidbody.velocity.x < 0) 
        {
            myRigidbody.velocity += friction;
        }


    }
    private void HandleJump()
    {
        animator.SetBool(boolJump, false);
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            myRigidbody.velocity = Vector2.up * forceJump;
            myRigidbody.transform.localScale = Vector2.one;
            DOTween.Kill(myRigidbody.transform);
            HandleJumpScale();
        }
        animator.SetBool(boolRun, true);

    }
    private void HandleJumpScale()
    {
                myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
                animator.SetBool(boolJump, true);
                myRigidbody.transform.DOScaleY(jumpScaley, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                myRigidbody.transform.DOScaleX(jumpScalex, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

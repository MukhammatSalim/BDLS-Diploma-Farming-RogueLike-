using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData playerData;
    Vector2 moveDir;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        InputManagment();
    }
    void FixedUpdate()
    {
        Move();
    }
    void InputManagment()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDir = new Vector2(moveX, moveY);

        animator.SetFloat("InputX", moveX);
        animator.SetFloat("InputY", moveY);

        if((moveX != 0) || (moveY != 0))animator.SetBool("IsMoving", true);
        else animator.SetBool("IsMoving",false);
    }
    void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveDir.x * playerData.MovementSpeed, moveDir.y * playerData.MovementSpeed);
    }
}

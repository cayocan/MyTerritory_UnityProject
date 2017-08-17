using CnControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 300;
    public Transform rotationPivot;
    public Animator animator;

    Rigidbody rigid;
    Vector3 movement;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}

    private void Update()
    {
        WalkAnimation();
        RotatePlayer();
    }
    // Update is called once per frame
    void FixedUpdate () {
        
        MovePlayer();
	}

    void MovePlayer()
    {
        movement = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
        rigid.velocity = movement;
    }

    void RotatePlayer()
    {
        rotationPivot.position = new Vector3(CnInputManager.GetAxis("HorizontalRotation"), 0, CnInputManager.GetAxis("VerticalRotation")) + this.transform.position;
        this.transform.LookAt(rotationPivot.position);
    }

    void WalkAnimation()
    { 
        if (rigid.velocity.magnitude > 1)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}

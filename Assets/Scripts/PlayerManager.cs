using CnControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [Header("General Properties")]
    public float moveSpeed = 300;
    public Transform rotationPivot;
    public Animator animator;

    [Header("Gun Properties")]
    public Rigidbody bullet;
    public float bulletForce;
    public float shotCadency;
    public Transform rightGunPivot, leftGunPivot;
    [HideInInspector]
    public bool canShoot = false;


    Rigidbody rigid;
    Vector3 movement;
    float shotTimer;
    bool intercalateGuns;

    private void Awake()
    {
        #region Singleton Statement
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion
    }

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        WalkAnimation();
        RotatePlayer();
    }

    void FixedUpdate()
    {
        MovePlayer();
        Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Die();
        }
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

    void Shoot()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer > shotCadency && canShoot)
        {
            if (intercalateGuns == true)
            {
                Instantiate(bullet, rightGunPivot.position, rightGunPivot.rotation).AddForce(rightGunPivot.transform.forward * bulletForce, ForceMode.Force);
            }
            else
            {
                Instantiate(bullet, leftGunPivot.position, leftGunPivot.rotation).AddForce(leftGunPivot.transform.forward * bulletForce, ForceMode.Force);
            }

            intercalateGuns = !intercalateGuns;
            shotTimer = 0;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

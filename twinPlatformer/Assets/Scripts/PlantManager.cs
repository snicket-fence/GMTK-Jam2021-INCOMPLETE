using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantManager : MonoBehaviour
{
    public Rigidbody2D plantBody;
    public CircleCollider2D plantHitbox1;
    public CapsuleCollider2D plantHitbox2;
    public CapsuleCollider2D plantHitbox3;
    public PolygonCollider2D plantHitbox4;
    public bool isAttached = true;

    public GameObject bulletSpawn;
    public GameObject bullet;

    bool facingRight = true;
    public CharacterController2D controller;

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            AdjustAttachment();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void AdjustAttachment()
    {
        if (isAttached)
        {
            EnableHitboxes();
            isAttached = false;
            this.gameObject.layer = 7;
            plantBody.gravityScale = 1f;
        }
        else
        {
            DisableHitboxes();
            isAttached = true;
            this.gameObject.layer = 0;
            plantBody.gravityScale = 0f;

            if (facingRight.CompareTo(controller.facingWhere()) != 0)
                Flip();
        }
    }

    void EnableHitboxes()
    {
        plantHitbox1.enabled = true;
        plantHitbox2.enabled = true;
        plantHitbox3.enabled = true;
        plantHitbox4.enabled = true;
    }

    void DisableHitboxes()
    {
        plantHitbox1.enabled = false;
        plantHitbox2.enabled = false;
        plantHitbox3.enabled = false;
        plantHitbox4.enabled = false;
    }

    void Shoot()
    {
        if (isAttached)
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
    }

    public void Flip()
    {
        if (isAttached)
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}

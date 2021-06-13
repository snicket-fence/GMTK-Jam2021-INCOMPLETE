using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 25f;
    float horizontalMove = 0f;

    bool jumpFlag = false;
    bool jump = false;

    public GameObject plant;
    public GameObject plantUpPosition;
    public GameObject plantDownPosition;
    bool hasPlant = true;

    public CircleCollider2D hitboxExtension1;
    public CapsuleCollider2D hitboxExtension2;
    public CapsuleCollider2D hitboxExtension3;
    public PolygonCollider2D hitboxExtension4;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (jumpFlag)
        {
            jumpFlag = false;
        }

        KeepPlant();

        if (Input.GetButtonDown("Jump"))
        {
            if (!hasPlant)
            {
                jump = true;
            }
        }

        if (Input.GetKeyDown("z"))
        {
            AttachDetach();
        }
    }

    void KeepPlant()
    {
        if (hasPlant)
        {
            plant.transform.position = plantUpPosition.transform.position;
        }
    }

    void AttachDetach()
    {
        if (hasPlant)
        {
            ExtensionOff();
            hasPlant = false;
            plant.transform.position = plantDownPosition.transform.position;
        }
        else
        {
            ExtensionOn();
            hasPlant = true;
        }
    }

    void ExtensionOn()
    {
        hitboxExtension1.enabled = true;
        hitboxExtension2.enabled = true;
        hitboxExtension3.enabled = true;
        hitboxExtension4.enabled = true;
    }

    void ExtensionOff()
    {
        hitboxExtension1.enabled = false;
        hitboxExtension2.enabled = false;
        hitboxExtension3.enabled = false;
        hitboxExtension4.enabled = false;
    }

    public void OnLanding()
    {
        jump = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        if (jump)
        {
            jumpFlag = true;
        }
    }
}

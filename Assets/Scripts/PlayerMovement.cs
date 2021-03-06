﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Events.Tools.MonoBehaviour_EventManagerBase//, Events.Groups.Pausable.IAll_Group_Events
{

    [Header("speed properties")]
    [SerializeField] float acceleration;
    [SerializeField] float decelertion;
    [SerializeField] float maxSpeed;
    [SerializeField] Rigidbody2D movedObject;
    [SerializeField] GameObject attackObj;
    [SerializeField] attackFunc attFun;
    float currnetSpeed;
    Vector2 direction;

    [Space, Space, Header("settings")]
    [SerializeField] bool isMovmentEnabled = true;

    public void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction.Set(horizontal, vertical);
        direction = direction.normalized;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            if (currnetSpeed < maxSpeed)
                currnetSpeed += acceleration;
            else currnetSpeed = maxSpeed;

        else
        {
            if (currnetSpeed > 0)
                currnetSpeed -= decelertion;

            else currnetSpeed = 0;
        }



        movedObject.position += direction * currnetSpeed * Time.deltaTime;

    }

    // Works when two objects have 'Is Trigger' turned off.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "StartAxe" && collision.gameObject.activeInHierarchy)
        {
            Events.Groups.Level.Invoke.OnLevelStart();
            collision.gameObject.SetActive(false);
        }

    }


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovmentEnabled && !attFun.Activated)
            Move();

    }
    
}

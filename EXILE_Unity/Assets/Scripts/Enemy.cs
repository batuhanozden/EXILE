using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using CodeMonkey.Utils;

public class Enemy : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private Rigidbody _rigidbody;
    private bool isEnemyInRange;
    private GameObject player;
    private float speed = 15f;
    private Transform target;
    private float distanceToStop = 1.7f;

    private float currentSpeed;
    
    private bool running;

    private bool attacking;

    private Animator _animator;

    private float currentDistance;

    public int health = 100;
    
    public void Damage(int damageAmount)
    {
        health -= damageAmount;
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
        player = GameObject.Find("ZayaPlayer");
        Debug.Log(player.tag);

        target = player.transform;
        
        Debug.Log(health);
    }

    private void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        
        if (isEnemyInRange)
        {
            if (Vector3.Distance(transform.position, target.position) > distanceToStop)
            {
                transform.LookAt(target);
                _rigidbody.AddRelativeForce(Vector3.forward * speed);
            }
        }

        currentSpeed = _rigidbody.velocity.magnitude;
        currentDistance = Vector3.Distance(transform.position, target.position);

        _animator.SetFloat("currentSpeed", currentSpeed);
        _animator.SetFloat("currentDistance", currentDistance);
        
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + UtilsClass.GetRandomDir() * UnityEngine.Random.Range(10f, 70f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isEnemyInRange = true;
        }
    }
}

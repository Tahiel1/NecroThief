using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class NpcScript : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float stopTime = 5f;
    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        ChangeDirection();
    }

    public void HandleMovement()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void ChangeDirection()
    {

    }
}

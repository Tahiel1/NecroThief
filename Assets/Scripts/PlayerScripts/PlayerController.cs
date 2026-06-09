using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float currentIntTime=0f;
    [SerializeField] private float maxIntTime=3f;


    private void Start()
    {
        inputController = GetComponent<PlayerInputController>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    private void HandleMovement()
    {
        rb.linearVelocityY = (inputController.MoveData.y * speed) * Time.deltaTime;
        rb.linearVelocityX = (inputController.MoveData.x * speed) * Time.deltaTime;
    }

    private void HandleInteraction()
    {
        if(!inputController.IsInteracting && currentIntTime <= 0) return;

        if (inputController.IsInteracting && currentIntTime<maxIntTime)
        {
            currentIntTime = Time.time - inputController.InteractingStartTime;
        }
        else
        {
            if (currentIntTime<maxIntTime)
            {
                Debug.Log("Soltaste a tiempo");
            }
            currentIntTime = 0;
            Debug.Log("Dejaste de interactuar");
        }

    }
}

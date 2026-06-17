using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer playerSprite;

    [Header ("movement")]
    [SerializeField] private float speed;
    [SerializeField] private bool isDoingSomething = false;

    private void Start()
    {
        inputController = GetComponent<PlayerInputController>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (inputController.MoveData == null) return;

        rb.linearVelocityY = (inputController.MoveData.y * speed) * Time.deltaTime;
        rb.linearVelocityX = (inputController.MoveData.x * speed) * Time.deltaTime;

        if (inputController.MoveData.x > 0)
        {
            playerSprite.flipX = true;
        }
        else if (inputController.MoveData.x < 0)
        {
            playerSprite.flipX = false;
        }
    }

}

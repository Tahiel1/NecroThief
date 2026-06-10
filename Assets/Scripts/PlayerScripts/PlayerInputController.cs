using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [Header("Player Actions")]
    [SerializeField] private Vector2 moveData;
    [SerializeField] private bool isInteracting;
    [SerializeField] private bool isChanging;
    [SerializeField] private float interactingStartTime;

    private PlayerInput playerActions;

    public Vector2 MoveData => moveData;
    
    public bool IsInteracting => isInteracting;
    public float InteractingStartTime => interactingStartTime;

    private void Awake()
    {
        playerActions = new PlayerInput();
    }

    private void OnEnable()
    {
        playerActions.Player.Enable();

        playerActions.Player.Move.performed += OnMove;
        playerActions.Player.Move.canceled += OnMove;

        playerActions.Player.Interact.started += OnInteractStart;
        playerActions.Player.Interact.canceled += OnInteractEnd;

        playerActions.Player.ChangeInteract.performed += OnChange;
        playerActions.Player.ChangeInteract.canceled += OnChange;
    }

    private void OnDisable()
    {
        playerActions.Player.Move.performed -= OnMove;
        playerActions.Player.Move.canceled -= OnMove;

        playerActions.Player.Interact.performed -= OnInteractStart;
        playerActions.Player.Interact.canceled -= OnInteractEnd;

        playerActions.Player.ChangeInteract.performed -= OnChange;
        playerActions.Player.ChangeInteract.canceled -= OnChange;

        playerActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveData = ctx.ReadValue<Vector2>();
    }
    private void OnInteractStart(InputAction.CallbackContext ctx)
    {
        isInteracting = true;
        interactingStartTime = Time.time;
    }
    private void OnInteractEnd(InputAction.CallbackContext ctx)
    {
        isInteracting = false;
        interactingStartTime= Time.time;
    }

    private void OnChange(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            isChanging = true;
        else isChanging = false;
    }
}

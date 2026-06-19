using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    [Header("Player Actions")]
    [SerializeField] private Vector2 moveData;
    [SerializeField] private bool isInteracting;
    [SerializeField] private bool isChanging;
    [SerializeField] private float interactingStartTime;

    [Header("Tools")]
    [SerializeField] private GameObject pickPocket;
    [SerializeField] private GameObject tiefTools;
    [SerializeField] private GameObject slingShot;

    [SerializeField] private Tool activeTool;

    private Dictionary<int, GameObject> toolList = new Dictionary<int, GameObject>();

    private PlayerInput playerActions;

    public Vector2 MoveData => moveData;
    
    public bool IsInteracting => isInteracting;
    public float InteractingStartTime => interactingStartTime;

    private void Awake()
    {
        playerActions = new PlayerInput();
        
        toolList.Add(0, pickPocket);
        toolList.Add(1, tiefTools);
        toolList.Add(2, slingShot);

    }

    private void Update()
    {
        if(activeTool) activeTool.HandleInteraction();
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
        int numKeyValue;

        int.TryParse(ctx.control.name, out numKeyValue);

        
        SetActiveTool(numKeyValue);
    }

    private void SetActiveTool(int tool)
    {
        foreach (var (num,equipedtool) in toolList)
        {
            if ((tool - 1)== num)
            {
                equipedtool.SetActive(true);
                SetActiveInteraction(equipedtool.GetComponent<Tool>());
            }
            else
            {
                equipedtool.SetActive(false);
            }
            
        }
    }
    public void SetActiveInteraction(Tool newTool)
    {
        activeTool = newTool;
    }
}

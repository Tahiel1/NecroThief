using Unity.VisualScripting;
using UnityEngine;

public class Pickpoquet : CrossCollider
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private bool isStealing = false;

    [SerializeField] private float currentIntTime = 0f;
    [SerializeField] private float maxIntTime = 3f;
    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        if (!objectOnCross && !isStealing) return;
        
        bool playerPlayerPressInt = inputController.IsInteracting;

        if (playerPlayerPressInt && currentIntTime<maxIntTime)
        {
            currentIntTime = Time.time - inputController.InteractingStartTime;
            isStealing=true;
        }
        else
        {
            if (currentIntTime < maxIntTime)
            {
                Debug.Log("Soltaste a tiempo");
            }
            currentIntTime = 0;
            Debug.Log("Dejaste de interactuar");
        }
        if (!objectOnCross)
        {
            isStealing = false;
        }
    }
}

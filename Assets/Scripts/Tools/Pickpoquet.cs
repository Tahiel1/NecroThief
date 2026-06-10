using Unity.VisualScripting;
using UnityEngine;

public class Pickpoquet : CrossCollider
{
    [SerializeField] private PlayerInputController inputController;
    [SerializeField] private bool isStealing = false;

    [SerializeField] private float currentIntTime = 0f;
    [SerializeField] private float maxIntTime = 3f;
    [SerializeField] private float jusTimeMin = 1.9f;
    [SerializeField] private float jusTimeMax = 2.3f;
    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        bool playerPressIntOnNpc = inputController.IsInteracting && objectOnCross!=null;

        if(!playerPressIntOnNpc && !isStealing) return;

        if (playerPressIntOnNpc && currentIntTime < maxIntTime)
        {
            currentIntTime = Time.time - inputController.InteractingStartTime;
            if (currentIntTime < maxIntTime) isStealing=true;
            return;
        }
        else
        {
            if (currentIntTime>=jusTimeMin && currentIntTime<=jusTimeMax)
            {
                Debug.Log("Robaste");
            }
            else if(isStealing)
            {
                Debug.Log("No robaste");
                
            }
        }
        currentIntTime = 0;
        isStealing = false;
    }
}

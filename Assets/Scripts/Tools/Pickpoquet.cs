using Unity.VisualScripting;
using UnityEngine;

public class Pickpoquet : CrossCollider
{
    [SerializeField] protected PlayerInputController inputController;
    [SerializeField] protected bool isStealing = false;
    public bool IsStealing => isStealing;

    [SerializeField] protected float currentIntTime = 0f;
    [SerializeField] protected float maxIntTime = 3f;
    [SerializeField] protected float jusTimeMin = 1.9f;
    [SerializeField] protected float jusTimeMax = 2.3f;
    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    protected void HandleInteraction()
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
                GameController.Instance.AddScore(50);
            }
            else if(isStealing)
            {
                Debug.Log("No robaste");
                GameController.Instance.AddScore(50);

            }
        }
        currentIntTime = 0;
        isStealing = false;
    }
}

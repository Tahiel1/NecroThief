using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pickpoquet : CrossCollider
{
    [SerializeField] protected PlayerInputController inputController;
    [SerializeField] protected bool isStealing = false;
    public bool IsStealing => isStealing;

    [SerializeField] protected float currentIntTime = 0f;
    [SerializeField] protected float maxIntTime = 3f;
    [SerializeField] protected float jusTimeMin = 1.9f;
    [SerializeField] protected float jusTimeMax = 2.3f;

    [SerializeField] protected GameObject timerInt;
    [SerializeField] protected Scrollbar scrollbar;
    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    protected void HandleInteraction()
    {
        bool playerPressIntOnNpc = inputController.IsInteracting && objectOnCross!=null;

        if(!playerPressIntOnNpc && !isStealing)
        {
            timerInt.SetActive(false);
            return;
        }
        timerInt.SetActive(true);
        if (playerPressIntOnNpc && currentIntTime < maxIntTime)
        {
            currentIntTime = Time.time - inputController.InteractingStartTime;
            if (currentIntTime < maxIntTime) isStealing=true;
            scrollbar.value = Mathf.Lerp(0f, 1f, currentIntTime / maxIntTime);
            return;
        }
        else
        {
            if (currentIntTime>=jusTimeMin && currentIntTime<=jusTimeMax)
            {
                if (objectOnCross != null)
                {
                    Debug.Log("Robaste");
                    objectOnCross.GetComponent<IisStealable>().StealMoney();
                }
            }
            else if(isStealing)
            {
                if (objectOnCross != null)
                {
                    Debug.Log("No robaste");
                    objectOnCross.GetComponent<IisStealable>().FailSteal();
                }
            }
        }
        currentIntTime = 0;
        isStealing = false;
    }
}

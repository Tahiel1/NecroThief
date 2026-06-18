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

    [SerializeField] protected GameObject isSusCollider;
    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }

    protected virtual void HandleInteraction()
    {
        bool playerPressIntOnNpc = inputController.IsInteracting && objectOnCross!=null;

        if(!playerPressIntOnNpc && !isStealing)
        {
            timerInt.SetActive(false);
            isSusCollider.SetActive(false);
            return;
        }
        //Activo la barra de robo
        timerInt.SetActive(true);
        isSusCollider.SetActive(true);
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
                    Steal();
                }
            }
            else if(isStealing)
            {
                if (objectOnCross != null)
                {
                    DidntSteal();
                }
            }
        }
        currentIntTime = 0;
        isStealing = false;
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (isStealing)
        {
            Debug.Log("No robaste");
            objectOnCross.GetComponent<IisStealable>().FailSteal();
        }
        if (collision.gameObject == objectOnCross)
            objectOnCross = null;
    }

    protected virtual void Steal()
    {
        Debug.Log("Robaste");
        objectOnCross.GetComponent<IisStealable>().StealMoney();
    }
    public virtual void DidntSteal()
    {
        Debug.Log("No robaste");
        objectOnCross.GetComponent<IisStealable>().FailSteal();
        objectOnCross=null;
        isStealing=false;
    }
}

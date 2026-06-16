using Unity.VisualScripting;
using UnityEngine;

public class CrossCollider : MonoBehaviour
{
    [SerializeField] protected GameObject objectOnCross;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        IisStealable isStealable = collision.GetComponent<IisStealable>();
        bool canYouSteal = collision.GetComponent<IisStealable>().IsStealable();
        if(isStealable!=null&&canYouSteal)
            objectOnCross=collision.gameObject;
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject==objectOnCross)
            objectOnCross=null;
    }
}
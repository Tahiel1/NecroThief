using Unity.VisualScripting;
using UnityEngine;

public class CrossCollider : MonoBehaviour
{
    [SerializeField] protected GameObject objectOnCross;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        IisStealable isStealable = collision.GetComponent<IisStealable>();
        if(isStealable!=null && isStealable.IsStealable())
            objectOnCross=collision.gameObject;
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject==objectOnCross)
            objectOnCross=null;
    }
}
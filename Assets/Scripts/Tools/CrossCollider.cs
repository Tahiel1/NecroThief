using Unity.VisualScripting;
using UnityEngine;

public class CrossCollider : MonoBehaviour
{
    [SerializeField] protected GameObject objectOnCross;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        objectOnCross=collision.gameObject;
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        objectOnCross=null;
    }
}
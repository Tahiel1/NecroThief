using System;
using UnityEngine;

public class DestructibleObject : MonoBehaviour, ICanDestroy
{
    public static event Action<Vector3> OnObjectDestroyed;
    public void DestroyObject()
    {
        OnObjectDestroyed?.Invoke(transform.position);

        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.Pool;

public class SlingshotAmmo : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    public ObjectPool<SlingshotAmmo> pool;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICanDestroy canDestroy = collision.GetComponent<ICanDestroy>();
        if (canDestroy != null)
        {
            collision.GetComponent<ICanDestroy>().DestroyObject();
            Deactivate();
        }
        
    }

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Deactivate", 2); 
    }

    void Deactivate()
    {
        pool.Release(this);
    }
}

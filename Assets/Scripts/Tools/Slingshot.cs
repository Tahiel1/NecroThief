using UnityEngine;
using UnityEngine.Pool;

public class Slingshot : Tool, IisSus
{
    [SerializeField] float timeBetweenShots = 2f;
    [SerializeField] float timeLastShoot = 0f;

    [SerializeField] protected PlayerInputController inputController;

    [SerializeField] private SlingshotAmmo bullet;
    [SerializeField] private Transform barrelTransform;

    ObjectPool<SlingshotAmmo> ammoPool;

    private void Awake()
    {
        ammoPool = new ObjectPool<SlingshotAmmo>(CreateNewBullet,GetBullet,ReturnBullet,DestroyBullet, false, 10, 100);
    }

    SlingshotAmmo CreateNewBullet()
    {
        SlingshotAmmo newBullet = Instantiate(bullet);
        newBullet.pool = ammoPool;
        return newBullet;
    }

    void GetBullet(SlingshotAmmo bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    void ReturnBullet(SlingshotAmmo bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    void DestroyBullet(SlingshotAmmo bullet)
    {
        Destroy(bullet.gameObject);
    }

    public override void HandleInteraction()
    {
        if (inputController.IsInteracting && timeLastShoot>=timeBetweenShots)
        {
            SlingshotAmmo newBullet = ammoPool.Get();
            newBullet.transform.position = barrelTransform.position;
            newBullet.transform.rotation = barrelTransform.rotation;
            timeLastShoot = 0;
        }
        else
        {
            timeLastShoot += Time.deltaTime;
        }
    }
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
    }
}

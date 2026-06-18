using Unity.VisualScripting;
using UnityEngine;

public class Slingshot : CrossAirPos, IisSus
{
    [SerializeField] float timeBetweenShots = 2f;
    [SerializeField] float timeLastShoot = 0f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrelTransform;


    private void Update()
    {
        HandleShot();
    }
    private void HandleShot()
    {
        if (inputController.IsInteracting && timeLastShoot>=timeBetweenShots)
        {
            Instantiate(bullet, barrelTransform.position, barrelTransform.rotation);
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

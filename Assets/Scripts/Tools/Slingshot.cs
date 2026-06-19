using Unity.VisualScripting;
using UnityEngine;

public class Slingshot : Tool, IisSus
{
    [SerializeField] float timeBetweenShots = 2f;
    [SerializeField] float timeLastShoot = 0f;

    [SerializeField] protected PlayerInputController inputController;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrelTransform;

    public override void HandleInteraction()
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

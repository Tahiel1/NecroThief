using Unity.VisualScripting;
using UnityEngine;

public class Slingshot : CrossAirPos, IisSus
{
    [SerializeField] float timeBetweenShots = 1.5f;
    [SerializeField] float timeLastShoot = 0f;

    [SerializeField] private GameObject bullet;


    private void Update()
    {
        HandleShot();
    }
    private void HandleShot()
    {
        if (inputController.IsInteracting)
        {
            Instantiate(bullet);
        }
    }
    public void addSus(int amount)
    {
        GameController.Instance.UpdateSuspicion(amount);
    }
}

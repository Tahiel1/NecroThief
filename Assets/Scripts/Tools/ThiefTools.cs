using UnityEngine;

public class ThiefTools : Pickpoquet, IisSus
{
    public void addSus(int amount)
    {
        Debug.Log("Sumando a la sospecha " + amount + " puntos.");
    }
}

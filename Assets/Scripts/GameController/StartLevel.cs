using System;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    [SerializeField] int level=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.Instance.SetScoreStarLevel(level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private bool isGameRunning;
    [SerializeField] private Transform panelUpdateIndexHorse;
    private FinishLevel updateUIIndexHorse;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    private void Start()
    {
        updateUIIndexHorse = FindObjectOfType<FinishLevel>();
    }

    private void Update()
    {
        updateUIIndexHorse.ShowAllIndexHorse(panelUpdateIndexHorse);
    }

    public void StartingGame()
    {
        isGameRunning = true;
    }

    public bool IsGameRunning()
    {
        return isGameRunning;
    }
}

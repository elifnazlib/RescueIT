using UnityEngine;
using TMPro;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    public float milkAmount = 100;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public enum CharacterType
    {
        Hundreds = 100,
        Tens = 10,
        One = 1
    };

    public GameObject hundredsPlaceHolderPrefab;
    public GameObject tensPlaceHolderPrefab;

    // Object declared as a singleton, can be accessed using LevelManager.Instance from anywhere
    private static LevelManager instance = null;
    public static LevelManager Instance
    { 
        get { return instance; }
    }

    // Ensures two copies of the singleton do not exist
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }

}

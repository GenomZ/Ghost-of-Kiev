using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool s_permanentInstance = true;  // set to true if you ever only want *one* instance among all scenes and drop an instance of GameManager in your first scene you load
    public static GameManager Instance { get; private set; }


    public TMPro.TMP_Text russian_losses;
    public float i_russian_losses = 0;

    private void Awake()
    {
        if (s_permanentInstance)
        {
            if (Instance != null)
            {
                Debug.LogError("GameManager initialized twice, overwriting");
            }
            DontDestroyOnLoad(this);  // prevents this from being destroyed on scene load
        }
        // store the singleton reference
        Instance = this;
    }
    void Start()
    {
        russian_losses.text = "Russias losses: "  + i_russian_losses + " mil $";
    }

    // Update is called once per frame
    void Update()
    {
        if (i_russian_losses < 1000)
        {
            russian_losses.text = "Russias losses: " + i_russian_losses + " mil $";
        }
        if (i_russian_losses >= 1000000)
        {
            russian_losses.text = "Russias losses: " + i_russian_losses + " bil $";
        }
        if (i_russian_losses >= 1000000000)
        {
            russian_losses.text = "Russias losses: " + i_russian_losses + " quad $";
        }
        if (i_russian_losses >= 1000000000000)
        {
            russian_losses.text = "Russias losses: " + i_russian_losses + " quint $";
        }
        if (i_russian_losses >= 1000000000000000)
        {
            russian_losses.text = "Russias losses: " + i_russian_losses + " sixtil $";
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI WinTMP;
    public TextMeshProUGUI LoseTMP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WinTMP.enabled = false;
        LoseTMP.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWinLabel()
    {
        LoseTMP.enabled = false;
        WinTMP.enabled = true;
    }

    public void setLoseLabel()
    {
        WinTMP.enabled = false;
        LoseTMP.enabled = true;
    }
}

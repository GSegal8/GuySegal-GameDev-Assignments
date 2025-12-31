using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Player;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject MainMenu;
    
    public static GameManager Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject);

        PauseGame();

    }
    public void ShowEndGame(bool playerWon)
    {
        gameOverUI.gameObject.SetActive(true);
        if (playerWon)
        {
            gameOverText.text = "YOU WON!";
            gameOverText.color = Color.green;
        }
        else
        {
            gameOverText.text = "YOU LOSE";
            gameOverText.color = Color.red;
        }
        Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameOverUI.gameObject.SetActive(false);
        MainMenu.SetActive(false);
        HUD.SetActive(true);
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        gameOverUI.gameObject.SetActive(false);
        MainMenu.SetActive(true);
        HUD.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

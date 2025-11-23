using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject HUD;
    public GameObject player;
    public int scoreToWin = 1000;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private GameObject CoinSpawner;
    private PlayerScript _playerScript;
    private GameOverMenu _gameOverMenu;

    void Start()
    {
        _gameOverMenu = GameOverMenu.GetComponent<GameOverMenu>();
        _playerScript = player.GetComponent<PlayerScript>();
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // make sure there’s only one
            return;
        }

        Instance = this;
        PauseGame();
        GameOverMenu.SetActive(false); 
       
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        CoinSpawner.SetActive(false);
        PauseMenu.SetActive(true);
        HUD.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        CoinSpawner.SetActive(true);
        PauseMenu.SetActive(false);
        HUD.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
             Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        checkWin();
    }
    public void checkWin()
    {
        if (_playerScript.score >= scoreToWin)
        {
            Time.timeScale = 0;
            CoinSpawner.SetActive(false);
            HUD.SetActive(false);
            _gameOverMenu.setWinLabel();
            GameOverMenu.SetActive(true);
        }
    }
    public void lostGame()
    {
        Time.timeScale = 0;
        CoinSpawner.SetActive(false);
        HUD.SetActive(false);
        _gameOverMenu.setLoseLabel();
        GameOverMenu.SetActive(true);
    }
}
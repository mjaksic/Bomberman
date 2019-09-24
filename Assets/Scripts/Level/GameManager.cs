using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour {

    private float time_left;
    private bool isPaused = false;
    private int player1health;
    private int player2health;

    [SerializeField]
    private GameObject gameplaySong;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject eventMenu;
    [SerializeField]
    public TextMeshProUGUI conclusionText;
    public GameObject player1;
    public GameObject player2;
    public TextMeshProUGUI p1Health;
    public TextMeshProUGUI p2Health;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                FindObjectOfType<UI_Timer>().GetIsPaused(isPaused);
                pauseMenu.SetActive(true);
            }
            else if(isPaused == true)
            {
                Time.timeScale = 1;
                isPaused = false;
                FindObjectOfType<UI_Timer>().GetIsPaused(isPaused);
                pauseMenu.SetActive(false);
            }

        }

        if(player1health > 0 && player2health <= 0 && time_left > 0)
        {
            conclusionText.text = "Player 1 WINS!";
            FindObjectOfType<UI_Timer>().GetIsPaused(isPaused);
            eventMenu.SetActive(true);
            gameplaySong.SetActive(false);
        }
        else if(player2health > 0 && player1health <= 0 && time_left > 0)
        {
            conclusionText.text = "Player 2 WINS!";
            FindObjectOfType<UI_Timer>().GetIsPaused(isPaused);
            eventMenu.SetActive(true);
            gameplaySong.SetActive(false);
        }
        else if(time_left <= 0 || player1health <= 0 && player2health <= 0)
        {
            conclusionText.text = "DRAW!";
            FindObjectOfType<UI_Timer>().GetIsPaused(isPaused);
            eventMenu.SetActive(true);
            gameplaySong.SetActive(false);

        }
    }

    public void GetP1Health(int health)
    {
        player1health = health;
        p1Health.text = "Player 1 Health\n" + player1health.ToString();
    }

    public void GetP2Health(int health)
    {
        player2health = health;
        p2Health.text = "Player 2 Health\n" + player2health.ToString();
    }

    public void GetTimer(float time)
    {
        time_left = time;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void IsPaused()
    {
        Time.timeScale = 1;
        isPaused = false;
        FindObjectOfType<UI_Timer>().GetIsPaused(isPaused);
        pauseMenu.SetActive(false);
    }
}

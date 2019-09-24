using UnityEngine;
using TMPro;

public class UI_Timer : MonoBehaviour {

    private TextMeshProUGUI countdown;
    private bool isPaused;

    [SerializeField]
    private float timer;

    void Start () {
        countdown = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<GameManager>().GetTimer(timer);
    }
	
	void Update () {
        if (isPaused == false)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            countdown.text = "0";
            FindObjectOfType<GameManager>().GetTimer(0);
        }

        else
        {
            FindObjectOfType<GameManager>().GetTimer(timer);
            countdown.text = Mathf.Round(timer).ToString();
        }
	}

    public void GetIsPaused(bool isPaused)
    {
        this.isPaused = isPaused;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.EventSystems;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI passedLabel;
    [SerializeField]
    private GameObject alert;
    [SerializeField]
    private TMPro.TextMeshProUGUI alertLabel;
    [SerializeField]
    private TMPro.TextMeshProUGUI livesLabel;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private TMPro.TextMeshProUGUI gameOverLabel;

    private Rigidbody2D rigidBody; // Reference на компонент того же ГО, на якому скрипт
    private int score;
    private bool needClear;
    private int lives;
    void Start()
    {
        Debug.Log("BirdScript Start");
        // пошук компонента та одержання посилання на нього 
        rigidBody = GetComponent<Rigidbody2D>();
        score = 0;
        needClear = false;
        lives = 3;
        HideAlert();
        HideGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, 300) * Time.timeScale);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (alert.activeSelf) { HideAlert(); }
            else { ShowAlert("Paused!"); }
        }
    }

    /* Подія, що виникає при перетині колайдерів-тригерів */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            lives--;
            livesLabel.text = lives.ToString();
            if (lives == 0)
            {
                ShowGameOver();
                return;
            }
            Debug.Log("Collision!! " + other.gameObject.name);
            ShowAlert("OOOPS!");
        }
        else if(other.gameObject.CompareTag("Bonus"))
        {
            lives++;
            livesLabel.text = lives.ToString();
            Debug.Log("+1 LIFE!! " + other.gameObject.name);
            foreach (var bonus in GameObject.FindGameObjectsWithTag("Bonus"))
            {
                GameObject.Destroy(bonus);
            }
        }
    }
    /* Подія, що виникає при роз'єднанні колайдерів-тригерів */
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pass"))
        {
            Debug.Log("+1");
            score++;
            passedLabel.text = score.ToString("D3");
        }
    }
    private void ShowAlert(string message)
    {
        alert.SetActive(true);
        alertLabel.text = message;
        Time.timeScale= 0f;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void HideAlert()
    {
        alert.SetActive(false);
        Time.timeScale = 1f;
        if(needClear)
        {
            foreach(var pipe in GameObject.FindGameObjectsWithTag("Pass"))
            {
                GameObject.Destroy(pipe);
            }
            needClear = false;
        }
    }
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("Игра завершена!");
    }
    IEnumerator QuitGameAfterDelay(float delay)
    {
        // Ожидать заданное количество секунд
        yield return new WaitForSecondsRealtime(delay);
        QuitGame();
    }
    private void ShowGameOver()
    {
        gameOver.SetActive(true);
        gameOverLabel.text = "GAME OVER!!!";
        Time.timeScale = 0f;
        StartCoroutine(QuitGameAfterDelay(5f));
    }
    private void HideGameOver()
    {
        gameOver.SetActive(false);
        Time.timeScale = 1f;
    }
}

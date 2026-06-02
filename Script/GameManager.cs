using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject finishPanel;

    [Header("UI Text Display")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI bestTimeText;

    [Header("Audio SFX")] // Tambahan baru untuk suara
    public AudioSource winSFX;
    public AudioSource loseSFX;

    private float startTime;
    private bool isFinished = false;

    void Start()
    {
        startTime = Time.time;
        if (finishPanel != null) finishPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!isFinished)
        {
            float t = Time.time - startTime;
            timerText.text = t.ToString("F2") + "s";
        }
    }

    public void WinGame()
    {
        if (isFinished) return;
        isFinished = true;

        // Putar suara menang
        if (winSFX != null) winSFX.Play();

        float finalTime = Time.time - startTime;
        float bestTime = PlayerPrefs.GetFloat("BestTime", 999f);

        if (finalTime < bestTime)
        {
            bestTime = finalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            resultText.text = "REKOR BARU! " + finalTime.ToString("F2") + "s";
        }
        else
        {
            resultText.text = "Waktu Kamu: " + finalTime.ToString("F2") + "s";
        }

        bestTimeText.text = "Tercepat: " + bestTime.ToString("F2") + "s";
        if (finishPanel != null) finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void EndGame()
    {
        if (isFinished) return;
        isFinished = true;

        // Putar suara kalah
        if (loseSFX != null) loseSFX.Play();

        float bestTime = PlayerPrefs.GetFloat("BestTime", 999f);
        resultText.text = "";

        if (bestTime < 999f)
            bestTimeText.text = "Best Time: " + bestTime.ToString("F2") + "s";
        else
            bestTimeText.text = "Belum ada rekor";

        if (finishPanel != null) finishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}
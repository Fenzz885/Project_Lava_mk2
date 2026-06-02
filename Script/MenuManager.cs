using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditPanel;

    // Langsung mulai ke game utama
    public void StartGame()
    {
        // Pastikan nama scene game kamu adalah "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }

    // Buka tutup panel credit
    public void ToggleCredit(bool show)
    {
        creditPanel.SetActive(show);
    }

    // Keluar dari aplikasi
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Keluar");
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text deathCounterText;

    private void Start()
    {
        int totalDeaths = PlayerPrefs.GetInt("TotalDeaths", 0);

        deathCounterText.text = "Total Deaths: " + totalDeaths;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public GameObject topGUI;

    public Button pauseBtn;

    public Dialog gameDialog;
    public Dialog pauseDialog;
    public TextMeshProUGUI killedCountingText;

    Dialog m_curDialog;

    public Dialog CurDialog { get => m_curDialog; set => m_curDialog = value; }

    public override void Awake()
    {
        MakeSingleton(false);
        topGUI.gameObject.SetActive(false);
        gameDialog.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(false);
    }

    public override void Start()
    {
        killedCountingText.text = "x0";
    }

    public void ShowGameGUI(bool isShow)
    {
        if (topGUI) topGUI.SetActive(isShow);
        if (gameGUI) gameGUI.SetActive(isShow);
        if (homeGUI) homeGUI.SetActive(!isShow);
    }

    public void ShowPauseButton(bool isShow)
    {
        pauseBtn.gameObject.SetActive(isShow);
    }

    public void UpdatekilledCounting(int killed)
    {
        if (killedCountingText)
            killedCountingText.text = "x" + killed.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioController.instance.ClickButtonSound();
        if (pauseDialog)
        {
            pauseBtn.gameObject.SetActive(false);
            m_curDialog = pauseDialog;
            pauseDialog.Show(true);
            pauseDialog.UpdateDialog("Your Score : ", "Best Killed : x" + Manager.Ins.m_enemyKilled, "Survival time : " + Manager.Ins.timeLife + "s");
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioController.instance.ClickButtonSound();
        if (m_curDialog)
        {
            pauseBtn.gameObject.SetActive(true);
            m_curDialog.Show(false);
        }
    }

    public void BacktoHome()
    {
        AudioController.instance.ClickButtonSound();
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        AudioController.instance.ClickButtonSound();
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

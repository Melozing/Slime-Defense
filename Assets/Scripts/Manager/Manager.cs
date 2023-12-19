using System.Collections;
using TMPro;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    [SerializeField] private Transform tanker;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private float radius = 6.0f;

    public int m_enemyKilled;
    public bool m_isGameover;
    public bool m_isPlay = false;
    float spawnTime = 5f;

    public int timeLife { get; private set; }
    public int EnemyKilled { get => m_enemyKilled; set => m_enemyKilled = value; }

    [SerializeField] private TextMeshProUGUI score;

    public override void Awake()
    {
        MakeSingleton(false);
        score.text = "0s";
    }

    public override void Start()
    {
        GameGUIManager.Ins.ShowGameGUI(false);
        GameGUIManager.Ins.UpdatekilledCounting(timeLife);
    }

    public void PlayGame()
    {
        m_isPlay = true;
        GameGUIManager.Ins.ShowGameGUI(true);
        GameGUIManager.Ins.ShowPauseButton(true);
        InvokeRepeating("IncreaseCount", 1f, 1f);
        StartCoroutine(GameSpawn());
    }

    private void IncreaseCount()
    {
        if (m_isGameover) return;
        timeLife++;
        score.text = timeLife.ToString() + "s";
    }

    IEnumerator GameSpawn()
    {
        while (!m_isGameover)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnTime);
        }
    }


    public void SpawnEnemy()
    {
        if (timeLife < 30)
        {
            for (int i = 0; i < 6; i++)
            {
                float angle = UnityEngine.Random.Range(0, 360);
                float xOffset = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                float yOffset = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

                Vector3 spawnPosition = tanker.position + new Vector3(xOffset, yOffset);
                Instantiate(enemy1, spawnPosition, Quaternion.identity);
            }
        }
        else if (timeLife > 30 && timeLife < 100)
        {
            for (int i = 0; i < 7; i++)
            {
                float angle = UnityEngine.Random.Range(0, 360);
                float xOffset = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                float yOffset = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

                Vector3 spawnPosition = tanker.position + new Vector3(xOffset, yOffset);
                Instantiate(enemy2, spawnPosition, Quaternion.identity);
            }
        }
    }
}

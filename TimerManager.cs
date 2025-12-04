using System;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [Header("Timer Settings")]
    public float totalTime = 60f;
    private float remainingTime;
    private bool hasTriggeredGameOver = false;
    private bool hasFired = false;
    [Header("Game Over Effects")]
    [SerializeField] private AudioSource stormAudio;
    [SerializeField] private GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        gameOverUI.SetActive(false);

        remainingTime = totalTime;
        UpdateUI();
    }

    void Update()
    {
        if (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            UpdateUI();
        }
        else if (!hasTriggeredGameOver)
        {
            remainingTime = 0f;
           
            TriggerGameOver();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (UIManager.Instance != null)
            UIManager.Instance.UpdateTimer(remainingTime.ToString("F0")); // Rounded seconds
    }

    public void AddTime(float extraTime)
    {
        remainingTime += extraTime;
        UpdateUI();
    }

    void TriggerGameOver()
    {
        hasTriggeredGameOver = true;

        if (stormAudio != null)
            stormAudio.Play();

        if (gameOverUI != null)
            gameOverUI.SetActive(true);


        Debug.Log("Time's up! Game Over.");
    }
}
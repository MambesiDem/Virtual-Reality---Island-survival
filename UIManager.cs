using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public TextMeshProUGUI logsText;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI timerText;

    void Awake() { Instance = this; }

    public void UpdateInventory(Dictionary<string, int> items)
    {
        int logs = items.ContainsKey("Log") ? items["Log"] : 0;
        logsText.text = "Logs: " + logs;
    }

    public void ShowMessage(string msg, float time = 3f)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(msg, time));
    }

    IEnumerator ShowRoutine(string msg, float time)
    {
        messageText.text = msg;
        yield return new WaitForSeconds(time);
        messageText.text = "";
    }
    public void UpdateTimer(string time)
    {
        timerText.text = "TR: " + time;
    }
}

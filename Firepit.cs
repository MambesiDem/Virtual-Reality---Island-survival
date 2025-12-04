using UnityEngine;

public class Firepit : Interactable
{
    [Header("Fire Settings")]
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private Light fireLight;
    [SerializeField] private AudioSource fireAudio;
    [SerializeField] private float burnDuration = 30f;

    [Header("Log Visuals")]
    [SerializeField] private Transform logDropPoint;         // Where logs appear
    [SerializeField] private GameObject logVisualPrefab;     // Log model to instantiate

    private float burnTimer = 0f;
    private bool isBurning = false;
    private int visualLogCount = 0;

    public override void OnInteract()
    {
        if (Inventory.Instance.UseItem("Log", 1))
        {
            UIManager.Instance.ShowMessage("You added a log to the fire!");

            if (!isBurning)
            {
                StartFire();
            }
            else
            {
                burnTimer += burnDuration; // Extend fire time
            }

            TimerManager.Instance.AddTime(30f); // Add survival time

            // Drop visual log with stacking offset
            if (logDropPoint != null && logVisualPrefab != null)
            {
                Vector3 offset = new Vector3(0f, 0.1f * visualLogCount, 0f); // stack upward
                GameObject logInstance = Instantiate(logVisualPrefab, logDropPoint.position + offset, logDropPoint.rotation, logDropPoint);
                visualLogCount++;
            }
        }
        else
        {
            UIManager.Instance.ShowMessage("You have no logs!");
        }
    }

    void Update()
    {
        if (isBurning)
        {
            burnTimer -= Time.deltaTime;
            if (burnTimer <= 0f)
            {
                StopFire();
            }
        }
    }

    void StartFire()
    {
        isBurning = true;
        burnTimer = burnDuration;

        if (fireEffect != null) fireEffect.Play();
        if (fireLight != null) fireLight.enabled = true;
        if (fireAudio != null) fireAudio.Play();
    }

    void StopFire()
    {
        isBurning = false;
        visualLogCount = 0;

        // Clear visual logs
        foreach (Transform child in logDropPoint)
        {
            Destroy(child.gameObject);
        }

        if (fireEffect != null) fireEffect.Stop();
        if (fireLight != null) fireLight.enabled = false;
        if (fireAudio != null) fireAudio.Stop();
    }
}


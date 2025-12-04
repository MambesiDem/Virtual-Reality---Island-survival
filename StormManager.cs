//using System.Collections;
//using UnityEngine;

//public class StormManager : MonoBehaviour
//{
//    [Tooltip("Seconds until storm begins")]
//    public float stormTime = 300f; // you can change in inspector

//    public ParticleSystem rainParticles;
//    public AudioSource thunderAudio;

//    public GameObject rescuePrefab;
//    public Transform rescueSpawnPoint;

//    float timer = 0f;
//    bool stormStarted = false;

//    void Update()
//    {
//        if (stormStarted) return;

//        timer += Time.deltaTime;
//        UIManager.Instance?.UpdateTimer(Mathf.Max(0f, stormTime - timer));

//        if (timer >= stormTime)
//        {
//            StartCoroutine(BeginStorm());
//        }
//    }

//    IEnumerator BeginStorm()
//    {
//        stormStarted = true;
//        if (rainParticles != null) rainParticles.Play();
//        if (thunderAudio != null) thunderAudio.Play();

//        UIManager.Instance?.ShowMessage("Storm started!");

//        yield return new WaitForSeconds(2f);

//        // Check if any firepit is lit
//        Firepit fp = FindObjectOfType<Firepit>();
//        if (fp != null && fp.IsLit)
//        {
//            UIManager.Instance?.ShowMessage("Signal noticed! Rescue incoming...");
//            SpawnRescue();
//        }
//        else
//        {
//            UIManager.Instance?.ShowMessage("No signal — rescue missed.");
//        }
//    }

//    void SpawnRescue()
//    {
//        if (rescuePrefab != null && rescueSpawnPoint != null)
//            Instantiate(rescuePrefab, rescueSpawnPoint.position, rescueSpawnPoint.rotation);
//    }
//}

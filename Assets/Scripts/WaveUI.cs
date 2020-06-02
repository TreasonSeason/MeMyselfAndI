using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    WaveSpawner spawner;

    [SerializeField]
    Animator waveAnimator;

    [SerializeField]
    TextMeshProUGUI waveCountdownText;

    [SerializeField]
    TextMeshProUGUI waveCountText;
    private WaveSpawner.SpawnState previousState;

    void Start()
    {
        if (spawner == null)
        {

            Debug.LogError("No spawner referenced!");     
        }
        if (waveAnimator == null)
        {

            Debug.LogError("No waveanimator referenced!");
        }
        if (waveCountdownText == null)
        {

            Debug.LogError("No waveCountdownText referenced!");
        }
        if (waveCountText == null)
        {

            Debug.LogError("No waveCountText referenced!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (spawner.State)
        {
            case WaveSpawner.SpawnState.COUNTING:
                UpdateCountingdownUI();
                break;
            case WaveSpawner.SpawnState.SPAWNING:
                UpdateSpawningUI();
                break;

        }
        previousState = spawner.State;
    }
    void UpdateCountingdownUI()
    {
        if (previousState != WaveSpawner.SpawnState.COUNTING)
        {
            waveAnimator.SetBool("WaveIncoming", false);
            waveAnimator.SetBool("WaveCountdown", true);
           Debug.Log("COUNTING");
        }
        waveCountdownText.text = ((int)spawner.WaveCountdown).ToString();
    
    }
    void UpdateSpawningUI()
    {
        if (previousState != WaveSpawner.SpawnState.SPAWNING)
        {
            waveAnimator.SetBool("WaveIncoming", true);
            waveAnimator.SetBool("WaveCountdown", false);
            Debug.Log("SPAWNING");
            waveCountText.text = (spawner.NextWave).ToString();
        }
        
    }
}

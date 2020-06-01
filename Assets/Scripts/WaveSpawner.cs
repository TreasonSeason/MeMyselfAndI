using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public int NextWave
    {
        get { return nextWave+1; }
    }

    public Transform[] spawnpoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    public float WaveCountdown
    {
        get { return waveCountdown+1; }
    }

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;
    public SpawnState State
    {
        get{ return state; }
    }

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        if (spawnpoints.Length == 0)
        {
            Debug.Log("NO SPAWNPOINTS");
        }
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            //check if enemies are alive
            if (!EnemyIsAlive())
            {
                waveCompleted();
            }
            else return;
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Start wave
                StartCoroutine(spawnWave(waves[nextWave]));
            }
        }
        else
        {
            //PRINTINT waveCountdown KINTAMAJI SUAPVALINUS IKI VIENO SKAICIAUS PO NULIO --------------------------------------------------------------------------
            waveCountdown -= Time.deltaTime;
        }
    }

    private void waveCompleted()
    {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            //BAIGESI VISOS BANGOS- ------------------------------------------------------------------------------------------------
            //Victory screen + nauja planeta atrakinta
            Debug.Log("All waves completed, looping...");
        }
        else
        {
            nextWave++;
            //NAUJAS ROUNDAS ------------------------------------------------------------------------------
        }

    }

    private bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {

                return false;
            }
        }
        return true;
    }

    IEnumerator spawnWave(Wave _wave)
    {
        //NAUJA BANGA PRASIDEDA _wave.name YRA BANGOS PAVADINIMAS JEIGU NORESI JOS PAVADINIMA  NAUDOT ----------------------------------------------
        Debug.Log("Spawning wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            spawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    private void spawnEnemy(GameObject[] _enemy)
    {
        for(int i = 0; i < _enemy.Length; i++)
        {
            Transform sp = spawnpoints[Random.Range(0, spawnpoints.Length)];
            Instantiate(_enemy[i], sp.position, sp.rotation);
            Debug.Log("Spawning: " + _enemy[i].name);
        }
        
    }
}

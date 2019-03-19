using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    public float timeBetweenSpawn;
    public float spawnTime;
    public float spawnRadius;

    public EnemyController enemy;
    public Transform spawnPoint;

    public float numberEnemyPerWave;
    public float numberSpawned;

    public float timeBetweenWaves;
    public float elapsedTime;

    public int wave;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (numberSpawned < numberEnemyPerWave && spawnTime <= 0)
        {
            spawnTime = timeBetweenSpawn;
            float angle = Random.Range(0, 360);

            Vector3 position = new Vector3(this.spawnRadius * Mathf.Cos(angle), spawnRadius * Mathf.Sin(angle), 0);
            EnemyController newEnemy = Instantiate(enemy, position, Quaternion.Euler(0, 0, 0)) as EnemyController;

            SetNewEnemy(newEnemy);
            numberSpawned++;
        }
        if (numberSpawned >= numberEnemyPerWave)
        {
            if (elapsedTime >= timeBetweenWaves)
            {
                elapsedTime = 0;
                wave++;
                numberEnemyPerWave = Mathf.Floor(numberEnemyPerWave * 1.041f * wave);
                numberSpawned = 0;
            }
            elapsedTime += Time.deltaTime;
        }
    }

    private void SetNewEnemy(EnemyController enemy)
    {
        int enemyLevel = Random.Range(wave / 2, wave);

        enemy.level = enemyLevel;
    }
}

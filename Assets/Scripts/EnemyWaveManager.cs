using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attacks;

public class EnemyWaveManager : MonoBehaviour
{
    #region Variables

    private List<GameObject> enemies;
    public GameObject enemyPrefab;

    public float minPos = -5f;
    public float maxPos = 5f;

    public int wave = 1;

    public System.Timers.Timer timer;

    public float spawnTimer = 2;

    public float timerMax = 2;

    public float timerInterval = 2;

    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        SpawnEnemy();

        timer = new System.Timers.Timer(timerInterval * 1000);
        timer.Enabled = true;
        timer.Elapsed += (object sender, System.Timers.ElapsedEventArgs e) => spawnTimer -= .2f;
    }

    private void Update()
    {
        if (spawnTimer <= 0)
        {
            if (timerMax >= .5)
            {
                timerMax -= .2f;
            }

            SpawnEnemy();

            spawnTimer = timerMax;
        }
    }

    #endregion Unity Methods

    #region Public Methods

    public void SpawnEnemy()
    {
        var pos = new Vector3(Random.Range(minPos, maxPos), Random.Range(minPos, maxPos), 0);

        enemies.Add(Instantiate(enemyPrefab, pos, Quaternion.identity));
        var enemy = enemies[enemies.Count + 1];
        var enemyScript = enemy.GetComponent<Enemy>();
        var enemyAttack = enemy.GetComponent<Attack>();

        enemyAttack.attackState = (Attack.AttackState)Random.Range(0, 3);
        enemyScript.timerInterval = Random.Range(.5f, 3f);
    }

    #endregion Public Methods
}
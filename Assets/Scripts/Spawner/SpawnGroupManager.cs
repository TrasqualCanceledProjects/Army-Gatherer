using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroupManager
{
    public List<GameObject> spawnedFriendlies = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private void OnEnemyProvokedCallback(Transform target)
    {
        foreach (var enemy in spawnedEnemies)
        {
            enemy.GetComponent<EnemyController>().SetTarget(target);
        }
    }

    public void AddFriendly(GameObject friendly)
    {
        spawnedFriendlies.Add(friendly);
    }

    public void AddEnemy(GameObject enemy)
    {
        spawnedEnemies.Add(enemy);
        enemy.GetComponent<EnemyController>().OnProvoked += OnEnemyProvokedCallback;
        enemy.GetComponent<EnemyController>().OnDeath += RemoveEnemy;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        var enemyController = enemy.GetComponent<EnemyController>();
        enemyController.OnProvoked -= OnEnemyProvokedCallback;
        enemyController.OnDeath -= RemoveEnemy;
        spawnedEnemies.Remove(enemy);
        if(spawnedEnemies.Count == 0)
        {
            ReleaseFriendlies();
        }
    }

    private void ReleaseFriendlies()
    {
        RemoveFriendlies();
    }

    private void RemoveFriendlies()
    {
        spawnedFriendlies.Clear();
    }
}

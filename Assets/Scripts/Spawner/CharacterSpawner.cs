using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameObject friendlyPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private int amountOfEnemiesToSpawn = 3;
    [SerializeField] private int amountOfFriendliesToSpawn = 1;
    [SerializeField] private int multiplierForCharactersPerRing = 5;
    [SerializeField] private int distanceBetweenRings = 5;

    public List<GameObject> spawnedFriendlies = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        var friendlyAndEmptySlots = Utilities.CalculateIncrementalValue(1, AmountOfRings(amountOfFriendliesToSpawn,multiplierForCharactersPerRing), multiplierForCharactersPerRing);
        var totalSpawnSlots = friendlyAndEmptySlots + amountOfEnemiesToSpawn;
        var spawnPositions = GetSpawnPositions(transform.position, distanceBetweenRings, totalSpawnSlots, true);

        for (int i = 0; i < amountOfFriendliesToSpawn; i++)
        {
            var spawnedFriendly = Instantiate(friendlyPrefab, spawnPositions[i], SpawnRotation(spawnPositions[i]));
            spawnedFriendlies.Add(spawnedFriendly);
        }        

        for (int i = friendlyAndEmptySlots; i < totalSpawnSlots; i++)
        {
            var spawnedEnemy = Instantiate(enemyPrefab, spawnPositions[i], SpawnRotation(spawnPositions[i]));
            spawnedEnemies.Add(spawnedEnemy);
        }
    }

    private List<Vector3> GetSpawnPositions(Vector3 startPosition, float distanceBetweenRings, int amountOfCharactersToSpawn, bool includeStartPosition)
    {
        List<Vector3> positionList = new List<Vector3>();
        if (includeStartPosition) positionList.Add(startPosition);
        int totalRingSpawn = AmountOfRings(amountOfCharactersToSpawn, multiplierForCharactersPerRing);
        for (int i = 0; i < totalRingSpawn; i++)
        {
            positionList.AddRange(GetSpawnPositionsOnSingleRing(startPosition, distanceBetweenRings*i, multiplierForCharactersPerRing*i));
        }
        return positionList;
    }

    private List<Vector3> GetSpawnPositionsOnSingleRing(Vector3 startPosition, float distance, int positionCount)
    {
        List<Vector3> positionList = new List<Vector3>();
        for (int i = 0; i < positionCount; i++)
        {
            float angle = i * (360f / positionCount);
            Vector3 dir = ApplyRotationToVector(Vector3.back, angle);

            Vector3 position = startPosition + dir * distance;
            positionList.Add(position);
        }
        return positionList;
    }

    private Vector3 ApplyRotationToVector(Vector3 vector3, float angle)
    {
        return Quaternion.Euler(0, angle, 0) * vector3;
    }

    private int AmountOfRings(int spawnAmount, int incrementAmount)
    {
        int f = spawnAmount - 1;
        int i = 0;
        while (f > 0)
        {
            f -= i * incrementAmount;
            i++;
        }
        return i;
    }

    private Quaternion SpawnRotation(Vector3 position)
    {
        var direction = (position - transform.position).normalized;
        return Quaternion.LookRotation(direction);
    }
}

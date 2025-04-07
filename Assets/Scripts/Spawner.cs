using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject missilePrefabs;

    [Header("���� Ÿ�̹� ����")]
    public float minSpawninterval = 0.5f;
    public float maxSpawninterval = 2.0f;

    [Header("���� ���� Ȯ�� ����")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;

    public float timer = 0.0f;
    public float nextSpawnTime;

    private void Start()
    {
        SetNextSpawnTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnObject();
            timer = 0.0f;
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawninterval, maxSpawninterval);
    }

    void SpawnObject()
    {
        Transform spawnTransform = transform;
        int randomValue = Random.Range(0, 100); // 0 - 100�� ���� ���� �̾Ƴ���.
        if (randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {
            Instantiate(missilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
    }
}

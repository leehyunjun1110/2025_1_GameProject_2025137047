using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject missilePrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawninterval = 0.5f;
    public float maxSpawninterval = 2.0f;

    [Header("동전 스폰 확률 설정")]
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
        int randomValue = Random.Range(0, 100); // 0 - 100의 랜덤 값을 뽑아낸다.
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

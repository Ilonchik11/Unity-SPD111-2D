using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bonusPrefab;

    private float bonusSpawnPeriod = 17f;
    private float timeLeft;
    void Start()
    {
        timeLeft = 0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = bonusSpawnPeriod;
            SpawnBonus();
        }
    }
    private void SpawnBonus()
    {
        var bonus = GameObject.Instantiate(bonusPrefab);
        bonus.transform.position = this.transform.position +
            Vector3.up * Random.Range(-2f, 2f);
    }
}

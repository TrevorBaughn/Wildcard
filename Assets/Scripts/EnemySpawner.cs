using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int maxEnemyCount;
    public int baseMaxEnemyCount;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Collider myCollider;
    [SerializeField] private int minSpawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemyCount = baseMaxEnemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMaxEnemyCount())
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Controller player = GameManager.instance.players[0];
        //bogos pick locations until it's far enough away from player, but still in bounds
        Vector3 point = RandomPointInBounds(myCollider.bounds);
        while(Vector3.Distance(point, player.transform.position) <= minSpawnDistance)
        {
            point = RandomPointInBounds(myCollider.bounds);
        }

        //make the enemy
        GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(point.x, 1, point.z), player.transform.rotation);

        //organize hierarchy
        newEnemy.transform.parent = this.transform;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            1,
            Random.Range(bounds.min.z, bounds.max.z)
            );
    }

    private bool IsMaxEnemyCount()
    {
        if(GameManager.instance.ais.Count >= maxEnemyCount)
        {
            return true;
        }
        return false;
    }

    public void KillThemAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

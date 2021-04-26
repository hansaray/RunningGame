using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject tallObstaclePrefab;
    [SerializeField] GameObject fullObstaclePrefab;
    [SerializeField] GameObject terrainPrefab;
    [SerializeField] float tallObstacleChance = 0.2f;
    [SerializeField] float fullObstacleChance = 0.4f;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnTerrains();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        //Choose which obstacle to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f,1f);
        //Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        if (random < tallObstacleChance)
        {
            obstacleToSpawn = tallObstaclePrefab;
        }else if(random < fullObstacleChance)
        {
            obstacleSpawnIndex = 3;
            obstacleToSpawn = fullObstaclePrefab;
        }
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //Spawn the obstacle at the position
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = Random.Range(0,6);
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public void SpawnTerrains()
    {
        Transform spawnPoint = transform.GetChild(8).transform;
        Transform spawnPoint2 = transform.GetChild(7).transform;
        Instantiate(terrainPrefab, spawnPoint2.position, Quaternion.identity, transform);
        Instantiate(terrainPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x,collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}

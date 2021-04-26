using UnityEngine;

public class SideTerrains : MonoBehaviour
{

    [SerializeField] GameObject treePrefab;
    //[SerializeField] GameObject coinPrefab;

    void Start()
    {
        SpawnTrees();
    }

    public void SpawnTrees()
    {
        int treesToSpawn = Random.Range(0, 3);
        for (int i = 0; i < treesToSpawn; i++)
        {
            GameObject temp = Instantiate(treePrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    void Update()
    {
        
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
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

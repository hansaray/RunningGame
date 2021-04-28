using UnityEngine;

public class SideTerrains : MonoBehaviour
{

    [SerializeField] GameObject treePrefab;
    [SerializeField] GameObject redTreePrefab;
    //[SerializeField] GameObject coinPrefab;

    void Start()
    {
        SpawnTrees();
    }

    public void SpawnTrees()
    {
        int treesToSpawn = Random.Range(0, 2);
        int type = Random.Range(0, 2);
        GameObject finalPrefab = treePrefab;
        for (int i = 0; i < treesToSpawn; i++)
        {
            if(type >= 1)
            {
                finalPrefab = redTreePrefab;
            }
            GameObject temp = Instantiate(finalPrefab, transform);
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

        if(point.x < collider.bounds.min.x+1.5)
        {
            point.x += 1;
        }else if(point.x > collider.bounds.max.x-1.5)
        {
            point.x += -1;
        }

        return point;
    }
}

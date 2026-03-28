using UnityEngine;

public class SpawnDog : MonoBehaviour
{
    public GameObject dogPrefabs;
    public float spawnRangeZ = 5;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 3f);
    }

    void Spawn()
    {
        Vector3 spawnPos = new(
            transform.position.x,
            transform.position.y,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );
        Instantiate(
            dogPrefabs,
            spawnPos,
            dogPrefabs.transform.rotation
        );
    }
}

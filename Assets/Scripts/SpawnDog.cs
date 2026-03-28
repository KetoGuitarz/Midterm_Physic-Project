using UnityEngine;

public class SpawnDog : MonoBehaviour
{
    public GameObject dogPrefabs;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 3f);
    }

    void Spawn()
    {
        Vector3 spawnPos = new(
            transform.position.x,
            transform.position.y,
            Random.Range(60, 80)
        );
        Instantiate(dogPrefabs, spawnPos, dogPrefabs.transform.rotation);
    }
}
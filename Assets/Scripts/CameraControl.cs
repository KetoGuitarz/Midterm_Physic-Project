using UnityEngine;

public class CCameraControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

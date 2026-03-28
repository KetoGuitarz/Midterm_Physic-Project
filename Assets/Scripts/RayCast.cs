using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject shootPointPrefab;
    [SerializeField] GameObject hitPointPrefab;
    [SerializeField] float shootRange = 50f;
    [SerializeField] GameObject door;

    private InputAction shootAction;

    void Awake()
    {
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        Aim();
        if (shootAction.triggered)
        {
            Shoot();
        }
    }

    void Aim()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, transform.forward, out hit, shootRange))
        {
            Debug.DrawRay(shootPoint.position, transform.forward * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(shootPoint.position, transform.forward * shootRange, Color.green);
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Instantiate(shootPointPrefab, shootPoint.position, Quaternion.identity);

        if (Physics.Raycast(shootPoint.position, transform.forward, out hit, shootRange))
        {
            Instantiate(hitPointPrefab, hit.point, Quaternion.identity);
            Debug.Log("Hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Obstacle"))
            {
                Destroy(hit.collider.gameObject);
            }

            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);

                if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 1)
                {
                    OpenDoor();
                }
            }
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.transform.Translate(Vector3.down * 5f);
            Debug.Log("ประตูเปิดแล้ว!");
        }
    }
}
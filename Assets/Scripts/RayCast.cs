using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject shootPointPrefab;
    [SerializeField] GameObject hitPointPrefab;
    [SerializeField] float shootRange = 50f;

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

        if (Physics.Raycast(shootPoint.position, transform.right, out hit, shootRange))
        {
            Instantiate(hitPointPrefab, hit.point, Quaternion.identity);

            Debug.Log("Hit: " + hit.collider.name);

            /*if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>()?.TakeDamage();
            }
            else if (hit.collider.CompareTag("Obstacle"))
            {
                hit.collider.GetComponent<Obstacle>()?.DamageTorque();
            }*/
        }
    }
}
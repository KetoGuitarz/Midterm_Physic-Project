using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 10.0f;
    public float turnSpeed = 180.0f;
    public GameObject bulletPrefab;

    [Header("Scene Settings")]
    public string nextScene = "Cradit";

    private float horizontalInput = 0;

    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Start()
    {

    }

    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        if (shootAction.triggered)
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
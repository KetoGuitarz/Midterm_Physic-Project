using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 10.0f;
    public float turnSpeed = 180.0f;
    public float gameTime = 30.0f;

    public GameObject bulletPrefab;

    private float horizontalInput = 0;
    private float timeRemaining;
    private bool isGameOver = false;

    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Start()
    {
        timeRemaining = gameTime;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isGameOver = true;
        }

        if (isGameOver)
        {
            return;
        }

        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

        if (shootAction.triggered)
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
        }
    }
}
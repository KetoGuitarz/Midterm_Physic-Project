using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 10.0f;
    public float turnSpeed = 180.0f;
    public float gameTime = 30.0f;

    private float horizontalInput = 0;
    private float timeRemaining;
    private bool isGameOver = false;

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

        InputAction moveAction = InputSystem.actions.FindAction("Move");
        horizontalInput = moveAction.ReadValue<Vector2>().x;

        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 30), $"Time: {timeRemaining:F1}s");
        if (isGameOver)
        {
            GUI.Label(new Rect(10, 40, 200, 30), "Time's Up!");
        }
    }
}
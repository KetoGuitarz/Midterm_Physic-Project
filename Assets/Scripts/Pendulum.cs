using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 100f;
    public float switchInterval = 2f;

    private float timer = 0f;
    private int direction = 1;

    void Start()
    {
        rb.AddForce(Vector3.left * force, ForceMode.Impulse);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f;
            direction *= -1;

            rb.linearVelocity = Vector3.zero;
            rb.AddForce(Vector3.left * force * direction, ForceMode.Impulse);
        }
    }
}
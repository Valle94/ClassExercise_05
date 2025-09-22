using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float accelerationRate = 10f;
    [SerializeField] float turnRate = 1f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float acceleration = Input.GetAxis("Vertical") * accelerationRate * Time.deltaTime;
        rb.AddRelativeForce(Vector3.forward * acceleration);

        float turn = Input.GetAxis("Horizontal") * turnRate * Time.deltaTime;
        gameObject.transform.Rotate(0f, turn, 0f);
    }
}

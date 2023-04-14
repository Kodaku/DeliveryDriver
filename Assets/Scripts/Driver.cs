using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 20.0f;
    [SerializeField] float slowSpeed = 15.0f;
    [SerializeField] float boostSpeed = 30.0f;
    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            currentSpeed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Bump") {
            currentSpeed = slowSpeed;
        }
    }
}

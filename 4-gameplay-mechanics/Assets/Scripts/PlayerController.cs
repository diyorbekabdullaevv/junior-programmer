using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions controls;
    public float playerSpeed = 150f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerUpStrength = 15.0f;

    public GameObject powerupIndicator;

    void Awake()
    {
        controls = new InputSystem_Actions();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");

    }
    private void OnEnable()
    {
        controls.Player.Enable();
        Debug.Log(controls.Player.Move);
    }

    private void Update()
    {
        Vector2 moveInput = controls.Player.Move.ReadValue<Vector2>();

        float forwardInput = moveInput.y; //Left and Right, Arrow keys

        playerRb.AddForce(focalPoint.transform.forward * forwardInput * playerSpeed * Time.deltaTime);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }


    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigitbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;


            enemyRigitbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

            Debug.Log("Collided with:" + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }


}

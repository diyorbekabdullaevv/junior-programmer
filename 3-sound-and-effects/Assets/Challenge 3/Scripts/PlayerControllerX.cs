using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public InputAction floatAction;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;

        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();

        floatAction.Enable();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is not too high, float up
        if (floatAction.IsPressed() && !gameOver && transform.position.y < 15)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.transform.position = transform.position;
            explosionParticle.Play();

            playerAudio.PlayOneShot(explodeSound, 1.0f);

            gameOver = true;

            Debug.Log("Game Over!");

            Destroy(other.gameObject);
        }

        // If player collides with money, show fireworks at player's position
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.transform.position = transform.position;
            fireworksParticle.Play();

            playerAudio.PlayOneShot(moneySound, 1.0f);

            Destroy(other.gameObject);
        }
    }
}

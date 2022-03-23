using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody body;
    private float speed = 500;
    private GameObject focalPoint;

    public bool hasPowerup;
    public GameObject powerupIndicator;
    public int powerUpDuration = 5;


    public bool hasPowerupl;

    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        body = GetComponent<Rigidbody>();


    }

    private void OnTriggerEvent(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerupl = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountDownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerupl = false;
        powerupIndicator.gameObject.SetActive(false);

    }

    private float powerupStrenght = 15.0f;


    private void onCollisionEvent(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerupl) {


            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to "  + hasPowerupl);
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        body.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
}

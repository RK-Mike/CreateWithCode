using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController plSc;

    private float leftBound = -15;
    // Update is called once per frame

    void Start() {
        plSc = GameObject.Find("SimplePeople_Man_Business_White").GetComponent<PlayerController>();
    }
    void Update()
    {
        if (plSc.gameOver == false) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}

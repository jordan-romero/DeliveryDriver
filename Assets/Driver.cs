using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // these variables don't change so they do not need to be updated every frame 
    [SerializeField] float steerSpeed = 300f;
     [SerializeField] float moveSpeed =  20f;
     [SerializeField] float slowSpeed =  1f;
    [SerializeField] float boostSpeed =  30f;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Boost") {
                moveSpeed = boostSpeed;
            } 
        }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.tag == "Bump") {
            moveSpeed = slowSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; 
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; 
        // variable is scoped to this update -- this allows this to update and calc every frame 
    
        transform.Rotate(0, 0, -steerAmount); 
        transform.Translate(0, moveAmount, 0);
    }
    
}

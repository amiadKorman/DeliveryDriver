using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{   
    const float baseSpeed = 20f;
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = baseSpeed;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float destroyDelay = 0.5f;
    

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical")* moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "BoostSpeed") {
            if(moveSpeed == baseSpeed){
                moveSpeed = boostSpeed;
                Destroy(other.gameObject, destroyDelay);
            } else if(moveSpeed == slowSpeed){
                moveSpeed = baseSpeed;
                Destroy(other.gameObject, destroyDelay);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Obstacle") {
            if(moveSpeed == baseSpeed){
                moveSpeed = slowSpeed;
            } else if(moveSpeed == boostSpeed){
                moveSpeed = baseSpeed;
            }
        }
    }
}

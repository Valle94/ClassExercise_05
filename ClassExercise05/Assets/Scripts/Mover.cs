using System;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float accelerationRate = 10f; // Rate we add force
    [SerializeField] float turnRate = 1f; 
    [SerializeField] float immuneTime = 3f; // Amount of time to not count hitting walls

    // Non-serialized components
    AudioSource music;
    Rigidbody rb;
    MeshRenderer mr;
    
    // enum for "health"
    enum Health { healthy, damaged, broken, crashed }
    Health currentHealth;

    float timer = 0f;

    void Start()
    {
        // Initialize components, color, current health
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        music = GetComponent<AudioSource>();
        mr.material.color = Color.green;
        currentHealth = Health.healthy;
        // Start music
        music.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // Move player
        timer -= Time.deltaTime; // Increment timer
    }

    private void OnCollisionEnter(Collision other)
    {
        // When we collide with a wall, we compare tags and also make sure
        // we haven't already touched a wall in the last 3 seconds
        if (other.gameObject.CompareTag("Wall") && timer < 0)
        {
            // Switch case based on current health; for each case we 
            // change the player color and change current health state.
            switch (currentHealth)
            {
                case Health.healthy:
                    mr.material.color = Color.yellow;
                    currentHealth = Health.damaged;
                    break;
                case Health.damaged:
                    mr.material.color = Color.orange;
                    currentHealth = Health.broken;
                    break;
                case Health.broken:
                    mr.material.color = Color.red;
                    currentHealth = Health.crashed;
                    break;
                case Health.crashed:
                    mr.material.color = Color.gray;
                    accelerationRate = 0f;
                    Debug.Log("You've Crashed!");
                    break;
            }
            timer = immuneTime; // Start immunity timer
        }
    }

    void Move()
    {
        // Adding relative force for movement forward and backwards
        float acceleration = Input.GetAxis("Vertical") * accelerationRate * Time.deltaTime;
        rb.AddRelativeForce(Vector3.forward * acceleration);

        // Directly translating the player body via rotation left and right
        float turn = Input.GetAxis("Horizontal") * turnRate * Time.deltaTime;
        gameObject.transform.Rotate(0f, turn, 0f);
    }
}
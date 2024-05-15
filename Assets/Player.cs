using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1;
    public GameObject bullet;
    public float fireRate = 1;
    float timeSinceLastShot;

    private void Update()
    {
        Movement();
        Shooting();
    }

    void Shooting()
    {
        timeSinceLastShot += Time.deltaTime;

        float minTime = 1 / fireRate; //iloœæ czasu do odczekania
        bool canShoot = timeSinceLastShot >= minTime;

        if (Input.GetButton("Jump") && canShoot)
        {
            Vector3 pos = transform.position;
            Instantiate(bullet, pos, Quaternion.identity);
            timeSinceLastShot = 0;
        }
    }

    void Movement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        inputX *= speed * Time.deltaTime;
        transform.position += new Vector3(inputX, 0);
    }
}

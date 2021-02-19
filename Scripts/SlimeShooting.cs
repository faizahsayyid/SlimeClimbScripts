using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int Health = 4;
    public float scale = 3f;

    private SlimeBodyMass slime;

    //Animation
    Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        slime = GetComponent<SlimeBodyMass>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !slime.massTooLow)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");

        slime.LoseBodyMass();


        //anything else
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Health -= 1;
    }

}

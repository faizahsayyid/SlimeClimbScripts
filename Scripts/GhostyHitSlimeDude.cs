using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostyHitSlimeDude : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer slimeSprite;

    [SerializeField] private float bounceForce = 100f;

    private bool canHit = true;


    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        slimeSprite = gameObject.GetComponent<SpriteRenderer>();
    }


    IEnumerator HitColour()
    {
        Debug.Log("Changed Colour");

        slimeSprite.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        slimeSprite.color = Color.white;
    }

    IEnumerator WaitToHit()
    {
        Debug.Log("Wait for a few seconds before hit");

        canHit = false;

        yield return new WaitForSeconds(0.5f);

        canHit = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ghosty" && canHit)
        {
            SlimeBodyMass slime = GetComponent<SlimeBodyMass>();

            slime.LoseBodyMass();

            playerRigidBody.AddForce(new Vector2(0f, bounceForce));

            StartCoroutine(HitColour());
        }

        StartCoroutine(WaitToHit());
    }
}

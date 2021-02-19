using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int Health = 4;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Health -= 1;
    }

    // Detect enemy
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);

        if (hitInfo.gameObject.tag == "Ghosty")
        {
            GhostHitPoints ghost = hitInfo.GetComponent<GhostHitPoints>();
            ghost.UpdateGhostHP();
        }
        else if (hitInfo.gameObject.tag == "Switch")
        {
            Switch switchscript = hitInfo.GetComponent<Switch>();
            switchscript.OnOff = !switchscript.OnOff;
        }

        Destroy(gameObject);
        Debug.Log("DEAD.");
    }
}

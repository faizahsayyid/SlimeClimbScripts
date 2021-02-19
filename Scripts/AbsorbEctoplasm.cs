using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbEctoplasm : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.name == "SlimeDude")
        {
            SlimeBodyMass slime = collision.GetComponent<SlimeBodyMass>();

            slime.GainBodyMass();
            Destroy(gameObject);
        }
    }

}

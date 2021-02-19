using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{ 
    public float speed;

    private bool movingLeft = true;

    public Transform groundDection;

    void Update()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDection.position, Vector2.down, 1f);

        if (groundInfo.collider == false)
        {
            if(movingLeft == true)
            {
                movingLeft = false;
                transform.eulerAngles = new Vector3(0, -180, 0);
                
            }
            else
            {
                movingLeft = true;
                transform.eulerAngles = new Vector3(0, 0, 0);
                
            }
        }
        
    }
}

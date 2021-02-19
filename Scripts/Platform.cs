using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    public Transform pos1;
    public Transform pos2;
    private bool turnback;
    public bool canMove = false;

    void Update()
    {
        if (canMove == true)
        {
            if (transform.position.y >= pos1.position.y)
            {
                turnback = true;
            }
            if (transform.position.y <= pos2.position.y)
            {
                turnback = false;
            }
            if (turnback)
            {
                transform.position = Vector2.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
            }
        }
    }

}

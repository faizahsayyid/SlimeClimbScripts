using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    //true if on, false if off
    public bool OnOff = false;
    public GameObject movingPlatform;
    private Platform platformScript;
    [SerializeField]private Sprite switchImage;
    private Sprite originalImage;

    // Start is called before the first frame update
    private void Start()
    {
        originalImage = GetComponent<SpriteRenderer>().sprite;
        platformScript = movingPlatform.GetComponent<Platform>();
        //gameObject.GetComponent<SpriteRenderer>().sprite = switchImage;
    }

    private void Update()
    {
        if (OnOff == true)
        {
            platformScript.canMove = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = originalImage;
        }
        else
        {
            platformScript.canMove = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = switchImage;
        }
    }


    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        Debug.Log("Log");
    //        gameObject.GetComponent<SpriteRenderer>().sprite = switchImage;
    //        renderererOfImage.sprite = switchImage;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnOff = !OnOff;
    }

  
}

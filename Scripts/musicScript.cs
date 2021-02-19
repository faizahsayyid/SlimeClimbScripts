using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicScript : MonoBehaviour
{
    public static musicScript music;

    // Start is called before the first frame update
    void Awake()
    {
        if (!music)
        {
            music = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float scrollMultiplier;
    GameObject mainCamera;

    Vector3 startPos;
    Vector3 offset;

    void Start()
    {
        startPos = transform.position;
        mainCamera = Camera.main.gameObject;
        offset = mainCamera.transform.position - startPos;
    }

    void LateUpdate()
    {
        transform.position = (mainCamera.transform.position - offset) * scrollMultiplier;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHitPoints : MonoBehaviour
{
    [SerializeField] private int ghostHitPoints = 2;
    [SerializeField] private GameObject ectoplasm;


    public void UpdateGhostHP()
    {
        ghostHitPoints -= 1;

        if (ghostHitPoints == 0)
        {
            Instantiate(ectoplasm, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}

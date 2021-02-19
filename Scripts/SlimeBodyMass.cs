using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SlimeBodyMass : MonoBehaviour
{
    public TextMeshProUGUI bodyMassCount;

    [Range(0, 1)] [SerializeField] private float bodyMassPercentage = 1;
    [SerializeField] private float slimeMassChangeRate = 0.25f; //The percent of mass the slime loses/gains

    private Vector3 slimeMassChange;

    public bool massTooLow = false;

    private void Start()
    {
        bodyMassCount.text = "100 %";
        slimeMassChange = transform.localScale * slimeMassChangeRate;
    }


    public void GainBodyMass()
    {
        transform.localScale += slimeMassChange;
        bodyMassPercentage += slimeMassChangeRate;
        bodyMassCount.text = (bodyMassPercentage * 100).ToString() + " %";
        massTooLow = false;
    }


    public void LoseBodyMass()
    {

        transform.localScale -= slimeMassChange;
        bodyMassPercentage -= slimeMassChangeRate;
        bodyMassCount.text = (bodyMassPercentage * 100).ToString() + " %";

        if (bodyMassPercentage <= slimeMassChangeRate)
        {
            massTooLow = true;
        }

        if (transform.localScale == Vector3.zero)
        {
            SlimeDeath();
        }
    }

    public void SlimeDeath()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }


}

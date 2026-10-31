using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MilkCounter : MonoBehaviour
{
    [SerializeField] private GameObject uiManager;
    [SerializeField] private GameObject MilkAmountLabel;
    private int milks = 0;

    void Start()
    {
        Debug.Log(MilkAmountLabel.GetComponent<TMP_Text>().text);
        MilkAmountLabel.GetComponent<TMP_Text>().text = Convert.ToString(milks);
    }

    public void AddMilkPack()
    {
        milks += 1;
        MilkAmountLabel.GetComponent<TMP_Text>().text = Convert.ToString(milks);
    } 
}

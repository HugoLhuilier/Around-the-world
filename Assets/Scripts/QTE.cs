using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTE : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instructionText;
    private int correctKey;

    void Update()
    {
        if(correctKey == 0)
        {
            if (Input.GetKey("up"))
            {
                correctKey = 1;
                instructionText.text = "Press left key";
            }
        }
        else if (correctKey == 1)
        {
            if (Input.GetKey("left"))
            {
                correctKey = 2;
                instructionText.text = "Press right key";
            }
        }
        else if (correctKey == 2)
        {
            if (Input.GetKeyDown("right"))
            {
                instructionText.text = "Good job!";
            }
        }
    }
}

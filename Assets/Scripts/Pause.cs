using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public IsWriting isWriting;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isWriting.getWriting())
            {
                UnityEngine.Debug.Log("1");
                isWriting.changeWritingState(false);
            }
            else
            {
                UnityEngine.Debug.Log("2");
                isWriting.changeWritingState(true);
            }
        }
    }
}

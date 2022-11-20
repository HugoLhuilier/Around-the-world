using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWriting : MonoBehaviour
{
    private bool isWriting = false;

    public bool getWriting()
    {
        return isWriting;
    }

    public void changeWritingState(bool test)
    {
        isWriting = test;
    }
}

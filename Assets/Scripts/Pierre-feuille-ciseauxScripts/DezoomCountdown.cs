using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DezoomCountdown : MonoBehaviour
{
    public float dezoomSpeed;

    private RectTransform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.localScale *= (1 - dezoomSpeed * Time.fixedDeltaTime);
    }
}

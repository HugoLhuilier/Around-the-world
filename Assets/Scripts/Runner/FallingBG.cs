using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBG : MonoBehaviour
{
    private float speed;
    [SerializeField] private RunnerController controller;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = transform.position + controller.bgspeed * Time.deltaTime * Vector3.down;
        if (tr.position.y < -8)
        {
            tr.position += 3 * 7.86f * Vector3.up;
        }
    }
}

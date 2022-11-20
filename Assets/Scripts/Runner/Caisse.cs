using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caisse : MonoBehaviour
{
    public float fallSpeed;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position += fallSpeed * Time.deltaTime * Vector3.down;

        if(tr.position.y < -5.2)
        {
            Destroy(gameObject);
        }
    }
}

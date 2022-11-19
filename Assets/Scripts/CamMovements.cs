using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovements : MonoBehaviour
{
    public Transform target;
    private Transform tr;
    [Range(0, 2)] public float smoothFact;
    [SerializeField] public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.position = Vector3.Slerp(tr.position, target.position + offset, smoothFact * Time.fixedDeltaTime * Vector3.Magnitude(tr.position - target.position));
    }
}

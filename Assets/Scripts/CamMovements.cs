using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovements : MonoBehaviour
{
    public Transform target;
    public CharacterMovements targetMove;
    private Transform tr;
    [Range(0, 2)] public float smoothFact;
    public Vector3 setOffset;
    public Vector3 camMinLim;
    public Vector3 camMaxLimit;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.position = Vector3.Slerp(tr.position, new Vector3(Mathf.Clamp(target.position.x + setOffset.x * targetMove.facing, camMinLim.x, camMaxLimit.x),
        Mathf.Clamp(target.position.y + setOffset.y, camMinLim.y, camMaxLimit.y), 
        Mathf.Clamp(target.position.z + setOffset.z, camMinLim.z, camMaxLimit.z)), smoothFact * Time.fixedDeltaTime * Vector3.Magnitude(tr.position - target.position));
    }
}

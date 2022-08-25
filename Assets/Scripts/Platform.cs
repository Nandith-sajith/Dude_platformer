using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform: MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Start is called before the first frame update
    void Start()
    {
        posB = transformB.localPosition;
        posA = childTransform.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition,nextPos)<= 0.1)
        {
            ChangeDestination();
        }
    }
    private void ChangeDestination()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}

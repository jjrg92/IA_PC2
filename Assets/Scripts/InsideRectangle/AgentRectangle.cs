using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRectangle : SBAgent
{
    public Transform target;
    public Transform center;

    void Start()
    {
        maxSpeed = 10f;
        maxSteer = 1f;
        target = GameObject.Find("Target").transform;
        center = GameObject.Find("Center").transform;
    }

    void Update()
    {
        velocity += SteeringBehaviours.InsideRectangle(this, target, center, 5, 3);

        transform.position += velocity * Time.deltaTime;
    }
}

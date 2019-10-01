using UnityEngine;

public class Agent : SBAgent
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
        velocity += SteeringBehaviours.InsideCircle(this,target,center,4);

        transform.position += velocity * Time.deltaTime;
    }
}

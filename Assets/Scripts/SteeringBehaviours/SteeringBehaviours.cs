using UnityEngine;
using System.Collections.Generic;

public class SteeringBehaviours
{
    static public Vector3 Seek(SBAgent agent, Transform target, float range = 9999)
    {
        // cálculo del vector deseado
        Vector3 desired = Vector3.zero;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;
        desired = difference.normalized * agent.maxSpeed;
        Vector3 steer;
        if (distance < range)
        {
            steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        }
        else
        {
            steer = Vector3.zero;
        }

        // cálculo de los demás vectores


        return steer;
    }

    static public Vector3 Flee(SBAgent agent, Transform target, float range = 99999)
    {
        Vector3 desired = Vector3.zero;
        Vector3 difference = -(target.position - agent.transform.position);
        float distance = difference.magnitude;
        desired = difference.normalized * agent.maxSpeed;
        Vector3 steer;
        if (distance < range)
        {
            steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);
        }
        else
        {
            steer = Vector3.zero;
        }

        // cálculo de los demás vectores


        return steer;
    }


    static public Vector3 InsideCircle(SBAgent agent, Transform target, Transform center, float range)
    {
        Vector3 desired = Vector3.zero;
        float distance = Vector3.Distance(agent.transform.position, center.position);
        Vector3 steer;
        if (distance > range)
        {
            steer = Seek(agent, center);
        }
        else
        {
            steer = Seek(agent, target);
        }

        return steer;
    }
    static public Vector3 InsideRectangle(SBAgent agent, Transform target, Transform center, float vertX, float vertY)
    {

        Vector3 desired = Vector3.zero;

        Vector3 steer;
        if (agent.transform.position.x > center.position.x + vertX || agent.transform.position.x < center.position.x - vertX 
		|| agent.transform.position.y < center.position.y - vertY || agent.transform.position.y > center.position.y + vertY)
        {
            steer = Seek(agent, center);
        }
        else
        {
            steer = Seek(agent, target);
        }

        return steer;
    }

    static public Vector3 Arrive(SBAgent agent, Transform target, float range)
    {
        // cálculo del vector deseado
        Vector3 desired;
        Vector3 difference = (target.position - agent.transform.position);
        float distance = difference.magnitude;

        desired = difference.normalized * agent.maxSpeed;

        if (distance < range)
        {
            desired *= distance / range;
        }

        // cálculo de los demás vectores
        Vector3 steer = Vector3.ClampMagnitude(desired - agent.velocity, agent.maxSteer);

        return steer;
    }
    static public Vector3 Separate(SBAgent agent, List<GameObject> agentToAvoid, float range)
    {
        Vector3 steer = Vector3.zero;
        for (int i = 0; i < agentToAvoid.Count; i++)
        {
            steer += Flee(agent, agentToAvoid[i].transform, range);
        }
        return steer;
    }
}

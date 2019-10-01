using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    void Start()
    {
        GameObject agent = Resources.Load<GameObject>("AgentRectangle");
        GameObject instance = Instantiate(agent);
        instance.transform.position = new Vector3(0, 0, 1);

    }
}

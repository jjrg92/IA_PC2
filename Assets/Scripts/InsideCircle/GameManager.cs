using UnityEngine;

using System.Collections.Generic;

public class GameManager : MonoBehaviour
{


	void Start()
	{
			GameObject agent = Resources.Load<GameObject>("Agent");
			GameObject instance = Instantiate(agent);
			instance.transform.position = new Vector3(0,0,1);

	}
}

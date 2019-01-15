using UnityEngine;
using System.Collections;

public class StickTo : MonoBehaviour
{

    public GameObject other;
	
	// Update is called once per frame
	void Update ()
	{
	    transform.position = other.transform.position;
	}
}

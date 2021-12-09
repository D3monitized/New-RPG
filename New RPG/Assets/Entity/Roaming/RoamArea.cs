using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamArea : MonoBehaviour
{
    public float roamRadius;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(transform.position, roamRadius); 
	}
}

using UnityEngine;
using UnityEngine.AI; 

public class MobMovement : MonoBehaviour
{
	public bool roamer;
	public RoamArea roamArea;
	public float minRoamDistance;
	public float roamCooldown; 
	
	[HideInInspector] public NavMeshAgent agent;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();	
	}

	public void MoveLocation(Vector3 target)
	{
		agent.SetDestination(target); 
	}	
}

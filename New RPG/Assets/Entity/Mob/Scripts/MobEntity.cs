using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI; 

public class MobEntity : Entity
{
	[Header("Mob Info")]
	public float aggroRange;
	public float chaseRange;
	public float attackRange; 

	public Entity target;

	[Header("Events")] 
	public TargetEvent onTargetUpdated; 

	private void Start()
	{
		//Attackrange can't be shorter than the agent stopping distance
		if (attackRange <= 0)
			attackRange = GetComponent<NavMeshAgent>().stoppingDistance;

		currentHealth = health;
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		
		onTargetUpdated.Invoke(this);
		
		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
			
	}
}

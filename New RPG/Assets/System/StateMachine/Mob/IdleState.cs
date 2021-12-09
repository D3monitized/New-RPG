using UnityEngine;

namespace Mob
{
	public class IdleState : State
	{
		public ChaseState chaseState; 
		
		private MobMovement movement;
		private MobEntity mobInfo; 

		private bool isRoaming;
		private bool startRoaming; 
		private float roamTimer;

		private int state;

		public override State RunCurrentState()
		{
			if (movement.roamer)
			{
				//Have a roamcooldown 
				//Roam

				if (startRoaming)
				{
					roamTimer -= Time.deltaTime;				
					if (roamTimer <= 0)
					{
						startRoaming = false; 
						isRoaming = false;
						roamTimer = movement.roamCooldown;
					}
				}

				if (!isRoaming)
					RoamRandomLocation();
				else
					CheckIfReachedTarget(); 
			}

			CheckForEnemies(); 
			
			//State
			if (state == 1)
			{
				state = 0; 
				isRoaming = false; 
				return chaseState;
			}
			else
				return this; 
		}

		private void CheckIfReachedTarget()
		{			
			float distance = Vector3.Distance(new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z), 
			movement.agent.destination);			

			if (distance <= movement.agent.stoppingDistance + .1f)
				startRoaming = true; 
		}

		private void RoamRandomLocation()
		{			
			isRoaming = true;

			Vector3 target = 
			movement.roamArea.transform.position + new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z)
			* movement.roamArea.roamRadius;

			float distance = Vector3.Distance(transform.position, target);
			if (distance < movement.minRoamDistance)
				RoamRandomLocation();
			else
			{
				movement.MoveLocation(target);			 
			}				
		}

		private void CheckForEnemies()
		{
			//Check for enemies, if any found, start chasing, return chaseState 
			Collider[] colliders = Physics.OverlapSphere(transform.position, mobInfo.aggroRange); 
			foreach(Collider collider in colliders)
			{
				if(collider.GetComponent<Entity>() != null)
				{
					Entity entityInfo = collider.GetComponent<Entity>();
					if (mobInfo.race.enemies.Contains(entityInfo.race.myRace))
					{
						mobInfo.target = entityInfo; 
						state = 1; 
					}
				}
			}
		}

		private void OnEnable()
		{
			movement = GetComponent<MobMovement>();
			mobInfo = GetComponent<MobEntity>(); 
			roamTimer = movement.roamCooldown; 
		}
	}
}
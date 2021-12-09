using UnityEngine;

namespace Mob
{
	public class ChaseState : State
	{
		public IdleState idleState; 
		
		private MobMovement movement;
		private MobEntity mobInfo;
	
		private int state;

		private bool inAttackRange; 

		public override State RunCurrentState()
		{
			ChaseTarget(); 
			CheckDistance();

			if (state == 1)
			{
				state = 0; 
				StopChase();
				mobInfo.target = null;
				return idleState; 
			}
			else	
				return this;
		}

		private void ChaseTarget()
		{
			movement.MoveLocation(mobInfo.target.transform.position);
		}

		private void StopChase()
		{
			movement.MoveLocation(movement.roamArea.transform.position);
		}

		private void CheckDistance()
		{
			float distance = Vector3.Distance(new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z),
			movement.agent.destination);

			if (distance > mobInfo.chaseRange)
				state = 1;

			if (distance <= mobInfo.attackRange)
				inAttackRange = true;
			else
				inAttackRange = false; 
		}

		public void Attack()
		{
			if (inAttackRange)
			{
				//Do attacking stuff
				print("Attack");
			}
		}

		private void OnEnable()
		{
			movement = GetComponent<MobMovement>();
			mobInfo = GetComponent<MobEntity>();
		}
	}
}
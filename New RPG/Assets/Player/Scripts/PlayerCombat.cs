using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Timeline;
using Vector3 = UnityEngine.Vector3;

public class PlayerCombat : MonoBehaviour
{
    [Header("General")]
    public float targetingRange;
    public Entity target;

    [Header("Events")]
    public TargetEvent onTargetSelected;
    public VoidEvent onTargetRemoved;
    public StringEvent onAutoattack;

    private RaycastHit targetHit;
    private Vector3 wp;

    private bool autoAttack; 

    private void Update()
    {
        if (PlayerInput.leftMouseDown)
            TargetEntity();
        
        if(Input.GetKeyDown(PlayerInput.commandButtons[0]))
            RemoveTarget();

        if (Input.GetKeyDown(PlayerInput.commandButtons[2]))
        {
            autoAttack = !autoAttack;
            if(autoAttack)
                onAutoattack.Invoke("Autoattack has been activated.");
            else
                onAutoattack.Invoke("Autoattack has been disabled.");
        }
            
        
        if(PlayerInventory.instance.inventory.Count > 0)
            print(PlayerInventory.instance.inventory[0].name);
    }

    public void Attack()
    {
        if (autoAttack)
        {
            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                if (distance <= PlayerEntity.attackRange)
                {
                    if(target.GetComponent<MobEntity>() != null)
                        target.GetComponent<MobEntity>().TakeDamage(PlayerEntity.damage);
                }
                    
            }
        }
    }

    private void TargetEntity()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
            out targetHit, targetingRange))
        {
            GameObject hitObject = targetHit.collider.gameObject;
            if (hitObject.GetComponent<Entity>() != null)
            {
                Entity entityInfo = hitObject.GetComponent<Entity>();
                target = entityInfo; 
                onTargetSelected.Invoke(entityInfo);
            }
        }
    }

    private void RemoveTarget()
    {
        target = null;
        onTargetRemoved.Invoke(); 
    }
}

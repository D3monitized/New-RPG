using UnityEngine;

public class PlayerModelController : MonoBehaviour
{
	public StringEvent onEmote; 
	
    private Animator animator;
	private Rigidbody rb;
	private Transform playerParent; 

	private float speed;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		rb = GetComponentInParent<Rigidbody>();
		playerParent = GameObject.Find("Player").transform; 
	}

	private void Update()
	{
		speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;
		animator.SetFloat("Speed", speed);		
	}

	public void ChangeModelRotation(Vector3 _dir) //Called on event
	{
		Vector2 dir = new Vector2(_dir.x, _dir.z);
		float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

		Quaternion targetRot = Quaternion.Euler(transform.rotation.x, playerParent.rotation.eulerAngles.y + angle, transform.rotation.z);
		Quaternion rot = transform.rotation;
		rot = Quaternion.Lerp(rot, targetRot, .2f); 

		transform.rotation = rot;		
	}

	public void Dance()
	{
		onEmote.Invoke("[" + PlayerEntity.playerName + "]" + " starts dancing.");
	}
}

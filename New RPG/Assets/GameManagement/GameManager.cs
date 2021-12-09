using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Tooltip("Ticklength in seconds")]
	public float tickLength; 

    public VoidEvent tick;

	private float tickTimer;

	private void Awake()
	{
		tickTimer = tickLength; 
	}

	private void Update()
	{
		tickTimer -= Time.deltaTime; 
		if(tickTimer <= 0)
		{
			tickTimer = tickLength;
			tick.Invoke(); 
		}
	}
}

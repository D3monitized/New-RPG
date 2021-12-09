using UnityEngine;
using UnityEngine.Events;

public class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
	public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

	[SerializeField] private E gameEvent; 
	[SerializeField] private UER unityEventResponse; 

	public void OnEventRaised(T item)
	{
		unityEventResponse.Invoke(item); 
	}

	private void OnEnable()
	{
		GameEvent.Register(this); 
	}

	private void OnDisable()
	{
		GameEvent.Deregister(this); 
	}
}

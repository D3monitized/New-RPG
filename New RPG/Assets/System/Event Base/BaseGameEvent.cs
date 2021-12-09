using UnityEngine;
using System.Collections.Generic; 

[System.Serializable]
public class BaseGameEvent<T> : ScriptableObject
{
    private List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>(); 

    public void Invoke(T item)
	{
		for (int i = eventListeners.Count - 1; i >= 0; i--)
		{
			eventListeners[i].OnEventRaised(item);
		}
	}

	public void Register(IGameEventListener<T> listener)
	{
		if (!eventListeners.Contains(listener))
			eventListeners.Add(listener); 
	}

	public void Deregister(IGameEventListener<T> listener)
	{

		if (eventListeners.Contains(listener))
			eventListeners.Remove(listener);
	}
}

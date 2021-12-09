using UnityEngine;
using System.Collections.Generic; 

[System.Serializable]
public class Race
{
	public race myRace; 
	public List<race> enemies; 

    public enum race
	{
		Human,
		Skeleton, 
		Troll
	}
}

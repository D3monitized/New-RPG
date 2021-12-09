using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MobMovement))]
public class MobMovementEditor : Editor
{
	public SerializedObject so;

	private SerializedProperty roamer;
	private SerializedProperty minRoamDistance;
	private SerializedProperty roamCooldown;
	private SerializedProperty roamArea; 

	public override void OnInspectorGUI()
	{
		MobMovement movement = target as MobMovement;

		so.Update();
		EditorGUILayout.PropertyField(roamer);
		so.ApplyModifiedProperties(); 

		if(roamer.boolValue)
		{
			so.Update(); 
			EditorGUILayout.PropertyField(roamArea, false, new GUILayoutOption[0]);			
			EditorGUILayout.PropertyField(minRoamDistance);
			EditorGUILayout.PropertyField(roamCooldown);
			so.ApplyModifiedProperties(); 
		}
	}

	private void OnEnable()
	{
		so = new SerializedObject((MobMovement)target);
		roamer = so.FindProperty("roamer");
		minRoamDistance = so.FindProperty("minRoamDistance");
		roamCooldown = so.FindProperty("roamCooldown");
		roamArea = so.FindProperty("roamArea");
	}
}

using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ChildSpawnPoint))]
public class ChildSpawnPointEditor : Editor
{
		public SerializedProperty spawnPointTypeMask;
	
		void OnEnable ()
		{
				spawnPointTypeMask = serializedObject.FindProperty ("spawnPointType");
		}
	
		public override void OnInspectorGUI ()
		{
				serializedObject.Update ();
		
				spawnPointTypeMask.intValue = (int)((SpawnPointTypes)EditorGUILayout.EnumMaskField
		                                    ("SpawnPointType", (SpawnPointTypes)spawnPointTypeMask.intValue));
		
				serializedObject.ApplyModifiedProperties ();
		}
}
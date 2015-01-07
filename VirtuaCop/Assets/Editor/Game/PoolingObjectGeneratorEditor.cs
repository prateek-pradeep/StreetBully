//using UnityEngine;
//using UnityEditor;
//using System.Collections;
//
//[CustomEditor(typeof(PoolingObjectGenerator))]
//public class PoolingObjectGeneratorEditor : Editor
//{
//		public override void OnInspectorGUI ()
//		{
//				SerializedProperty poolingObjectsList = serializedObject.FindProperty ("poolingObjects");
//				
//				serializedObject.Update ();
//				EditorGUILayout.PropertyField (poolingObjectsList, true);
//
//				serializedObject.ApplyModifiedProperties ();
//		}
//}

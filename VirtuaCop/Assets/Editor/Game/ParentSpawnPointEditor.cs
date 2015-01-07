using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(ParentSpawnPoint))]
public class ParentSpawnPointEditor : Editor
{

		public SerializedProperty fixedPoints;
		Transform go;
		static bool enablePermanentHandles;

		void OnEnable ()
		{
				ParentSpawnPoint script = target as ParentSpawnPoint;
				script.InitializePoints ();
				
				SceneView.onSceneGUIDelegate -= OnScene;
				SceneView.onSceneGUIDelegate += OnScene;
				
		}
	
		public override void OnInspectorGUI ()
		{
				enablePermanentHandles = EditorGUILayout.Toggle ("Permanent Handles", enablePermanentHandles);
				DrawDefaultInspector ();
				

		}

		public void OnScene (SceneView sceneview)
		{
				if (enablePermanentHandles) {
						DrawCustomHandles ();
				}
		}

		public void OnSceneGUI ()
		{
				
				DrawCustomHandles ();
				
		}

		void DrawCustomHandles ()
		{
				ParentSpawnPoint script = target as ParentSpawnPoint;

				foreach (var child in script.GetFixedPoints()) {
						Handles.color = Color.red;
						Handles.DrawLine (script.transform.position, child.position); 
				}

				Vector3[] bunny = script.GetBunnyHopPoints ().Select(point => point.position).ToArray ();
				
				if (bunny.Length > 1) {
						Handles.color = Color.white;
						Handles.DrawLine (bunny [0], script.transform.position);
						Handles.color = Color.yellow;
						Vector3 midPoint = (bunny [0] + bunny [1]) / 2;
						midPoint.y = 3f;
						Handles.DrawLine (bunny [0], bunny [1]);
						Vector3 dir = bunny [1] - bunny [0];
						float count = 20;
						Vector3 lastP = bunny [0];
						for (float i = 0; i < count+1; i++) {
								Vector3 p = bunny [0] + (dir / count) * i;
								p.y = Mathf.Sin ((i / count) * Mathf.PI) * midPoint.y;
								//Handles.color = i % 2 == 0 ? Color.blue : Color.green;
								Handles.DrawLine (lastP, p);
								lastP = p;
						}
				}


				//drawing roaming lines
				Vector3[] roaming = script.GetRoamingPoints ().Select(point => point.position).ToArray ();
				if (roaming.Length > 0) {
						Handles.color = Color.white;
						Handles.DrawLine (script.transform.position, roaming.ElementAt (0));
						Handles.color = Color.blue;
						Handles.DrawPolyLine (roaming.ToArray ());
						Handles.DrawLine (roaming.ElementAt (0), roaming.ElementAt (roaming.Count () - 1));
				
						//drawing roaming label
//						Handles.BeginGUI ();
//						for (int i=0; i<roaming.Length; i++) {
//								var guiPoint = HandleUtility.WorldToGUIPoint (roaming [i]);
//								var rect = new Rect (guiPoint.x - 50f, guiPoint.y - 80, 80, 20);
//								GUI.Box (rect, "Roaming " + (i + 1));
//						}
//						Handles.EndGUI ();
				}
				
				Vector3[] covers = script.GetCoverPoints ().Select(point => point.position).ToArray ();
				if (covers.Length > 0) {
						Handles.color = Color.magenta;
						foreach (var cover in covers) {
								Handles.DrawLine (cover, script.transform.position);
						}
				}

			
		}

			
}

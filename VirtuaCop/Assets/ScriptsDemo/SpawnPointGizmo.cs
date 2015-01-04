using UnityEngine;
using System.Collections;

public class SpawnPointGizmo : MonoBehaviour {

	public void OnDrawGizmos()
	{
		Gizmos.DrawCube (transform.position, new Vector3 (0.5f, 0.5f, 0.5f));
	}
}

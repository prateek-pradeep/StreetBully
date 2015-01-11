using UnityEngine;
using System.Collections;

public enum EnemyState
{
		None=1 << 0,
		Shoot=1 << 1,
		Hide=1 << 2,
}

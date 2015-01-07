using UnityEngine;
using System.Collections;

public enum SpawnPointTypes
{
		
		HiddenSpawn=1 << 0,		
		Fixed =1 << 1,
		BunnyHop=1 << 2,
		Roaming=1 << 3,
		Cover=1 << 4,
		All = HiddenSpawn | Fixed | BunnyHop | Roaming | Cover,
}

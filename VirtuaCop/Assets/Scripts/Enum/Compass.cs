using UnityEngine;
using System.Collections;

public enum Compass
{
		None=0,
		North,
		East,
		South,
		West
}

public static class CompassExtensionClass
{
		public static float GetAngle (this Compass value)
		{
				switch (value) {
				case Compass.East:
						return 90f;
						
				case Compass.South:
						return 180f;
						
				case Compass.West:
						return 270f;
						
				default:
						return 0f;
						
				}
		}

		public static Compass GetNextDirection (this Compass value, TKSwipeDirection direction)
		{
				return GetDirection (value, direction);
		}
		
		public static Compass GetNextDirection (this Compass value, TKSwipeDirection direction, Compass[] supportedDirection)
		{
				Compass newDirection = value;
				while (true) {
						newDirection = GetDirection (newDirection, direction);
						
						//check if found direction is supported 
						foreach (var eachDir in supportedDirection) {
								if (eachDir == newDirection)
										return newDirection;
						}						
				}
				//return newDirection;
		}

		private static Compass GetDirection (Compass value, TKSwipeDirection direction)
		{
				switch (value) {
				case Compass.East:
						if (direction == TKSwipeDirection.Left) {
								return Compass.North;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.South;
						break;
			
				case Compass.South:
						if (direction == TKSwipeDirection.Left) {
								return Compass.East;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.West;
						break;
				case Compass.West:
						if (direction == TKSwipeDirection.Left) {
								return Compass.South;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.North;
						break;
				case Compass.North:
						if (direction == TKSwipeDirection.Left) {
								return Compass.West;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.East;
						break;
				}
				return value;
		}
}
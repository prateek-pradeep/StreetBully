﻿using UnityEngine;
using System.Collections;

public enum Compass
{
		None=1 << 0,
		North=1 << 1,
		East=1 << 2,
		South=1 << 3,
		West=1 << 4,
		NorthWest = 1 << 5,
		NorthEast=1 << 6
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
				case Compass.NorthEast:

						return 45f;
				case Compass.NorthWest:

						return 315f;
						
				default:
						return 0f;
						
				}
		}

		public static Compass GetNextDirection (this Compass value, TKSwipeDirection direction)
		{
				return GetDirection (value, direction);
		}
		
		public static Compass GetNextDirection (this Compass value, TKSwipeDirection direction, Compass supportedDirection)
		{
				Compass newDirection = value;
				while (true) {
						newDirection = GetDirection (newDirection, direction);
						
						if ((newDirection & supportedDirection) == newDirection)
								return newDirection;
				}

		}

		private static Compass GetDirection (Compass value, TKSwipeDirection direction)
		{
				switch (value) {
				case Compass.East:
						if (direction == TKSwipeDirection.Left) {
								return Compass.NorthEast;
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
								return Compass.NorthWest;
						break;
				case Compass.North:
						if (direction == TKSwipeDirection.Left) {
								return Compass.NorthWest;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.NorthEast;
						break;
				case Compass.NorthEast:
						if (direction == TKSwipeDirection.Left) {
								return Compass.North;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.East;
						break;
				case Compass.NorthWest:
						if (direction == TKSwipeDirection.Left) {
								return Compass.West;
						} else if (direction == TKSwipeDirection.Right)
								return Compass.North;
						break;
				}
				return value;
		}
}
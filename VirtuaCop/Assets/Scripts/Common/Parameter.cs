using System.Collections;
using UnityEngine;

public struct Parameter
{
	public float MaxValue ;

	public float MinValue ;

	public float CurrentValue ;

		Parameter (float minValue, float maxValue)
		{
				CurrentValue = MinValue = minValue;
				MaxValue = maxValue;
		}

		public void UpdateParameterValue (float value)
		{
				CurrentValue = Mathf.Clamp (value, this.MinValue, this.MaxValue);
		}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class EnumUtils
{
	public static IEnumerable<T> IterateEnum<T>()
	{
		foreach (T value in Enum.GetValues(typeof(T)))
		{
			if (value.ToString() == "None") continue;
			if (value.ToString() == "Count") continue;
			yield return value;
		}
	}
}

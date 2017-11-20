using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class LinqExtensions
{
	//based on http://stackoverflow.com/questions/3173718/how-to-get-a-random-object-using-linq
	public static T Random<T>(this IEnumerable<T> enumerable)
	{
		if (enumerable == null)
		{
			throw new ArgumentNullException(nameof(enumerable));
		}

		var list = enumerable as IList<T> ?? enumerable.ToList();
		return list.Count == 0 ? default(T) : list[RNGUtils.RNG.Next(0, list.Count)];
	}
}
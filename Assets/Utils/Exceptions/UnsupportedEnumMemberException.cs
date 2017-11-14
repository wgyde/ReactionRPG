using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils.Exceptions
{
	public class UnsupportedEnumMemberException : Exception
	{
		public UnsupportedEnumMemberException() { }
		public UnsupportedEnumMemberException(string message) : base(message) { }
		public UnsupportedEnumMemberException(string message, Exception inner) : base(message, inner) { }

		public static UnsupportedEnumMemberException GetGeneric(object enumMember)
		{
			return new UnsupportedEnumMemberException($"Unsupported enum member {enumMember}");
		}
	}
}

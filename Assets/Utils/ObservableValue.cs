using System;
using System.Collections.Generic;
using System.Text;

namespace NSUtils
{
    public class ObservableValue<T>
    {
		public event Action OnValueChanged = delegate { };

		private T _Value;
		public T Value
		{
			get { return _Value; }
			set { _Value = value; OnValueChanged(); }
		}
    }
}

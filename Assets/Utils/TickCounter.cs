using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NSUtils.MathUtils;

namespace NSUtils
{
	public class TickCounter
	{
		private int _Value = 0;
		public int Value
		{
			get { return _Value; }
			set { _Value = Max(0, value); }
		}

		private int _DefaultValue = 0;
		public int DefaultValue
		{
			get { return _DefaultValue; }
			set { _DefaultValue = Max(0, value); }
		}

		public bool Finished { get { return Value == 0; } }

		public void Reset()
		{
			Value = DefaultValue;
		}

		public void Tick(int delta = 1)
		{
			if (Finished)
				return;

			Value -= delta;

			if (Finished)
				OnFinish();
		}

		public Action OnFinish;
	}
}

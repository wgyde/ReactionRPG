using System;
using System.Collections.Generic;
using System.Linq;

public class TimeTracker
{
	private float _TimeRemaining = 0;
	public float TimeRemaining
	{
		get { return _TimeRemaining; }
		private set { _TimeRemaining = MathUtils.Max(0, value); }
	}

	public float TimeElapsed => Duration - TimeRemaining;

	private float _Duration = 0;
	public float Duration
	{
		get { return _Duration; }
		set { _Duration = MathUtils.Max(0, value); }
	}

	public bool Finished { get { return TimeRemaining == 0; } }

	public void Reset()
	{
		TimeRemaining = Duration;
	}

	public void Tick(float delta)
	{
		if (Finished)
			return;

		TimeRemaining -= delta;

		if (Finished)
			OnFinish();
	}

	public Action OnFinish = delegate { };
}

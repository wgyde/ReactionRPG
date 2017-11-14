using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
	public static class MathUtils
	{
		public const double TAU = Math.PI * 2.0;
		public const double RAD2DEG = 360.0 / TAU;
		public const double DEG2RAD = TAU / 360.0;

		public const float TAUF = (float)Math.PI * 2.0f;
		public const float RAD2DEGF = 360.0f / TAUF;
		public const float DEG2RADF = TAUF / 360.0f;

		public static int Clamp(this int value, int min, int max) { return Math.Min(Math.Max(min, value), max); }
		public static float Clamp(this float value, float min, float max) { return Math.Min(Math.Max(min, value), max); }
		public static double Clamp(this double value, double min, double max) { return Math.Min(Math.Max(min, value), max); }

		public static float Lerp(this float value, float start, float end) { return value.Clamp(0.0f, 1.0f) * (end - start) + start; }
		public static float InvLerp(this float value, float start, float end) { return ((value - start) / (end - start)).Clamp(0.0f, 1.0f); }
		
		public static bool IsBetween(this int value, int min, int max) { return value >= min && value < max; }
		public static bool IsBetween(this float value, float min, float max) { return value >= min && value < max; }
		public static bool IsBetween(this double value, double min, double max) { return value >= min && value < max; }

		public static int RoundToInt(this float f) { return (int)Math.Round(f); }
		public static int RoundToInt(this double d) { return (int)Math.Round(d); }
		public static float Floor(this float f) { return (float)Math.Floor(f); }
		public static int FloorToInt(this float f) { return (int)Math.Floor(f);}
		public static int FloorToInt(this double d) { return (int)Math.Floor(d); }
		public static float Ceil(this float f) { return (float)Math.Ceiling(f); }
		public static int CeilToInt(this float f) { return (int)Math.Ceiling(f); }
		public static int CeilToInt(this double d) { return (int)Math.Ceiling(d); }

		public static int Scale(this int i, double d) { return RoundToInt((double)i * d); }
		public static int ScaleByPercent(this int i, int p) { return i * p / 100; }
		public static int Pow(this int i, int p)
		{
			int ret = 1;
			while (p > 0)
			{
				if ((p & 1) == 1)
					ret *= i;
				p >>= 1;
				i *= i;
			}

			return ret;
		}

		public static int Min(int i1, int i2) { return i1 < i2 ? i1 : i2; }
		public static int Max(int i1, int i2) { return i1 > i2 ? i1 : i2; }
		public static float Min(float f1, float f2) { return f1 < f2 ? f1 : f2; }
		public static float Max(float f1, float f2) { return f1 > f2 ? f1 : f2; }
		public static double Min(double d1, double d2) { return d1 < d2 ? d1 : d2; }
		public static double Max(double d1, double d2) { return d1 > d2 ? d1 : d2; }

		public static float Mod(this int i, int m) { return ((i % m) + m) % m; }
		public static float Mod(this float f, float m) { return ((f % m) + m) % m; }

		public static float Abs(this float f) { return Math.Abs(f); }

		public static float SinRad(this float f) { return (float)Math.Sin(f); }
		public static float SinDeg(this float f) { return (float)Math.Sin(DEG2RADF * f); }
		public static float CosRad(this float f) { return (float)Math.Cos(f); }
		public static float CosDeg(this float f) { return (float)Math.Cos(DEG2RADF * f); }

		public static float DistanceMod(this float f1, float f2, float mod)
		{
			f1 = f1.Mod(mod);
			f2 = f2.Mod(mod);
			var diff = Abs(f1 - f2);
			return Min(diff, mod - diff);
		}

		public static float Pert(float p, float r, float dt)
		{
			return p * (float)Math.Pow(Math.E, r * dt);
		}
	}
}

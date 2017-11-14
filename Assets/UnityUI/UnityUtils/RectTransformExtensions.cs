using NSUtils.Exceptions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RectTransformExtensions
{
	public static float GetSize(this RectTransform transform, RectTransform.Axis axis)
	{
		switch (axis)
		{
			case RectTransform.Axis.Horizontal: return transform.rect.size.x;
			case RectTransform.Axis.Vertical: return transform.rect.size.y;
			default: throw UnsupportedEnumMemberException.GetGeneric(axis);
		}
	}

	public static void SetSizeWithCurrentAnchors(this RectTransform transform, float w, float h)
	{
		transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, w);
		transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);
	}

	public static Rect GetWorldRect(this RectTransform transform)
	{
		var min = transform.TransformPoint(new Vector3(transform.rect.xMin, transform.rect.yMin));
		var max = transform.TransformPoint(new Vector3(transform.rect.xMax, transform.rect.yMax));
		return new Rect(min, max - min);
	}

	public static void SetWorldRect(this RectTransform transform, Rect rect)
	{
		transform.position = Rect.NormalizedToPoint(rect, transform.pivot);
		transform.SetSizeWithCurrentAnchors(rect.width, rect.height);
	}

	public static void StretchAnchors(this RectTransform transform)
	{
		transform.anchorMin = Vector2.zero;
		transform.anchorMax = Vector2.one;
		transform.offsetMax = Vector2.zero;
		transform.offsetMin = Vector2.zero;
	}
}

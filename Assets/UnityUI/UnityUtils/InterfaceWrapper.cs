using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.UnityUI.UnityUtils
{
	class InterfaceWrapper<T> : MonoBehaviour
	where T : class
	{
		private T _Value;
		public T Value { get { FindValue(); return _Value; } }
		private void FindValue()
		{
			if (_Value != null) return;
			_Value = GetComponent<T>();
			if (_Value == null) Debug.LogWarning($"Can't find interface of type {typeof(T).Name} on gameObject {gameObject.name}");
		}
		protected virtual void Awake() { FindValue(); }
	}
}

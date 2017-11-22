using System.Collections.Generic;
using System.Linq;

public class SimplePool<T> : Pool<T>
where T : new()
{
	protected override T Create() => new T();
	protected override void Activate(T el) { }
	protected override void Deactivate(T el) { }
}

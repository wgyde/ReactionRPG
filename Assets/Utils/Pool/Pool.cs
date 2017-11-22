using System.Collections.Generic;
using System.Linq;

public abstract class Pool<T>
{
	private Queue<T> Elements;

	public Pool()
	{
		Elements = new Queue<T>();
	}

	public void Create(int amount)
	{
		while (amount-- > 0)
			Elements.Enqueue(Create());
	}

	protected abstract T Create();
	protected abstract void Activate(T el);
	protected abstract void Deactivate (T el);

	public T Take()
	{
		if (Elements.Count == 0)
		{
			System.Console.Error.WriteLine($"Pool \"{this}\" is out of instances. Creating {10} more.");
			Create(10);
		}
		var instance = Elements.Dequeue();
		Activate(instance);
		return instance;
	}

	public void Give(T el)
	{
		Deactivate(el);
		Elements.Enqueue(el);
	}
}

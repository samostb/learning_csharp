using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex09;
internal class MyList<T> : IEnumerable<T>
{
    private T?[] _storage = new T?[5];
    private int _count = 0;
    public void Add(T a)
    {
        if (_count >= _storage.Length)
        {
            var newStorage = new T?[_storage.Length * 2];
            for (int i = 0; i < _storage.Length; i++)
            {
                newStorage[i] = _storage[i];
            }
            _storage = newStorage;
        }
        _storage[_count] = a;

        _count++;
    }

    public int Count()
    {
        return _count;
    }

    public void Remove(T? a)
    {
        for (int i = 0; i < _storage.Length; i++)
        {
            if (_storage[i]!.Equals(a))
            {
                _storage[i] = default;
                _storage[i] = _storage[_count - 1];
                _storage[_count - 1] = default;
                _count--;
                return;

            }
        }
        
        
    }

    public void Print()
    {
        for (int i = 0; i < _storage.Length; i++)
        {
            Console.Write($"{_storage[i]} ");
        }
        Console.WriteLine($"||{_count}|| ");

    }

    public T? this[int index]
    {
        get => _storage[index];
        set => _storage[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

internal class MyListEnumerator<T> : IEnumerator<T?>
{
    private MyList<T?> _list;
    private int _position = -1;

    public MyListEnumerator(MyList<T?> list)
    {
        _list = list;
    }

    public T? Current => _list[_position];

    object? IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        _position++;
        return _position < _list.Count();

    }

    public void Reset()
    {
        _position = -1;
    }
}
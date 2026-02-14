using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex09;
internal class MyList<T>
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

}
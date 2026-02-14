using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex09;
internal class MyList
{
    private int?[] _storage = new int?[5];
    private int _count = 0;
    public void Add(int a)
    {
        if (_count >= _storage.Length)
        {
            var newStorage = new int?[_storage.Length * 2];
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

    public void Remove(int a)
    {
        for (int i = 0; i < _storage.Length; i++)
        {
            if (_storage[i] == a)
            {
                _storage[i] = null;
                _storage[i] = _storage[_count - 1];
                _storage[_count - 1] = null;
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
using System;
using System.Collections;
using System.Collections.Generic;

namespace Universe
{
  class Counter<T> : IEnumerable<KeyValuePair<T, int>>
  {
    Dictionary<T, int> Counts { get; set; }

    public IEnumerable<T> Keys
    {
      get
      {
        return Counts.Keys;
      }
    }

    public Counter()
    {
      Counts = new Dictionary<T, int>();
    }

    public void Add(T item)
    {
      if (Counts.ContainsKey(item))
      {
        Counts[item] += 1;
      }
      else
      {
        Counts[item] = 1;
      }
    }

    public void Add(T item, int count)
    {
      if (Counts.ContainsKey(item))
      {
        Counts[item] += count;
      }
      else
      {
        Counts[item] = count;
      }
    }

    public void AddRange(IEnumerable<T> items)
    {
      foreach (var item in items)
      {
        Add(item);
      }
    }

    public int this[T key]
    {
      get
      {
        if (Counts.ContainsKey(key))
        {
          return Counts[key];
        }
        else
        {
          return 0;
        }
      }
    }

    public IEnumerator<KeyValuePair<T, int>> GetEnumerator()
    {
      return Counts.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}

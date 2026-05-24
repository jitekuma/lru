# LRU

A simple generic LRU cache implementation for .NET.

## Examples

### Example 1: Using `int` values

```csharp
using System;
using System.Collections.Generic;
using LRU;

var cache = new LRU<int>(2);

cache.Add(10);
cache.Add(20);
cache.Add(10);
cache.Add(30);

IList<int> items = cache.GetItems();
foreach (int item in items)
{
    Console.WriteLine(item);
}
```

### Example 2: Using `string` values

```csharp
using System;
using System.Collections.Generic;
using LRU;

var cache = new LRU<string>(3);

cache.Add("alpha");
cache.Add("beta");
cache.Add("gamma");
cache.Add("alpha");
cache.Add("delta");

IList<string> items = cache.GetItems();
foreach (string item in items)
{
    Console.WriteLine(item);
}
```

The cache works with any `T` supported by the generic type, including value types and reference types.


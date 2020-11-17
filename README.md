# CSharp.Cacheable
So that we could cache properties' results instead of doing lazy initialization. C#

### What's supposed to be generated?

```cs
[Cacheable] public T Property => Function();
```

->

```cs
public T Property => property.GetValue();
private T property = new Container<T>(() => Function());
```
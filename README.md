# NetChalker

> A chalker library for .NET.

![](https://i.imgur.com/zMdi3Gz.png)

## Installation

1. Goto ``'Releases'``.
2. Download the latest version.
3. Reference the ``.dll`` into your Console Application Project.

## How to use
Create a new instance by typing
```CSharp
using NetChalker;
// ...


var chalker = new Chalker();
```

## Why
I originally created the first version for a project called [UniversalUnityHooks](https://github.com/UserR00T/UniversalUnityHooks) but later thought this was pretty useful as standalone. I then decided to improve the source code and release it.

## Example

```CSharp
// ...
using NetChalker;
// ...
public static Chalker ChalkerInstance { get; set; }
public static void Main()
{
  ChalkerInstance = new Chalker();
  foreach (var messageType in ChalkerInstance.MessageTypes)
    ChalkerInstance.WriteMessage(messageType.Value, "Hello World!");
}
```
<details><summary>Output</summary>
<p>

![](https://i.imgur.com/zMdi3Gz.png)

</p>
</details>

For more examples visit the source/Samples/ folder.

## Todo

- [ ] Refactor code / Redesign structure
- [ ] Build for multiple versions; currently only supports .NET 4.6.1, but can easily be changed to others.
- [ ] Upload to NuGet.
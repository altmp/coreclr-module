# StartProjectile

## Server

This event is called when a player creates a projectile. Return false to remove the projectile before it is seen from other players.

| Parameter     | Description                                          |
| ------------- | ---------------------------------------------------- |
| player        | The player who shot the projectile                   |
| startPosition | The startprojection of the projectile                |
| direction     | The direction of the projectile                      |
| ammoHash      | The ammoHash                                         |
| weaponHash    | The weaponHash                                       |

### Normal event handler

```csharp
Alt.OnStartProjectile += (player, startPosition, direction, ammoHash, weaponHash) => {
    // ...
    return true;
}
```

### Attribute event handler

> [!WARNING]
> Attribute event handlers only work in Scripts, or after executing Alt.RegisterEvents on a class instance.<br>
> For more info see: [Create script](../../getting-started/create-script.md)

```csharp
public class MyScript : IScript
{
    [ScriptEvent(ScriptEventType.StartProjectile)]
    public bool OnStartProjectile(IPlayer player, Position startPosition, Position direction, uint ammoHash, uint weaponHash)
    {
        // ...
        return true;
    }
}
```

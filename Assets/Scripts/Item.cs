using UnityEngine;

public class Item : MonoBehaviour
{
    Player player;

    public Item(Player p)
    {
        this.player = p;
    }

    public virtual void PlayerEffect()
    {
        return;
    }
}

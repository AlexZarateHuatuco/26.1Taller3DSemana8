using UnityEngine;

public class Kit : Item
{
    Player player;
    public Item(Player p) : base(p)
    {
        this.player = p;
    }
    public override void PlayerEffect()
    {
        player.hp+=5;
    }
}

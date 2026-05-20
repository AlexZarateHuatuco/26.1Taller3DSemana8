using UnityEngine;

public class PowerUp : Item
{
    Player player;
    public Item(Player p) : base(p)
    {
        this.player = p;
    }
    public override void PlayerEffect()
    {
        player.dmg*=1.5f;
    }
}

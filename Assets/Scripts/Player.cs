using UnityEngine;

public class Player : MonoBehaviour
{
    public float dmg = 12;
    public int hp = 20;

    public Player(float dmg, int hp)
    {
        this.dmg = dmg;
        this.hp = hp;
    }
}

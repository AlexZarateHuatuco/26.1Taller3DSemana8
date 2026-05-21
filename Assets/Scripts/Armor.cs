using UnityEngine;

public class Armor : MonoBehaviour
{

    [SerializeField] private string armorName;
    [SerializeField] protected int durability;

    public int Durability => durability;

    protected virtual void TakeHit()
    {
        durability--;
        Debug.Log( armorName + " durabilidad: " + durability );

        if (durability <= 0)
        {
            BreakArmor();
        }
    }

    protected virtual void BreakArmor()
    {
        Debug.Log(armorName + " rota");
        Destroy(gameObject);
    }

    protected void SetArmorData(string newName,int newDurability)
    {
        armorName = newName;
        durability = newDurability;
    }
}
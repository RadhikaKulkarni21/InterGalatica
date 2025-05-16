using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageValue = 10;
    public int GetDamage()
    {
        return damageValue;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class NPCInput : MonoBehaviour
{
    public ShipController controller;
    public ItemStore itemStore;
    public Shooting shooting;

    private void Awake()
    {
        float rand1 = Random.Range(1f, 2f);
        InvokeRepeating("GenerateRandomNumber", 0f, rand1);

        float rand2 = Random.Range(1f, 4f);
        InvokeRepeating("Shoot", 0f, rand2);

        float rand3 = Random.Range(5f, 10f);
        InvokeRepeating("UseItem", 0f, rand3);
    }

    private void GenerateRandomNumber()
    {
        controller.moveVertical = Random.Range(-1f, 1f);
        controller.moveHorizontal = Random.Range(-1f, 1f);
    }

    private void Shoot()
    {
        float direction = Random.Range(-1f, 1f);
        if (direction < 0f)
        {
            shooting.ShootBall(transform.right);
        }
        else
        {
            shooting.ShootBall(transform.right * -1f);
        }
    }

    private void UseItem()
    {
        itemStore.UseItem(0);
    }
}

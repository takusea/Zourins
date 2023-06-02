using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public ShipController controller;
    public ItemStore itemStore;
    public Shooting shooting;

    private void Update()
    {
        controller.moveVertical = Input.GetAxis("Vertical");
        controller.moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            itemStore.UseItem(0);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            shooting.ShootBall(transform.right * -1);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            shooting.ShootBall(transform.right);
        }
    }
}

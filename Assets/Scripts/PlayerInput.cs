using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    public ItemStore player;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スペースキーが押されたら、最初のアイテムを使用する
            player.UseItem(0);
        }
    }
}

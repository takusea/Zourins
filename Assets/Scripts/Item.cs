using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public abstract void Use();
    public abstract Sprite GetItemImage();
}

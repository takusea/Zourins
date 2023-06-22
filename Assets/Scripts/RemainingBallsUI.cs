using UnityEngine;
using TMPro;

public class RemainingBallsUI : MonoBehaviour
{
    public TMP_Text remainingBallsText; // 残弾数を表示するTextMeshProテキスト
    public Shooting shooting; // Shootingクラスの参照

    private void Start()
    {
        UpdateRemainingBallsUI(); // 初期表示の更新
    }

    private void UpdateRemainingBallsUI()
    {
        if (shooting != null)
        {
            remainingBallsText.text = string.Format("{0:D3}", shooting.RemainingBalls); // 残弾数をテキストに反映
        }
    }

    private void OnEnable()
    {
        if (shooting != null)
        {
            shooting.RemainingBallsChanged += UpdateRemainingBallsUI; // 残弾数が変更された時にUIを更新するイベントを登録
        }
    }

    private void OnDisable()
    {
        if (shooting != null)
        {
            shooting.RemainingBallsChanged -= UpdateRemainingBallsUI; // イベントの登録を解除
        }
    }
}

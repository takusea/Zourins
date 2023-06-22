using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText; // スコアを表示するTextMeshProテキスト

    private ScoreManager scoreManager; // ScoreManager の参照

    private void Start()
    {
        scoreManager = ScoreManager.Instance; // ScoreManager のインスタンスを取得

        UpdateScoreUI(); // 初期表示の更新
    }

    private void UpdateScoreUI()
    {
        scoreText.text = string.Format("{0:D6}", scoreManager.Score); // スコアをテキストに反映
    }

    private void OnEnable()
    {
        scoreManager.AddScoreEvent += UpdateScoreUI; // スコアが更新された時にUIを更新するイベントを登録
    }

    private void OnDisable()
    {
        scoreManager.AddScoreEvent -= UpdateScoreUI; // イベントの登録を解除
    }
}

using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance; // ScoreManager のインスタンス

    private int score = 0; // スコアの初期値

    public static ScoreManager Instance => instance; // ScoreManager のインスタンスを取得

    public int Score => score; // 現在のスコアの取得

    public UnityAction AddScoreEvent; // スコアが変更されたときに呼び出されるイベント

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // インスタンスを設定
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は削除する
        }
    }

    // スコアを加算する
    public void AddScore(int points)
    {
        score += points;

        // スコアが変更されたことを通知する
        AddScoreEvent?.Invoke();
    }

    // スコアをリセットする
    public void ResetScore()
    {
        score = 0;

        // スコアが変更されたことを通知する
        AddScoreEvent?.Invoke();
    }
}

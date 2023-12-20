using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class ScoreDisplay: MonoBehaviour {

  [SerializeField]
  private Counter counter;

  [SerializeField]
  private Timer timer;

  private TextMeshProUGUI tmp;

  private int score;

  void Start() {
    this.tmp = this.GetComponent<TextMeshProUGUI>();

    Assert.IsNotNull(this.counter);
    Assert.IsNotNull(this.timer);
    Assert.IsNotNull(this.tmp);

    this.score = 0;
  }

  void Update() {
    this.score = this.CalculateScore();

    this.tmp.SetText($"Score: {this.score.ToString()}");
  }

  public int CalculateScore() {
    return Mathf.RoundToInt(
      (((float) this.counter.count) * 100) / this.timer.elapsedTime
    );
  }
}

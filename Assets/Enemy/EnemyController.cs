using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyController: MonoBehaviour {

  public InteractEvent interactEvent;

  public PickUpEvent pickUpEvent;

  private EnemyDisplay enemyDisplay;

  private EnemyMovement enemyMovement;

  void Start() {
    this.enemyDisplay = this.GetComponent<EnemyDisplay>();
    this.enemyMovement = this.GetComponent<EnemyMovement>();

    Assert.IsNotNull(this.interactEvent);
    Assert.IsNotNull(this.pickUpEvent);
    Assert.IsNotNull(this.enemyDisplay);
    Assert.IsNotNull(this.enemyMovement);
  }

  void OnEnable() {
    this.interactEvent.e.AddListener(this.HandleInteract);
  }

  void OnDisable() {
    this.interactEvent.e.RemoveListener(this.HandleInteract);
  }

  public void HandleInteract(string name) {
    if (name != this.gameObject.name) return;

    Debug.Log($"[EnemyController#HandleInteract] {this.gameObject.name}");
    this.pickUpEvent.e.Invoke();

    this.enemyDisplay.Die();
  }
}


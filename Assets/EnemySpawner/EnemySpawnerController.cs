using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySpawnerController: MonoBehaviour {

  public GameObject prefabToSpawn;

  // public Enemy easyEnemyObject;

  // public Enemy hardEnemyObject;

  // public Enemy impossibleEnemyObject;

  public Enemy enemyObject;

  public Transform parentTransform;

  public EnemySpawner enemySpawner;

  private Camera cam;

  private Bounds cameraBounds;

  // public Vector3 minPosition;
  // public Vector3 maxPosition;

  void Start() {
    // this.camera = this.GetComponent<Camera>();
    this.cam = Camera.main;

    this.cameraBounds = new Bounds(
      new Vector3(0, 0, 0),
      new Vector3(
        this.cam.orthographicSize * 2 * this.cam.aspect,
        this.cam.orthographicSize * 2,
        0
      )
    );

    Assert.IsNotNull(this.prefabToSpawn);
    // Assert.IsNotNull(this.easyEnemyObject);
    // Assert.IsNotNull(this.hardEnemyObject);
    // Assert.IsNotNull(this.impossibleEnemyObject);
    Assert.IsNotNull(this.enemyObject);
    Assert.IsNotNull(this.parentTransform);
    Assert.IsNotNull(this.enemySpawner);
    Assert.IsNotNull(this.cam);
    Assert.AreNotEqual(this.cameraBounds, default(Bounds));

    this.SpawnGameObjects();
  }

  private void SpawnGameObjects() {
    for (int i = 0; i < this.enemySpawner.quantity; i++) {
      GameObject go = Instantiate(
        this.prefabToSpawn,
        this.GetRandomPosition(),
        Quaternion.identity,
        this.parentTransform
      );

      go.name = $"Enemy-{i}";
      // go.GetComponent<ResourceDisplay>().resource = this.GetRandomResourceObject();
    }
  }

  private Vector3 GetRandomPosition() {
    return new Vector3(
      Random.Range(this.cameraBounds.min.x, this.cameraBounds.max.x),
      Random.Range(this.cameraBounds.min.y, this.cameraBounds.max.y),
      Random.Range(this.cameraBounds.min.z, this.cameraBounds.max.z)
    );
  }

  // private Resource GetRandomResourceObject() {
  //   int randomIndex = Random.Range(0, this.enemyObjects.Length);

  //   return this.enemyObjects[randomIndex];
  // }
}

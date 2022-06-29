using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameHandler parentHandler { get; set; }
    private PlayerModel playerModel { get; set; }

    private List<GameObject> enemyInstances = new List<GameObject>();

    private const float enemySpeedBase = 0.7f;
    private const float enemySpeedDelta = 0.5f;

    public void Init(GameHandler gameHandler, PlayerModel playerModel)
    {
        parentHandler = gameHandler;
        this.playerModel = playerModel;
    }

    public EnemyController SpawnNewEnemy()
    {
        var view = Instantiate(parentHandler.EnemyPrefab);
        view.AddComponent<EnemyView>();
        enemyInstances.Add(view);
        var startPos = new Vector4(Random.Range(-3.5f, 3.5f),
                                   Random.Range(-5.5f, 5.5f),
                                   0f,
                                   0f);
        var model = new EnemyModel(startPos, Random.Range(enemySpeedBase - enemySpeedDelta / 2, enemySpeedBase + enemySpeedDelta / 2), 0);
        return new EnemyController(model, view.GetComponent<EnemyView>(), parentHandler, playerModel);
    }
}

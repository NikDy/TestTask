using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class FoodSpawner : MonoBehaviour
{
    public GameHandler parentHandler { get; set; }
    private PlayerModel playerModel { get; set; }

    private List<GameObject> foodInstances = new List<GameObject>();

    public void Init(GameHandler gameHandler, PlayerModel playerModel)
    {
        parentHandler = gameHandler;
        this.playerModel = playerModel;
    }

    public FoodController SpawnNewFood()
    {
        var view = Instantiate(parentHandler.FoodPrefab);
        view.AddComponent<FoodView>();
        foodInstances.Add(view);
        var startPos = new Vector4(Random.Range(-3.5f, 3.5f),
                                   Random.Range(-5.5f, 5.5f),
                                   0f,
                                   0f);
        var model = new FoodModel(startPos);
        return new FoodController(model, view.GetComponent<FoodView>(), parentHandler);
    }

}

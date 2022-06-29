using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public enum GAMESTATE
{
    BEGINSCREEN = 0,
    INGAME = 1,
    SCORESCREEN = 2
}


public class GameHandler : MonoBehaviour
{
    public int numberOfEnemies;
    public int numberOfFood;

    public CanvasGroup scoreScreen;
    public CanvasGroup beginScreen;

    public GameObject EnemyPrefab;
    public GameObject FoodPrefab;

    public PlayerView player;
    public int playerLives = 3;
    public float playerSpeed = 3f;
    private PlayerController playerController;
    public PlayerModel playerModel;

    private List<EnemyController> enemyControllerList = new List<EnemyController>();
    private List<FoodController> foodControllerList = new List<FoodController>();

    private EnemySpawner enemySpawner;
    private FoodSpawner foodSpawner;
    
    public delegate void UpdateHandler();
    public event UpdateHandler MoveUpdate;

    private GAMESTATE currentGameste = GAMESTATE.BEGINSCREEN;

    public int bestScore;

    void Start()
    {
        SetBeginScreen();
        playerModel = new PlayerModel(new Vector4(0, 0, 0, 0), 0, playerLives, playerSpeed);
        var playerInput = gameObject.AddComponent(Type.GetType("PlayerInput"));
        enemySpawner = gameObject.AddComponent<EnemySpawner>();
        enemySpawner.Init(this, playerModel);
        foodSpawner = gameObject.AddComponent<FoodSpawner>();
        foodSpawner.Init(this, playerModel);
        
        playerController = new PlayerController(playerModel, player, (PlayerInput)playerInput, this);
    }

    private void SetScoreScreen()
    {
        currentGameste = GAMESTATE.SCORESCREEN;
        scoreScreen.alpha = 1;
        scoreScreen.blocksRaycasts = true;
        scoreScreen.interactable = true;
        beginScreen.alpha = 0;
        beginScreen.blocksRaycasts = false;
        beginScreen.interactable = false;
        foreach (var food in foodControllerList)
        {
            food.DestroyView();
        }
        foreach (var enemy in enemyControllerList)
        {
            enemy.DestroyView();
        }
        foodControllerList.Clear();
        enemyControllerList.Clear();

        bestScore = ReadDataFromFile().bestScore;
        if (playerModel.points > bestScore)
        {
            bestScore = playerModel.points;
            WriteDataToFile(new GameModel { bestScore = this.bestScore });
        }
    }

    private void SetBeginScreen()
    {
        currentGameste = GAMESTATE.BEGINSCREEN;
        scoreScreen.alpha = 0;
        scoreScreen.blocksRaycasts = false;
        scoreScreen.interactable = false;
        beginScreen.alpha = 1;
        beginScreen.blocksRaycasts = true;
        beginScreen.interactable = true;
        foreach (var food in foodControllerList)
        {
            food.DestroyView();
        }
        foreach (var enemy in enemyControllerList)
        {
            enemy.DestroyView();
        }
        foodControllerList.Clear();
        enemyControllerList.Clear();
    }

    private void SetInGameScreen()
    {
        currentGameste = GAMESTATE.INGAME;
        playerModel.points = 0;
        playerModel.lives = playerLives;

        scoreScreen.alpha = 0;
        scoreScreen.blocksRaycasts = false;
        scoreScreen.interactable = false;
        beginScreen.alpha = 0;
        beginScreen.blocksRaycasts = false;
        beginScreen.interactable = false;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            AddEnemyController(enemySpawner.SpawnNewEnemy());
        }
        for (int i = 0; i < numberOfFood; i++)
        {
            AddFoodController(foodSpawner.SpawnNewFood());
        }
    }

    public void ChangeGameState(GAMESTATE state)
    {
        if (state == GAMESTATE.SCORESCREEN)
            SetScoreScreen();
        else if (state == GAMESTATE.INGAME)
            SetInGameScreen();
        else if (state == GAMESTATE.BEGINSCREEN)
            SetBeginScreen();
    }

    private void WriteDataToFile(GameModel data)
    {
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", JsonUtility.ToJson(data));
    }


    private GameModel ReadDataFromFile()
    {
        if (!File.Exists(Application.persistentDataPath + "/gameData.json")) return new GameModel() { bestScore = 0};
        return JsonUtility.FromJson<GameModel>(File.ReadAllText(Application.persistentDataPath + "/gameData.json"));
    }

    public void AddEnemyController(EnemyController enemyController)
    {
        enemyControllerList.Add(enemyController);
    }


    public void AddFoodController(FoodController foodController)
    {
        foodControllerList.Add(foodController);
    }


    public List<FoodController> GetFoodContollers()
    {
        return foodControllerList;
    }

    public List<EnemyController> GetEnemyControllers()
    {
        return enemyControllerList;
    }


    private void Update()
    {
        if (currentGameste == GAMESTATE.INGAME)
        {
            if (enemyControllerList.Count > 0 || playerController != null)
                MoveUpdate();
            if (enemyControllerList.Count < this.numberOfEnemies)
                AddEnemyController(enemySpawner.SpawnNewEnemy());
            if (foodControllerList.Count < this.numberOfFood)
                AddFoodController(foodSpawner.SpawnNewFood());
        }
    }

}


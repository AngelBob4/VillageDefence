using UnityEngine;

public class EnemyGeneratorView : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    private int _waveCounter = 0;
    private int _startAmountOfEnemies = 10;

    private void Awake()
    {
        //_enemies = new ObjectPool(_template);
        //GenerateEnemy(2);
    }

    public void StartNextWave()
    {
        //StartCoroutine(GenerateWave());
    }

    private void GenerateWave(int amountOfEnemies)
    {
        /*
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Enemy enemy = _enemies.GetObject();
            enemy.gameObject.SetActive(true);
            Debug.Log(enemy.name);
        }
        */
    }
}
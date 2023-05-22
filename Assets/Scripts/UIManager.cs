using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] TMP_Text txtEnemyCount;

    int enemyCount = 0;

    private void Awake()
    {
        if(Instance != null && Instance != this) 
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        DisplayEnemyCount();
    }

    void DisplayEnemyCount()
    {
        txtEnemyCount.text = $"Enemy Count: {enemyCount}";
    }

    public void UpdateEnemy(int enemy)
    {
        enemyCount += enemy;
        DisplayEnemyCount();
    }


}

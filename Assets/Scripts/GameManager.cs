using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public GameObject player;

    public Queue<GameObject> scaffoldingQueue;
    public Queue<GameObject> garbageScaffoldingQueue;
    public Transform scaffoldingDir;

    public Transform spawnPoint;

    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<GameManager>() as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
        else if (_instance != this)
            Destroy(gameObject);
        // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        scaffoldingQueue = new Queue<GameObject>();
        garbageScaffoldingQueue = new Queue<GameObject>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        AddScaffolding();

        ScaffoingNextStep();

        SpawnPlayer();
    }


    void AddScaffolding()
    {
        for (int i = 0; i < scaffoldingDir.childCount; i++)
        {
            scaffoldingQueue.Enqueue(scaffoldingDir.GetChild(i).gameObject);
        }
    }

    public void ScaffoingNextStep()
    {
        for(int i=0; i<3; i++)
        {
            var scaf = scaffoldingQueue.Dequeue();
            scaf.SetActive(true);
            garbageScaffoldingQueue.Enqueue(scaf);
        }
    }

    public void SpawnPlayer()
    {
        ObjectPooler.SpawnFromPool("Player", spawnPoint.position);
    }
}

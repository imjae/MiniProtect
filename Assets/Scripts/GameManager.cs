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

    public void ResetScaffolding()
    {
        // ���� garbageť�� �������� Ȱ��ȭ�� ������ gargabeť�� ���� �ֱ�
        while(scaffoldingQueue.Count > 0)
            garbageScaffoldingQueue.Enqueue(scaffoldingQueue.Dequeue());

        // ��� ���� �ٽ� Ȱ��ȭ���� ť�� ����ֱ�
        while(garbageScaffoldingQueue.Count > 0)
        {
            var tmpScaffolding = garbageScaffoldingQueue.Dequeue();
            tmpScaffolding.SetActive(false);
            tmpScaffolding.GetComponent<Collider>().enabled = true;
            scaffoldingQueue.Enqueue(tmpScaffolding);
        }
    }

    public void SpawnPlayer()
    {
        ObjectPooler.SpawnFromPool("Player", spawnPoint.position);
    }
}

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
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
            Destroy(gameObject);
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
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
        // 아직 garbage큐에 들어가지않은 활성화된 발판을 gargabe큐에 전부 넣기
        while(scaffoldingQueue.Count > 0)
            garbageScaffoldingQueue.Enqueue(scaffoldingQueue.Dequeue());

        // 모든 발판 다시 활성화발판 큐에 집어넣기
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

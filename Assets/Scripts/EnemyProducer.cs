using MessagePipe;
using System.Collections;
using UnityEngine;
using VContainer;

public class EnemyProducer : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [Inject]ISubscriber<TheWorld> OnStop { get; set; }
    void Update()
    {
        if(Random.Range(0, 30) == 15)
        {
            var obj = Instantiate(enemy, new Vector3(Random.Range(-2.0f, 2.0f), 4.5f, 0.0f), Quaternion.identity);
            var enm = obj.GetComponent<Enemy>();
            
            enm.SetUp(OnStop);

            StartCoroutine(DeleteObj(obj));
        } 
    }

    IEnumerator DeleteObj(GameObject gameObj)
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObj);
    }
}

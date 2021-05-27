using MessagePipe;
using UnityEngine;
using VContainer;

public class Stopper : MonoBehaviour
{
    [Inject] IPublisher<TheWorld> stopEvent { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たった！");
        stopEvent.Publish(new TheWorld() { speed = 0.2f });
    }
}

public class TheWorld
{
    public float speed;
}
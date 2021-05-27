using MessagePipe;
using UnityEngine;
using VContainer;

public class Enemy : MonoBehaviour
{
    float random = 0.0f;
    float speed = 1.0f;
    ISubscriber<TheWorld> OnStop { get; set; }

    private System.IDisposable disposable;
    public void SetUp(ISubscriber<TheWorld> theWorld)
    {
        OnStop = theWorld;
        var d = DisposableBag.CreateBuilder();
        OnStop.Subscribe(ev =>
        {
            speed = ev.speed;
        }).AddTo(d);

        disposable = d.Build();
        random = Random.Range(-0.01f, 0.01f);
    }

    void Update()
    {
        this.transform.Translate(random * speed, -0.03f * speed, 0.0f);
    }

    private void OnDestroy()
    {
        disposable.Dispose();
    }
}


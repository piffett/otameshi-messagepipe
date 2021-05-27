using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainLifetimeScope : LifetimeScope
{

    protected override void Configure(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe(/* configure option */);
        builder.RegisterMessageBroker<TheWorld>(options);
    }
}

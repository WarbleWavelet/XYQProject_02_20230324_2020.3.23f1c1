using UnityEngine;
/// <summary>
///  遇“墙”停下来
/// </summary>
public struct SetWillStoppingStateCommand : ICommand
{
    public void Execute(object obj)
    {
        this.GetSystem<ISceneSystem>().PlayerNormalAI.willStopping = true;
    }
}

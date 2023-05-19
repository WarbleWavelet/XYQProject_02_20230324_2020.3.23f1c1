using UnityEngine;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：人物死亡命令
/// 参数:
/// </summary>
public struct CharacterDieCommand : ICommand
{
    public void Execute(object obj)
    {
        IFightSystem sys = this.GetSystem<IFightSystem>();
        AudioSourceManager.Instance.PlaySoundCharacter( ResourcesName.AudioClip.FlyAway);
        Time.timeScale = 1;
        sys.DieCnt++;
        sys.EnterCurRound = false;
    }
}

/****************************************************

	文件：ResourcesName.cs
	作者：WWS
	日期：2023/04/04 20:58:16
	功能：

*****************************************************/

using System;

public static partial class ResourcesName
{
    public static partial class AudioClip
    {
        public const string DongHaiWan = "DongHaiWan";
        public const string FightBG = "Fight/FightBG";
        public const string Attack = "Attack";
        public const string FlyAway = "FlyAway";
        public const string RecoverHP = "AudioClips/Characters/Common/RecoverHP";
        public const string RecoverMP = "AudioClips/Characters/Common/RecoverMP";
        public const string Defend = "Defend";
        public const string Common = "Common";

        public static string GetCharacterAudioClipPath(string characterName,string soundName)
        {
            return String.Format("AudioClips/Characters/{0}/{1}"  , characterName , soundName);
        }

    }

    public static partial class Texture2D
    {
        public static  class Cursor
        {
            public const string Normal = "UI/Cursor/Normal";
            public const string Attack = "UI/Cursor/Attack";
            public const string Forbid = "UI/Cursor/Forbid";
            public const string Skill = "UI/Cursor/Skill";
        }

        public static string GetCharacterFightIdlePath(string characterName)
        {
            return "Character/" + characterName + "/Fight/Idle/";
        }
    }
    public static partial class Prefab
    {
        public const string CharacterNumCanvas = "Prefabs/CharacterNumCanvas";
        public const string CursorEffect = "Prefabs/CursorEffect";
        public const string HengSaoDebuff = "Prefabs/HengSaoDebuff";
        public const string RecoverHPEffect = "RecoverHPEffect";
        public const string RecoverMPEffect = "RecoverMPEffect";
        public const string AttackEffect = "Prefabs/AttackEffect";
        public const string CharacterFight = "Prefabs/CharacterFight";
        public const string DefendEffect = "Prefabs/DefendEffect";
    }

    public static partial class OverrideController
    {
        public static string CharacterPath(string characterPathName)
        {
            return String.Format("Character/{0}/Fight/FightController", characterPathName);
        }
    }

}
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
/// <summary>
/// 创建人：Trigger 
/// 命令名称：在战斗开始后生成战斗敌人与玩家
/// 参数:
/// </summary>
public struct CreateCharactersCommand : ICommand
{

    public void Execute(object obj)
    {
        // new Execute01(this, obj);
        new Execute02(this, obj);
    }
    #region 原版本
    class Execute01
    {
        private CreateCharactersCommand cmd;
        private object obj;

        public Execute01(CreateCharactersCommand cmd, object obj)
        {
            this.cmd = cmd;
            this.obj = obj;
            Execute(obj);
        }
        #region 生成位置有问题，贴一下原版的


        public void Execute(object obj)
        {
            //玩家
            IFightSystem ifs = cmd.GetSystem<IFightSystem>();
            ifs.PlayerAI = GameObject.Instantiate(ifs.CharacterPrefab, ifs.PlayerInitPosTrans);
            ifs.PlayerAI.transform.localPosition = Vector3.zero;
            ifs.PlayerAI.isPlayer = true;
            ifs.CurActAILst.Add(ifs.PlayerAI);
            InitCharacterData(ifs.PlayerAI);
            //敌人
            int num = Random.Range(1, 10);
            for (int i = 0; i < num; i++)
            {
                ifs.EnemyAIList.Add(GameObject.Instantiate(ifs.CharacterPrefab, ifs.EnemyInitPosTrans[i]));
                ifs.EnemyAIList[i].transform.localPosition = Vector3.zero;
                ifs.CurActAILst.Add(ifs.EnemyAIList[i]);
                ifs.EnemyAIList[i].isPlayer = false;
                InitCharacterData(ifs.EnemyAIList[i]);
            }
            ifs.CurActAILst = ifs.CurActAILst.OrderByDescending(p => p.actRate).ToList();
        }

        private void InitCharacterData(CharacterFightAI cfa)
        {
            IFightSystem ifs = cmd.GetSystem<IFightSystem>();
            if (cfa.isPlayer)
            {
                cfa.actRate = 8;
                cfa.SetDieMovePath(ifs.PlayerDieStartMovePath, ifs.PlayerDieEndMovePath);
                cfa.tag = "Player";
                cfa.characterInfo = cmd.GetModel<ICharacterDataModel>().GetCharacterInfo(2);
            }
            else
            {
                cfa.actRate = Random.Range(1, 10);
                cfa.SetDieMovePath(ifs.EnemyDieStartMovePath, ifs.EnemyDieEndMovePath);
                cfa.tag = "Enemy";
                cfa.characterInfo = cmd.GetModel<ICharacterDataModel>().GetCharacterInfo(Random.Range(1, 6));
            }
            cfa.name = cfa.characterInfo.pathName;
        }
        #endregion

    }
    #endregion

    #region 我的版本
    class Execute02
    {

        IFightSystem sys;
        /// <summary>发生战斗实例位置不跟随玩家变化</summary>
        private CreateCharactersCommand cmd;
        private object obj;

        public Execute02(CreateCharactersCommand createCharactersCommand, object obj)
        {
            this.cmd = createCharactersCommand;
            this.obj = obj;
            Execute(this.obj);
        }

        public void Execute(object obj)
        {

            sys = cmd.GetSystem<IFightSystem>();
            InstantiatePlayer();
            InstantiateEnemys();
            sys.CurActAILst = sys.CurActAILst.OrderByDescending(p => p.actRate).ToList(); //按速度安排角色先后行动
        }

        void InstantiatePlayer()
        {
            //玩家
            CharacterFightAI ai = GameObject.Instantiate(sys.CharacterPrefab, sys.PlayerInitPosTrans);
            ai.transform.localPosition = Vector3.zero;
            ai.initPos = ai.transform.position;            
            ai.isPlayer = true;
            sys.PlayerAI = ai;
            sys.CurActAILst.Add(ai);
            InitCharacterData(ai);

        }

        void InstantiateEnemys()
        {
            //敌人
            int num = Random.Range(1, 10);
            for (int i = 0; i < num; i++)
            {
                CharacterFightAI ai = GameObject.Instantiate(sys.CharacterPrefab, sys.EnemyInitPosTrans[i]);
                ai.transform.localPosition = Vector3.zero;
                ai.initPos = ai.transform.position;                
                ai.isPlayer = false;
                sys.EnemyAIList.Add(ai);
                sys.CurActAILst.Add(ai);
                InitCharacterData(ai);

            }

        }

        /// <summary>
        /// 需要注意顺序
        /// </summary>
        /// <param name="ai"></param>
        private void InitCharacterData(CharacterFightAI ai)
        {
            int playerID = 2;
            int enemyID = Random.Range(1, 6);
            ai.Init4PosTransesAnd2LookDirs();
            ai.InitMoveFightBehaviour();//后面要用到SetDieMovePath，所以放这里


            if (ai.isPlayer)
            {
                ai.tag = Tags.PLAYER;
                ai.actRate = 8;
                ai.characterInfo = cmd.GetModel<ICharacterDataModel>().GetCharacterInfo(playerID);
                ai.SetDieMovePath(sys.PlayerDieStartMovePath, sys.PlayerDieEndMovePath);
            }
            else
            {
                ai.tag = Tags.ENEMY;
                ai.actRate = Random.Range(1, 10);
                ai.characterInfo = cmd.GetModel<ICharacterDataModel>().GetCharacterInfo(enemyID);
                ai.SetDieMovePath(sys.EnemyDieStartMovePath, sys.EnemyDieEndMovePath);
            }
            ai.name = ai.characterInfo.pathName;
            ai.InitComponents();

        }
        #endregion
    }
    //不想再方法中重写01,02，所以直接单独出类




}

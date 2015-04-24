using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using TowerDefense.Model.Enemies;

namespace TowerDefense.Model.Enemy
{
    public static class EnemyFactory
    {
        public static List<Enemies.Enemy> GenerateWave(short round, string difficulty)
        {
            List<Enemies.Enemy> enemyLS = GenerateDynamicWave(round);
            if (round < 30)
            {
                foreach (Enemies.Enemy temp in enemyLS)
                {
                    if (difficulty == "Easy")
                    {
                        temp.Health = (int)(temp.Health * 0.8);
                        if(temp.Speed > 1) temp.Speed = (int)(temp.Speed * 0.8);
                    }

                    if (difficulty == "Hard")
                    {
                        temp.Health = (int)(temp.Health * 1.2);
                        temp.Speed = (int)(temp.Speed * 1.2);
                    }
                }
            }

            else
            {
                foreach (Enemies.Enemy temp in enemyLS)
                {
                    if (difficulty == "Easy")
                    {
                        temp.Health = (int)(temp.Health * 1);
                        temp.Speed = (int)(temp.Speed * 1);
                    }

                    if (difficulty == "Normal")
                    {
                        temp.Health = (int)(temp.Health * 1.2);
                        temp.Speed = (int)(temp.Speed * 1.2);
                    }

                    if (difficulty == "Hard")
                    {
                        temp.Health = (int)(temp.Health * 1.4);
                        temp.Speed = (int)(temp.Speed * 1.4);
                    }
                }
            }

            //double Num Of Enemies
            if (difficulty == "Hard" && round != 23)
            {
                foreach(Enemies.Enemy tempEnemy in GenerateDynamicWave(round))
                {
                    enemyLS.Add(tempEnemy);
                }
            }

            return enemyLS;
        }    
        
        public static List<Enemies.Enemy> GenerateDynamicWave(int round)
        {
            List<Enemies.Enemy> enemyReferenceList = new List<Enemies.Enemy>();
            List<Enemies.Enemy> enemyRandomList = new List<Enemies.Enemy>();
            Random rnd = new Random();

            if (round == 23)
            {
                enemyRandomList.Add(new Trey());
                for (int i = 1; i <= 23; i++)
                {
                    enemyRandomList.Add(new Sanic());
                    enemyRandomList[i].Speed *= 2;
                    enemyRandomList[i].Health /= 2;
                }
            }

            else
            {
                //Generate Gaben
                for (int i = 0; i < round; i++) enemyReferenceList.Add(new Gaben());
                //Generate Sanics
                for (int i = 0; i < round / 2; i++) enemyReferenceList.Add(new Sanic());
                //Generate Mr. Krabs
                for (int i = 0; i < round / 3; i++) enemyReferenceList.Add(new Mr_Krabs());
                //Generate Kalvin 
                if (round % 6 == 0)
                {
                    for (int i = 0; i < round / 6; i++) enemyReferenceList.Add(new Lord_Calvin());
                }
                //Generate William
                if (round % 5 == 0)
                {
                    for (int i = 0; i < round / 5; i++) enemyReferenceList.Add(new William());
                }
            }

            while(enemyReferenceList.Count > 0)
            {
                int randomNum = rnd.Next(0, enemyReferenceList.Count);
                enemyRandomList.Add(enemyReferenceList[randomNum]);
                enemyReferenceList.RemoveAt(randomNum);
            }
                return enemyRandomList;
        }
    }
}
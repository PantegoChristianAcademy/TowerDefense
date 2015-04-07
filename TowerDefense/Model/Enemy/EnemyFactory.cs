﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Model.Enemy
{
    public static class EnemyFactory
    {
        public static List<Enemies.Enemy> GenerateWaveE(byte WaveNumb)
        {
            switch (WaveNumb)
            {
                case 1:
                    return CreateWave1();
                case 2:
                    return CreateWave2();
                case 3:
                    return CreateWave3();
                case 4:
                    return CreateWave4();
                case 5:
                    return CreateWave5();
                case 6:
                    return CreateWave6();
                case 7:
                    return CreateWave7();
                case 8:
                    return CreateWave8();
                case 9:
                    return CreateWave9();
                case 10:
                    return CreateWave10();
            
            }

            return new List<Enemies.Enemy>();
        }

        public static List<Enemies.Enemy> CreateWave1()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x <8; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            return enemies;
        }

        public static List<Enemies.Enemy> CreateWave2()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 12; x++)
            {
                enemies.Add(new Enemies.Sanic());       
            }
            return enemies;
        }

        public static List<Enemies.Enemy> CreateWave3()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 11; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            enemies.Add(new Enemies.Mr_Krabs());
            enemies.Add(new Enemies.Mr_Krabs());
            return enemies;
        }

        public static List<Enemies.Enemy> CreateWave4()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 15; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 4; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            return enemies;
            }
        public static List<Enemies.Enemy> CreateWave5()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 18; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 6; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            return enemies;
        }

        public static List<Enemies.Enemy> CreateWave6()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 20; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 9; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            return enemies;
        }

        public static List<Enemies.Enemy> CreateWave7()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 24; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 13; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            for (int x = 0; x < 1; x++)
            {
                enemies.Add(new Enemies.Gaben());
                enemies.Add(new Enemies._75_off());
                enemies.Add(new Enemies._50_off ());
            }
                return enemies;
        }
        public static List<Enemies.Enemy> CreateWave8()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 27; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 17; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            for (int x = 0; x < 3; x++)
            {
                enemies.Add(new Enemies.Gaben());
                enemies.Add(new Enemies._75_off());
                enemies.Add(new Enemies._50_off());
            }
            return enemies;
        }

        public static List<Enemies.Enemy> CreateWave9()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 30; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 20; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            for (int x = 0; x < 6; x++)
            {
                enemies.Add(new Enemies.Gaben());
                enemies.Add(new Enemies._75_off());
                enemies.Add(new Enemies._50_off());
            }
            return enemies;
        }
        public static List<Enemies.Enemy> CreateWave10()
        {
            List<Enemies.Enemy> enemies = new List<Enemies.Enemy>();
            for (int x = 0; x < 34; x++)
            {
                enemies.Add(new Enemies.Sanic());
            }
            for (int x = 0; x < 22; x++)
            {
                enemies.Add(new Enemies.Mr_Krabs());
            }
            for (int x = 0; x < 7; x++)
            {
                enemies.Add(new Enemies.Gaben());
                enemies.Add(new Enemies._75_off());
                enemies.Add(new Enemies._50_off());
            }
            enemies.Add(new Enemies.Plane());
            return enemies;
        }

    }
}
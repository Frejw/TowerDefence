using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TowerDefence
{
    static class EnemyManager
    {
        private static int waveIndex = 0;
        private static int previousWaveIndex;
        private static float timeBetweenWaves = 10000f;
        private static float waveTimer = 0f;
        private static int normalEnemiesPerWave;
        private static int fastEnemiesPerWave;
        private static float timeBetweenSpawns = 2f;
        private static float spawnTimer = 0f;

        public static float WaveTimer { get { return waveTimer; } set { waveTimer = value; } }

        public static float TimeBetweenWaves { get { return timeBetweenWaves; } }

        static List<Enemy> enemyList = new List<Enemy>();
        public static List<Enemy> EnemyList { get { return enemyList; } }

        static List<Enemy> spawnedEnemies = new List<Enemy>();

        private static int WaveIndex
        {
            get { return waveIndex; }
            set
            {
                waveIndex = value;
                
                if (value != 0)
                {
                    previousWaveIndex = waveIndex;
                }
            }
        }

        public static void Update(GameTime gameTime)
        {
            spawnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            switch (WaveIndex)
            {
                case 0:
                    if (enemyList.Count <= 0)
                    {
                        waveTimer += (float)gameTime.TotalGameTime.TotalSeconds;
                        if (waveTimer >= timeBetweenWaves)
                        {
                            WaveIndex = previousWaveIndex + 1;
                            waveTimer = 0f;
                        }
                    }
                    break;

                case 1:
                    normalEnemiesPerWave = 10;
                    fastEnemiesPerWave = 5;
                    SpawnEnemy();
                    break;

                case 2:
                    normalEnemiesPerWave = 20;
                    fastEnemiesPerWave = 10;
                    SpawnEnemy();
                    break;

            }

            //if (enemyList.Count == 0)
            //{
            //    waveTimer += (float)gameTime.TotalGameTime.TotalSeconds;
            //    spawnTimer += (float)gameTime.TotalGameTime.TotalSeconds;

            //    if (waveTimer >= timeBetweenWaves)
            //    {
            //        StartWave();
            //        waveTimer = 0f;
            //    }
            //}


            //for (int i = 0; i < enemyList.Count; i++)
            //{
            //    enemyList[i].Update(gameTime);

            //    enemyList[i].CurveCurPos += enemyList[i].Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;



            //    if (enemyList[i].Health <= 0)
            //    {
            //        Player.Money += enemyList[i].KillValue;
            //        enemyList.RemoveAt(i);
            //    }

            //    if (enemyList[i].CurveCurPos >= 1)
            //    {
            //        Player.Health -= enemyList[i].Damage;
            //        enemyList.RemoveAt(i);
            //    }
            //}

            //foreach (Enemy enemy in enemyList)
            //{
            //    enemy.Update(gameTime);

            //    enemy.CurveCurPos += enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //    if (enemy.Health <= 0)
            //    {
            //        Player.Money += enemy.KillValue;
            //        enemyList.Remove(enemy);
            //    }

            //    if (enemy.CurveCurPos >= 1)
            //    {
            //        Player.Health -= enemy.Damage;
            //        enemyList.Remove(enemy);
            //    }
            //}

            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                Enemy enemy = enemyList[i];
                enemy.Update(gameTime);

                enemy.CurveCurPos += enemy.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (enemy.Health <= 0)
                {
                    Player.Money += enemy.KillValue;
                    enemyList.RemoveAt(i);
                }

                if (enemy.CurveCurPos >= 1)
                {
                    Player.Health -= enemy.Damage;
                    enemyList.RemoveAt(i);
                }
            }

        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            //foreach (Enemy enemy in enemyList)
            //{
            //    enemy.Draw(spriteBatch);
            //}

            spriteBatch.DrawString(Assets.fontArial, "waveIndex: " + WaveIndex, new Vector2(1300, 60), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, "previousWaveIndex: " + previousWaveIndex, new Vector2(1300, 75), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial,"wave timer: " + waveTimer , new Vector2(1300, 90), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, "spawnTimer: " + spawnTimer, new Vector2(1300, 105), Color.LightBlue);
            spriteBatch.DrawString(Assets.fontArial, "Spawned enemies: " + spawnedEnemies.Count, new Vector2(1300, 120), Color.LightBlue);
            
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Draw(spriteBatch);

                //float healthBarWidth = (float)enemyList[i].Health / enemyList[i].MaxHealth;
                //spriteBatch.Draw(Assets.blackTex, new Rectangle(100, 100, 50, 10), Color.White);
                //spriteBatch.Draw(Assets.greenTex, new Rectangle(100, 100, (int)healthBarWidth, 10), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.3f);

                spriteBatch.DrawString(Assets.fontArial, i + enemyList[i].ToString(), new Vector2(1300, 200 + i * 15), Color.LightBlue);
            }
        }

        public static void CreateEnemy(Type enemy)
        {
            enemyList.Add((Enemy)Activator.CreateInstance(enemy));
            spawnedEnemies.Add((Enemy)Activator.CreateInstance(enemy));
        }

        private static void SpawnEnemy()
        {
            if (spawnedEnemies.Count(enemy => enemy is NormalEnemy) < normalEnemiesPerWave)
            {
                if (spawnTimer >= timeBetweenSpawns)
                {
                    CreateEnemy(typeof(NormalEnemy));
                    spawnTimer = 0f;
                }
            }
            else if (spawnedEnemies.Count(enemy => enemy is FastEnemy) < fastEnemiesPerWave)
            {
                if (spawnTimer >= timeBetweenSpawns)
                {
                    CreateEnemy(typeof(FastEnemy));
                    spawnTimer = 0f;
                }
            }
            else
            {
                spawnedEnemies.Clear();
                WaveIndex = 0;
            }
        }

        //private static void StartWave()
        //{
        //    waveIndex++;

        //    int i = 0;
        //    if (spawnTimer >= timeBetweenSpawns && i < enemiesPerWave)
        //    {
        //        waveIndex++;
        //        CreateEnemy(typeof(NormalEnemy));
        //        spawnTimer = 0f;
        //        i++;
        //    }
        //}
    }
}

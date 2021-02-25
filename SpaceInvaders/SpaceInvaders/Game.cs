using System;
using System.Collections.Generic;

namespace SpaceInvaders {
    public class Game {
        private const int PLAYER_LIVES = 3;
        private const int ENEMY_LIVES = 2;
        public int score { get; private set; }
        public int diedShips { get; private set; }
        public Game(int Width, int Height)
        {
            random = new Random();
            lastSpawn = DateTime.Now;
            score = 0;
            diedShips = 0;
            screen = new Screen(Width, Height);
            bullets = new List<Bullet>();
            enemyShips = new List<EnemyShip>();
            playerShip = new PlayerShip(this, PlayerShip.PLAYER, (screen.Width / 2) - (PlayerShip.PLAYER.Length / 2), screen.Height - 1, PLAYER_LIVES);
        }
        public Screen screen { get; private set; }
        public PlayerShip playerShip { get; private set; }
        public IList<Bullet> bullets { get; private set; }
        public IList<EnemyShip> enemyShips { get; private set; }
        public void Draw() 
        {
            screen.Draw();
            if (playerShip != null)
                playerShip.Draw();
        }
        private Random random;

        private DateTime lastSpawn;
        public bool GamePlaying
        {
            get { return playerShip != null || enemyShips.Count > 0; }
        }
        public const String ENEMY = "\\v/";
        private void SpawnEnemyShip()
        {
            int value = random.Next(1, screen.Width - 2);
            var enemyShip = new EnemyShip(this, ENEMY, value, 1, ENEMY_LIVES);
            enemyShip.Draw();
            enemyShips.Add(enemyShip);
            lastSpawn = DateTime.Now;
        }
        public void Update()
        {
            if (playerShip != null && (DateTime.Now - lastSpawn).TotalMilliseconds >= 3000)
            {
                SpawnEnemyShip();
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].NewStep();
                bullets[i].Move();
                if (bullets[i].InScreen())
                {
                    bool hit = false;
                    for (int j = 0; j <enemyShips.Count; j++)
                    {
                        if (enemyShips[j].Hit(bullets[i].X, bullets[i].Y) ||
                            enemyShips[j].Hit(bullets[i].LastX, bullets[i].LastY))
                        {
                            hit = true;
                            bullets.RemoveAt(i--);
                            score++;
                            if (enemyShips[j].Alive())
                            {
                                diedShips++;
                                enemyShips[j].Clear();
                                enemyShips.RemoveAt(j--);
                            }
                            break;
                        }
                    }
                    if (!hit)
                    {
                        bullets[i].Redraw();
                    }
                }
                else
                {
                    bullets.RemoveAt(i--);
                }
            }
            for (int i = 0; i < enemyShips.Count; i++)
            {
                enemyShips[i].NewStep();
                enemyShips[i].Move();
                if (enemyShips[i].InScreen())
                {
                    if (playerShip != null)
                    {
                        bool hit = false;

                        int y = enemyShips[i].Y;
                        foreach (int x in enemyShips[i].GetXValues())
                        {
                            if (playerShip.Hit(x, y))
                            {
                                enemyShips[i].Clear();
                                enemyShips.RemoveAt(i--);
                                hit = true;
                                break;
                            }
                        }
                        if (hit)
                        {
                            playerShip.Clear();
                            playerShip = null;
                            break;
                        }
                        else
                            enemyShips[i].Redraw();
                    }
                    enemyShips[i].Redraw();
                }
                else
                {
                    enemyShips[i].Clear();
                    enemyShips.RemoveAt(i--);
                }
            }
            if (playerShip != null)
            {
                playerShip.Move();
                playerShip.Redraw();
            }
        }
    }
}
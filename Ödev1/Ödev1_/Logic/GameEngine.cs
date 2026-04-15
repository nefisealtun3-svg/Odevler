using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ödev1_.Models;

namespace Ödev1_.Logic
{
    public class GameEngine
    {
        public int CurrentLevel { get; private set; } = 1;
        public const int MaxLevel = 50;
        public Player Player { get; private set; }
        public List<GameObject> GameObjects { get; private set; }

        private Random rnd = new Random();
        private bool isProcessingLevelEnd = false;

        private int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        public GameEngine()
        {
            Player = new Player { X = 50, Y = 50 };
            LoadLevel();
        }

        public void LoadLevel()
        {
            GameObjects = new List<GameObject>();
            Player.X = 50;
            Player.Y = 50;
            isProcessingLevelEnd = false;

            int treasureCount = 3 + (CurrentLevel / 2);
            int enemyCount = 2 + (int)(CurrentLevel * 1.2);

            for (int i = 0; i < treasureCount; i++)
            {
                GameObjects.Add(new Treasure
                {
                    X = rnd.Next(100, screenWidth - 100),
                    Y = rnd.Next(100, screenHeight - 100)
                });
            }

            for (int i = 0; i < enemyCount; i++)
            {
                GameObjects.Add(new Enemy
                {
                    X = rnd.Next(100, screenWidth - 100),
                    Y = rnd.Next(100, screenHeight - 100),
                    IsMoving = rnd.Next(0, 2) == 1
                });
            }
        }

        public void UpdateGame()
        {
            if (isProcessingLevelEnd) return;

            foreach (var obj in GameObjects)
            {
                if (obj is Enemy enemy) enemy.Move(screenWidth);
            }
            CheckCollisions();
        }

        public void UpdatePlayer(int dx, int dy)
        {
            if (isProcessingLevelEnd) return;
            int newX = Player.X + dx;
            int newY = Player.Y + dy;

            if (newX >= 0 && newX <= screenWidth - 40) Player.X = newX;
            if (newY >= 0 && newY <= screenHeight - 40) Player.Y = newY;
            CheckCollisions();
        }

        private void CheckCollisions()
        {
            if (isProcessingLevelEnd) return;
            Rectangle playerRect = new Rectangle(Player.X, Player.Y, 35, 35);

            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                var obj = GameObjects[i];
                Rectangle objRect = new Rectangle(obj.X, obj.Y, 30, 30);

                if (playerRect.IntersectsWith(objRect))
                {
                    if (obj is Treasure) { Player.AddScore(10); GameObjects.RemoveAt(i); }
                    else if (obj is Enemy) { HandleGameOver(); return; }
                }
            }

            if (!GameObjects.Any(o => o is Treasure)) HandleLevelEnd();
        }

        private void HandleLevelEnd()
        {
            isProcessingLevelEnd = true;
            InstallationGuard.SaveProgress(CurrentLevel + 1); // İlerlemeyi Kaydet

            string msg = CurrentLevel < MaxLevel ? $"{CurrentLevel}. Seviye Bitti! Devam?" : "OYUN BİTTİ!";
            DialogResult result = MessageBox.Show(msg, "Tebrikler", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes && CurrentLevel < MaxLevel) NextLevel();
            else CloseGameAndReturnMenu();
        }

        private void HandleGameOver()
        {
            isProcessingLevelEnd = true;
            DialogResult result = MessageBox.Show("Yandınız! Tekrar?", "Eyvah", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) LoadLevel();
            else CloseGameAndReturnMenu();
        }

        public void NextLevel() { if (CurrentLevel < MaxLevel) { CurrentLevel++; LoadLevel(); } }

        private void CloseGameAndReturnMenu() { Application.OpenForms["Form1"]?.Close(); }
    }
}
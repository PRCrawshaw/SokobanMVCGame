﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public interface iView
    {
        void DesignerNewLevel(int rows, int cols);
        void CreateLevelGridImage(int row, int col, Parts part);
        void CreateLevelGridButton(int row, int col, Parts part);
        void DesignerLoadLevel();
        void DisplayMain();
        void GameSetup(int moves);
        void SetMoves(int moves);
        void SetGamePosition(int row, int col, Parts part);
        void FinishGame(string bestPlayer, string bestScore, int thisScore);
        void ResetForm();
        void SetButtonHighlight();
        void SetNotification(string message);
        void ClearGameGrid();
    }
}

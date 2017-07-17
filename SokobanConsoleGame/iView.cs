using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public interface iView
    {
        bool PlayingGame { get; set; }
        void CreateLevelGridImage(int row, int col, Parts part);
        void CreateLevelGridButton(int row, int col, Parts part);
        void CreateSelectTypeButtons();
        void DesignerLoadLevel();
        void DisplayMain();
        void SetMoves(int moves);
        void FinishGame(string bestPlayer, string bestScore, int thisScore);
        void ResetForm();
        void SetButtonHighlight();
        void SetNotification(string message);
        void ClearGameGrid();
        void ToggleMoveCountVisibility(bool v);
        void ToogleNotificationVisiablity(bool v);
        void ToogleListBoxVisiablity(bool v);
        void SetIntialHighlightArea();
        void SetupItemList(string[] fileList);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public interface iView
    {
        //bool PlayingGame { get; set; }
        // game and design buttons and images
        //void CreateLevelGridImage(int row, int col, Parts part);
        void CreateLevelGridButton(int row, int col, Parts part);
        void SetIntialHighlightArea();
        void CreateSelectTypeButtons();
        //void SetButtonHighlight();
        // set text fields
        //void SetMoves(int moves);
        //void SetNotification(string message);
        void SetDefaultFileName(string v);
        // Visibility Toggles
        //void ToggleMoveCountVisibility(bool v);
        void ToggleChooseDesignerSizeVisibility(bool v);
        //void ToogleNotificationVisiablity(bool v);
        void ToogleGameButtonsVisiablity(bool v);
        //void ClearGameGrid(EventArgs e);
        void ClearDesignArea();
    }
}

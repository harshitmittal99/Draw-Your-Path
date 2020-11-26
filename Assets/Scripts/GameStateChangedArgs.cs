using System;

namespace Assets.Scripts
{
    internal class GameStateChangedArgs : EventArgs
    {
        #region Fields
        private GameStateManager.GameState _state = 0;
        #endregion


        #region Properties
        public GameStateManager.GameState State
        {
            get { return _state; }
        }
        #endregion


        #region Public methods
        public GameStateChangedArgs(GameStateManager.GameState state)
        {
            _state = state;
        }
        #endregion
    }
}

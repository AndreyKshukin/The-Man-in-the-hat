namespace ConsoleGame.Units.Players.StatePlayer
{
    public interface IPlayerState
    {
        void Jump();
        void Falls();
        void MoveLeft();
        void MoveRight();
        void Wait();
    }
}

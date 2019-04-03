namespace ConsoleGame.Units.Players.StatePlayer
{
    public class MoveLeftPlayerState : IPlayerState
    {
        private readonly Player _player;

        public MoveLeftPlayerState(Player player)
        {
            _player = player;
        }

        public void Jump()
        {
            _player.SetState(_player.JumpState);
            _player.Jump();
        }

        public void Falls()
        {
            _player.SetState(_player.FallsState);
            _player.AnimationService.JumpAnimation();
            _player.Falls();
        }

        public void MoveLeft()
        {
            _player.Direction = DirectionHorizontal.Left;
            _player.Run();
        }

        public void MoveRight()
        {
            _player.SetState(_player.MoveRightState);
            _player.AnimationService.RunRightAnimation();
            _player.AnimationPlayer.StartFrameAnimation(1);
            _player.MoveRight();
        }

        public void Wait()
        {
            _player.SetState(_player.WaitState);
            _player.Wait();
        }
    }
}

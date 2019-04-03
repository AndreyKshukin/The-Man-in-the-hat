namespace ConsoleGame.Units.Players.StatePlayer
{
    public class WaitPlayerState : IPlayerState
    {
        private readonly Player _player;

        public WaitPlayerState(Player player)
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
            _player.SetState(_player.MoveLeftState);
            _player.AnimationService.RunLeftAnimation();
            _player.AnimationPlayer.StartFrameAnimation(1);
            _player.MoveLeft();
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
            _player.Direction = DirectionHorizontal.Stop;
        }
    }
}

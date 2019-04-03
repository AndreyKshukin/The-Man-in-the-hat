namespace ConsoleGame.Units.Players.StatePlayer
{
    public class JumpPlayerState : IPlayerState
    {
        private readonly Player _player;

        public JumpPlayerState(Player player)
        {
            _player = player;
        }

        public void Jump()
        {
            _player.IsGrounded = false;
            _player.AnimationService.JumpAnimation();
            _player.Speed_y = _player.ForceJump;
            _player.Falls();
        }

        public void Falls()
        {
            _player.SetState(_player.FallsState);
            _player.Falls();
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void Wait()
        {
        }
    }
}

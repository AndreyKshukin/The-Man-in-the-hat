using log4net.Core;

namespace ConsoleGame.Units.Players.StatePlayer
{
    public class FallsPlayerState : IPlayerState
    {
        private readonly Player _player;

        public FallsPlayerState(Player player)
        {
            _player = player;
        }

        public void Jump()
        {
        }

        public void Falls()
        {
            if (_player.Speed_y > 0)
                MoveUp();
            else if (_player.Speed_y < 0)
                MoveDown();
            else
            {
                _player.Speed_y -= _player.Gravity;
            }
        }

        public void MoveLeft()
        {
        }

        public void MoveRight()
        {
        }

        public void Wait()
        {
            _player.SetState(_player.WaitState);
            _player.AnimationService.RunRightAnimation();
            _player.AnimationPlayer.StartFrameAnimation(0);
            _player.Wait();
        }

        private void MoveDown()
        {
            bool isWell = false;
            bool isGroundDown = false;
            float speedABS = 0;
            int playerSpeedX = PlayerSpeedX();
            int speed_x = 0;
            int speed_y = (int)_player.Speed_y;

            int dir = (_player.Direction == DirectionHorizontal.Right) ? 1 :
                (_player.Direction == DirectionHorizontal.Left) ? -1 : 0;

            for (int i = 1; i <= -speed_y; i++)
            {
                speedABS = -(float)i / (float)speed_y;
                speed_x = (!isWell) ? (int)(speedABS * playerSpeedX) : speed_x;

                isGroundDown = _player.Collider.CheckDown(_player.Position_x + speed_x * dir, _player.Position_y + i, _player);

                for (int j = 1; j <= speed_x; j++)
                {
                    bool checkWell = false;

                    if (dir > 0)
                        checkWell = _player.Collider.CheckRight(_player.Position_x + j, _player.Position_y + i, _player);
                    else
                        checkWell = _player.Collider.CheckLeft(_player.Position_x + j * dir, _player.Position_y + i, _player);

                    if (checkWell)
                    {
                        isWell = true;
                        _player.Direction = DirectionHorizontal.Stop;
                        speed_x = j - 1;
                        isGroundDown = _player.Collider.CheckDown(_player.Position_x + speed_x * dir, _player.Position_y + i, _player);
                    }
                }

                if (isGroundDown)
                {
                    speed_y = -i + 1;
                    _player.IsGrounded = true;
                }
            }

            _player.Position_x += speed_x * dir;
            _player.Position_y -= speed_y;

            if (_player.IsGrounded)
            {
                _player.Speed_y = 0;
                _player.Wait();
            }

            else
                _player.Speed_y -= _player.Gravity;
        }

        private void MoveUp()
        {
            bool isWell = false;
            bool isGroundUp = false;
            int playerSpeedX = PlayerSpeedX();
            float speedABS = 0;
            int speed_x = 0;
            int speed_y = (int)_player.Speed_y;

            int dir = (_player.Direction == DirectionHorizontal.Right) ? 1 :
                (_player.Direction == DirectionHorizontal.Left) ? -1 : 0;

            for (int i = 1; i <= speed_y; i++)
            {
                speedABS = (float) i / (float) speed_y;
                speed_x = (!isWell) ? (int) (speedABS * playerSpeedX) : speed_x;

                isGroundUp = _player.Collider.CheckUp(_player.Position_x + speed_x * dir, _player.Position_y - i, _player);

                if (!isGroundUp)
                { 
                    for (int j = 1; j <= speed_x; j++)
                    {
                        bool checkWell = false;

                        if (dir > 0)
                            checkWell = _player.Collider.CheckRight(_player.Position_x + j, _player.Position_y - i,
                                _player);
                        else
                            checkWell = _player.Collider.CheckLeft(_player.Position_x + j * dir, _player.Position_y - i,
                                _player);

                        if (checkWell)
                        {
                            isWell = true;
                            _player.Direction = DirectionHorizontal.Stop;
                            speed_x = j - 1;
                            isGroundUp = _player.Collider.CheckUp(_player.Position_x + speed_x * dir,
                                _player.Position_y - i, _player);
                        }
                    }
                }

            if (isGroundUp)
                    speed_y = i - 1;
            }

            _player.Position_x += speed_x * dir;
            _player.Position_y -= speed_y;

            if (isGroundUp)
                _player.Speed_y = 0;
            else
                _player.Speed_y -= _player.Gravity;
        }

        private int PlayerSpeedX()
        {
            int playerSpeedX = (int)_player.Speed_x;

            if (_player.Direction == DirectionHorizontal.Right)
            {
                bool check = false;
                while (!check)
                {
                    if ((_player.Position_x + playerSpeedX + _player.Size_x / 2) < Program.LevelMap.Size_x || playerSpeedX == 0)
                    {
                        check = true;
                    }
                    else
                    {
                        playerSpeedX -= 1;
                    }
                }
            }

            if (_player.Direction == DirectionHorizontal.Left)
            {
                bool check = false;
                while (!check)
                {
                    if ((_player.Position_x - playerSpeedX - _player.Size_x / 2) >= 0 || playerSpeedX == 0)
                    {
                        check = true;
                    }
                    else
                    {
                        playerSpeedX -= 1;
                    }
                }
            }
            return playerSpeedX;
        }
    }
}

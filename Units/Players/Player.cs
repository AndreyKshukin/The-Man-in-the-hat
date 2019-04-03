using System.Threading;
using ConsoleGame.Generic;
using ConsoleGame.Physics;
using ConsoleGame.Units.Players.Animation_Player;
using ConsoleGame.Units.Players.StatePlayer;

namespace ConsoleGame.Units.Players
{
    public class Player : Unit
    {
        private IPlayerState _iPlayerState;
        public JumpPlayerState JumpState { get; private set; }
        public FallsPlayerState FallsState { get; private set; }
        public MoveLeftPlayerState MoveLeftState { get; private set; }
        public MoveRightPlayerState MoveRightState { get; private set; }
        public WaitPlayerState WaitState { get; private set; }
        public DirectionHorizontal Direction { get; set; }

        public BoxCollider Collider;
        public Animation AnimationPlayer;
        public AnimationPlayerService AnimationService;

        public Thread Timer;
        private float _time = 0;
        public bool IsGrounded { get; set; }

        private float _memorySpeed = 2f;

        private float _speed_x;
        public float Speed_x { get => _speed_x; }
        public float Speed_y { get; set; }

        public readonly float Gravity = 0.5f;
        public readonly float ForceJump = 4f;

        public Player(int pos_x, int pos_y, int size_x, int size_y, BoxCollider boxCollider) : base(pos_x, pos_y, size_x, size_y)
        {
            Collider = boxCollider;
            AnimationService = new AnimationPlayerService(this);
            Speed_y = 0f;
            _speed_x = _memorySpeed;
            IsGrounded = false;
            Direction = DirectionHorizontal.Stop;
            JumpState = new JumpPlayerState(this);
            FallsState = new FallsPlayerState(this);
            MoveLeftState = new MoveLeftPlayerState(this);
            MoveRightState = new MoveRightPlayerState(this);
            WaitState = new WaitPlayerState(this);
            _iPlayerState = FallsState;
            Timer = new Thread(CheckTime);
            Timer.Name = "TimerWaitState";
            Timer.Start();
        }

        public void SetState(IPlayerState state)
        {
            _iPlayerState = state;
        }

        public void Run()
        {
            int dir = (Direction == DirectionHorizontal.Right) ? 1 : -1;
            bool checkWall = false;
            float speedABS;
            int plrSpeed = (int)Speed_x;
            for (int i = 1; i <= plrSpeed; i++)
            {
                speedABS = i / plrSpeed;
                if(dir > 0)
                    checkWall = Collider.CheckRight(Position_x + i * dir, Position_y + (int)(speedABS * Speed_y), this);
                else
                    checkWall = Collider.CheckLeft(Position_x + i * dir, Position_y + (int)(speedABS * Speed_y), this);
                if (checkWall)
                    plrSpeed = i - 1;
            }
            Position_x += plrSpeed * dir;
            CheckGround();
        }

        public void CheckGround()
        {
            IsGrounded = Collider.CheckDown(Position_x, Position_y + 1, this);
        }

        public void Falls()
        {           
            Thread.Sleep(25);
            _iPlayerState.Falls();
        }
        public void Jump()
        {
            _iPlayerState.Jump();
        }
        public void MoveLeft()
        {
            _iPlayerState.MoveLeft();
        }
        public void MoveRight()
        {
            _iPlayerState.MoveRight();
        }
        public void Wait()
        {
            _iPlayerState.Wait();
        }

        public void CoolDownStart()
        {
            _time = 0;
        }

        private void CheckTime()
        {
            _time = 0;
            while (true)
            {
                if (_time > 0.2f && _iPlayerState != WaitState && _iPlayerState != FallsState)
                    Wait();

                else
                {
                    Thread.Sleep(25);
                    _time += 0.025f;
                }
            }
        }
    }
}
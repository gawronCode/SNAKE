using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SNAKE
{
    public partial class SnakeApp : Form
    {

        private RandomNumberGenerator _rng = new RandomNumberGenerator();

        private int _colorIndex = 0;
        private readonly Color[] _snakeColor = { Color.Black, Color.Red, Color.Yellow, Color.Aqua, Color.BlueViolet, Color.DarkGreen, Color.LawnGreen, Color.Magenta };
        private int _snakeSpeed = 1;
        private Snake _snake = new Snake(Color.Black);
        private const int BaseSpeed = 200;

        private Food _food;
        private Food _superFood = null;

        private int _difficultyIndex = 0;
        private readonly int[] _difficultyGameTimerInterval = {200, 150, 100};
        private readonly String[] _difficultyName = {"EASY", "MEDIUM", "HARD"};

        private readonly System.Timers.Timer _animationTimer = new System.Timers.Timer();
        private readonly System.Timers.Timer _gameClockTimer = new System.Timers.Timer();

        private int _animationTimerInterval = 200;
        private const int ClockTimerInterval = 10;
        private int _clockToSeconds = 0;
        private int _speedUpClockValue = 30;
        private int _timeTillNextSuperFood;
        private int _superFoodTimeOfLife = 10;
        private int _gameOverAnimationCounter = 1;

        private int _score = 0;
        private int _bestScore = 0;



        private void SnakeApp_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null; //null == this (focus on Form)
            this.KeyPreview = true;
        }
        
        private void Exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            this.Close();
        }
        
        private void Color_Click(object sender, EventArgs e)
        {
            ChangeSkinColor();
        }

        public void ChangeSkinColor()
        {
            if (!this.color.Enabled) return;

            Graphics g = gameField.CreateGraphics();
            if (_colorIndex < _snakeColor.Length - 1) _colorIndex++;
            else _colorIndex = 0;
            _snake = new Snake(_snakeColor[_colorIndex]);
            _snake.Draw(g);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            if(!this.start.Enabled) return;

            _snake = new Snake(_snakeColor[_colorIndex]);
            SetStartClocks();
            _score = 0;
            this.start.Enabled = false;
            this.color.Enabled = false;
            this.difficulty.Enabled = false;
        }

        private void SetStartClocks()
        {
            _animationTimer.Interval = _animationTimerInterval;
            _animationTimer.Enabled = true;
            _animationTimer.AutoReset = true;
            _gameClockTimer.Enabled = true;
            this.gameOver.Visible = false;
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            PauseSwitch();
        }

        private void PauseSwitch()
        {
            if(this.start.Enabled) return;
            _animationTimer.Enabled = !_animationTimer.Enabled;
            _gameClockTimer.Enabled = !_gameClockTimer.Enabled;
        }

        private void Difficulty_Click(object sender, EventArgs e)
        {
            SetDifficulty();
        }

        private void SetDifficulty()
        {
            if (!this.difficulty.Enabled) return;

            if (_difficultyIndex < 2) _difficultyIndex++;
            else _difficultyIndex = 0;

            _animationTimerInterval = _difficultyGameTimerInterval[_difficultyIndex];
            _animationTimer.Interval = _animationTimerInterval;
            CalculateSnakeSpeed();
            this.gameDifficulty.Text = "DIFFICULTY: " + _difficultyName[_difficultyIndex];
            this.snakeSpeed.Text = "SNAKE SPEED: " + _snakeSpeed.ToString();
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = gameField.CreateGraphics();
            if (_animationTimer.Enabled) { _snake.Move(); }
            if (_snake.HeadEatFood(_food.PositionX, _food.PositionY)) ActionForFood(_food);
            if (!(_superFood is null)) if (_snake.HeadEatFood(_superFood.PositionX, _superFood.PositionY)) ActionForFood(_superFood);
            DrawElements(g);
            _snake.CheckForCollision();
            SetLabels();
            if (_snake.IsAlive) return;
            GameOverProtocol();
        }

        private void DrawElements(Graphics g)
        {
            _food.Draw(g);
            if (!(_superFood is null)) _superFood.Draw(g);
            _snake.Draw(g);
        }
        
        private void SetScore(int score)
        {
            _score += score;
            if (_score > _bestScore) _bestScore = _score;
        }

        private void GameOverProtocol()
        {
            _gameClockTimer.Enabled = false;
            _animationTimer.Interval = 150;

            if(_gameOverAnimationCounter%2==0) this.gameOver.Visible = !this.gameOver.Visible;
            _gameOverAnimationCounter++;
            
            if (_gameOverAnimationCounter != 30) return;
            _gameOverAnimationCounter = 1;
            _snake = new Snake(_snakeColor[_colorIndex]);
            _food = AddNewFood(10, Color.Yellow);
            _speedUpClockValue = 30;
            _score = 0;
            _clockToSeconds = 0;
            _animationTimer.AutoReset = false;
            ResetSuperFood();
            SetDifficulty();
            this.start.Enabled = true;
            this.start.Enabled = true;
            this.color.Enabled = true;
            this.difficulty.Enabled = true;
            //1123
        }
        
        private Food AddNewFood(int points, Color foodColor)
        {
            int positionX = _rng.GetRandomIntegerInRange(0, 19) * 40;
            int positionY = _rng.GetRandomIntegerInRange(0, 19) * 40;

            while (_snake.IsBodyOnThatField(positionX, positionY))
            {
                positionX = _rng.GetRandomIntegerInRange(0, 19) * 40;
                positionY = _rng.GetRandomIntegerInRange(0, 19) * 40;
            }
            
            return new Food(positionX, positionY, points, foodColor);
        }


        
        public SnakeApp()
        {
            SetTimeTillNextSuperFood();
            SetAnimationTimer();
            SetGameClockTimer();
            _food = AddNewFood(10, Color.Yellow);
            InitializeComponent();
        }

        private void SetAnimationTimer()
        {
            _animationTimer.Interval = _animationTimerInterval;
            _animationTimer.Elapsed += SimulationTick;
            _animationTimer.AutoReset = true;
            _animationTimer.Enabled = false;
        }

        private void SetGameClockTimer()
        {
            _gameClockTimer.Interval = ClockTimerInterval;
            _gameClockTimer.Elapsed += GameUpdate;
            _gameClockTimer.AutoReset = true;
            _gameClockTimer.Enabled = false;
        }
        
        private void GameUpdate(Object source, System.Timers.ElapsedEventArgs e)
        {
            _clockToSeconds += 10;
            if(_clockToSeconds!=1000) return;
            SuperFoodEvent();
            SpeedUpEvent();
            _clockToSeconds = 0;
        }

        private void SuperFoodEvent()
        {
            if (_superFood is null)
            {
                if (_timeTillNextSuperFood > 0) _timeTillNextSuperFood--;
                else _superFood = AddNewFood(100, Color.Red);
            }
            else
            {
                if (_superFoodTimeOfLife > 0) _superFoodTimeOfLife--;
                else
                {
                    ResetSuperFood();
                }
            }
        }

        private void ResetSuperFood()
        {
            _superFood = null;
            _superFoodTimeOfLife = 10;
            SetTimeTillNextSuperFood();
        }

        private void SpeedUpEvent()
        {
            if (_animationTimerInterval == 20) return;
            if (_speedUpClockValue > 0) _speedUpClockValue--;
            else
            {
                _speedUpClockValue = 30;
                _animationTimerInterval -= 10;
                CalculateSnakeSpeed();
            }
        }

        private void CalculateSnakeSpeed()
        {
            int currentSpeed = _animationTimerInterval;
            _snakeSpeed = ((BaseSpeed - currentSpeed) / 10) + 1;
        }

        private void SimulationTick(Object source, System.Timers.ElapsedEventArgs e)
        {
            gameField.Invalidate();
        }
        
        private void ActionForFood(Food food)
        {
            _snake.AddBodyPart();
            SetScore(food.Points);
            if (food == _food) _food = AddNewFood(10, Color.Yellow);
            if (food != _superFood) return;
            _superFood = null;
            SetTimeTillNextSuperFood();
        }

        private void SetTimeTillNextSuperFood()
        {
            _timeTillNextSuperFood = _rng.GetRandomIntegerInRange(10, 20);
            _superFoodTimeOfLife = 10;
        }

        private void SetLabels()
        {
            this.currentScore.Text = "SCORE: " + _score.ToString();
            this.snakeLenght.Text = "SNAKE LENGHT: " + _snake.Length().ToString();
            this.clock.Text = _speedUpClockValue.ToString() + "s";
            this.snakeSpeed.Text = "SNAKE SPEED: " + _snakeSpeed.ToString();
            this.bestScore.Text = "BEST SCORE: " + _bestScore.ToString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            CreateGameFieldBorders(e);
            base.OnPaint(e);
        }

        private void CreateGameFieldBorders(PaintEventArgs e)
        {
            if (gameField.BorderStyle != BorderStyle.FixedSingle) return;
            
            int thickness = 10;
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(Color.Black, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness + gameField.Location.X - 5,
                    halfThickness + gameField.Location.Y - 5,
                    gameField.ClientSize.Width - thickness + 12,
                    gameField.ClientSize.Height - thickness + 12));

            }
            
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) // snake control
        {
            switch (keyData)
            {
                case Keys.Right:
                    _snake.SetHeadDirection(0);
                    return true;
                case Keys.Up:
                    _snake.SetHeadDirection(1);
                    return true;
                case Keys.Left:
                    _snake.SetHeadDirection(2);
                    return true;
                case Keys.Down:
                    _snake.SetHeadDirection(3);
                    return true;
                case Keys.S:
                    Start();
                    return true;
                case Keys.C:
                    ChangeSkinColor();
                    return true;
                case Keys.D:
                    SetDifficulty();
                    return true;
                case Keys.P:
                    PauseSwitch();
                    return true;
                case Keys.Escape:
                    Exit();
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}

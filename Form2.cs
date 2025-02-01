using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_Runners
{
    public partial class FormJuego : Form
    {
        private const int CellSize = 16;
        private const int Rows = 21; 
        private const int Cols = 21; 
        private bool[,] maze;
        private Random random = new Random();

        private List<Point> flags; 
        private List<Point> traps; 
        private Dictionary<Point, int> trapTypes; // 1 pierde turno, 2 retroceso, 3 teletransp, 4 mov doblee)
        private int[] playerScores; 
        private Point[,] playerPositions; 
        private int[] activePiece; // ficha actica 
        private int currentPlayer;
        private bool extraMove; //indicar si mov doble 

        public FormJuego()
        {
            InitializeComponent();
            maze = new bool[Rows, Cols];
            flags = new List<Point>();
            traps = new List<Point>(); 
            trapTypes = new Dictionary<Point, int>(); 
            playerScores = new int[2] { 0, 0 }; 
            playerPositions = new Point[2, 5]; 
            activePiece = new int[2] { 0, 0 }; 
            currentPlayer = 0; 
            extraMove = false; //sin mov extra en el 1er turno
            UpdateTurnLabel(); 
        }

        private void btnGenerarLaberinto_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
                {
                    maze[x, y] = false;
                }
            }

            maze[1, 1] = true;
            GenerateMaze(1, 1);
            GenerateFlags(7);
            GenerateTraps(18); 
            InitializePlayerPositions();
            DrawMaze();
        }

        private void GenerateMaze(int x, int y)
        {
            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int j = random.Next(i, 4);
                (dx[i], dx[j]) = (dx[j], dx[i]);
                (dy[i], dy[j]) = (dy[j], dy[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i] * 2;
                int ny = y + dy[i] * 2;

                if (nx >= 0 && ny >= 0 && nx < Rows && ny < Cols && !maze[nx, ny])
                {
                    maze[nx, ny] = true;
                    maze[x + dx[i], y + dy[i]] = true;
                    GenerateMaze(nx, ny);
                }
            }
        }

        private void GenerateFlags(int count)
        {
            flags.Clear();

            while (flags.Count < count)
            {
                int x = random.Next(1, Rows - 1);
                int y = random.Next(1, Cols - 1);

                if (!flags.Contains(new Point(x, y)) && maze[x, y])
                {
                    flags.Add(new Point(x, y));
                }
            }
        }

        private void GenerateTraps(int countType)
        {
            traps.Clear();
            trapTypes.Clear();

            for (int type = 1; type <= 4; type++) //tipos de trampas del 1 al 4
            {
                int generatedCount = 0;

                while (generatedCount < countType)
                {
                    int x = random.Next(1, Rows - 1);
                    int y = random.Next(1, Cols - 1);
                    Point trapPosition = new Point(x, y);

                    if (!traps.Contains(trapPosition) && maze[x, y])
                    {
                        traps.Add(trapPosition);
                        trapTypes[trapPosition] = type;
                        generatedCount++;
                    }
                }
            }
        }

        private void InitializePlayerPositions()
        {
            HashSet<Point> occupiedPositions = new HashSet<Point>(flags); //solo celdas libres

            for (int playerIndex = 0; playerIndex < 2; playerIndex++)
            {
                for (int i = 0; i < 5; i++)
                {
                    Point position;

                    do
                    {
                        position = new Point(random.Next(1, Rows - 1), random.Next(1, Cols - 1));
                    } while (!maze[position.X, position.Y] || occupiedPositions.Contains(position));

                    playerPositions[playerIndex, i] = position;
                    occupiedPositions.Add(position);
                }
            }
        }

        private void DrawMaze()
        {
            Bitmap bitmap = new Bitmap(pictureBoxMaze.Width, pictureBoxMaze.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);

                for (int x = 0; x < Rows; x++) // maze
                {
                    for (int y = 0; y < Cols; y++)
                    {
                        if (!maze[x, y])
                        {
                            g.FillRectangle(Brushes.Black, x * CellSize, y * CellSize, CellSize, CellSize);
                        }
                    }
                }

                foreach (var flag in flags) // banderas
                {
                    g.FillRectangle(Brushes.Red, flag.X * CellSize, flag.Y * CellSize, CellSize, CellSize);
                }

                
                foreach (var trap in traps) // traps
                {
                    g.FillRectangle(Brushes.Gray,
                        trap.X * CellSize,
                        trap.Y * CellSize,
                        CellSize,
                        CellSize);
                }

                for (int playerIndex = 0; playerIndex < 2; playerIndex++)  // fichas
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Brush brush;
                        if (playerIndex == currentPlayer && i == activePiece[playerIndex])
                            brush = playerIndex == 0 ? Brushes.DarkBlue : Brushes.DarkGreen;
                        else
                            brush = playerIndex == 0 ? Brushes.Blue : Brushes.Green;

                        g.FillEllipse(brush,
                            playerPositions[playerIndex, i].X * CellSize,
                            playerPositions[playerIndex, i].Y * CellSize,
                            CellSize,
                            CellSize);
                    }
                }
            }

            pictureBoxMaze.Image = bitmap;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W: MovePlayer(currentPlayer, -1); break; 
                case Keys.S: MovePlayer(currentPlayer, +1); break; 
                case Keys.A: MovePlayer(currentPlayer, -2); break;
                case Keys.D: MovePlayer(currentPlayer, +2); break; 

                case Keys.Q:
                    ChangeActivePiece(0); break; // cambio jugador 1

                case Keys.E:
                    ChangeActivePiece(1); break; // cambio jugador 2

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        private void MovePlayer(int playerIndex, int direction)
        {
            Point currentPosition;

            if (playerIndex == currentPlayer)
            {
                currentPosition = playerPositions[playerIndex, activePiece[playerIndex]];

                switch (direction)
                {
                    case -1: currentPosition.Y--; break;
                    case +1: currentPosition.Y++; break;
                    case -2: currentPosition.X--; break;
                    case +2: currentPosition.X++; break;
                }

                if (IsValidMove(currentPosition))
                {
                    playerPositions[playerIndex, activePiece[playerIndex]] = currentPosition;

                    CheckFlagCollection(playerIndex);

                    if (traps.Contains(currentPosition))
                    {
                        HandleTrapEffect(currentPosition);
                    }

                    DrawMaze();

                    currentPlayer = (currentPlayer == 0) ? 1 : 0;
                    UpdateTurnLabel();
                }
            }
        }

        private void HandleTrapEffect(Point trapPosition)
        {
            int trapType = trapTypes[trapPosition];

            switch (trapType)
            {
                case 1:
                    MessageBox.Show("Caiste en la trampa!");
                    traps.Remove(trapPosition); 
                    break;
                case 2:
                    MessageBox.Show("Retrocedes a una posición anterior!");
                    MoveBackSpaces(currentPlayer);                   
                    traps.Remove(trapPosition); 
                    break;
                case 3:
                    MessageBox.Show("Te teletransportas a una nueva posición!");
                    TeleportToRandomPosition(activePiece[currentPlayer]);
                    traps.Remove(trapPosition); 
                    break;
                case 4:
                    MessageBox.Show("Puedes moverte dos veces en este turno!");
                    extraMove = true;
                    traps.Remove(trapPosition); 
                    break;
            }
        }

        private void TeleportToRandomPosition(int pieceIndex)
        {
            Point newPosition;

            do
            {
                newPosition = new Point(random.Next(1, Rows - 1), random.Next(1, Cols - 1));
            } while (!maze[newPosition.X, newPosition.Y]);

            playerPositions[currentPlayer, pieceIndex] = newPosition;
        }

        private void MoveBackSpaces(int playerIndex)
        {
            Point currentPosition = playerPositions[playerIndex, activePiece[playerIndex]];           
            for (int i = 0; i < 2; i++)
            {
                if (currentPosition.Y > 0 && maze[currentPosition.X, currentPosition.Y - 1])
                {
                    currentPosition.Y--; 
                }
                else if (currentPosition.X > 0 && maze[currentPosition.X - 1, currentPosition.Y])
                {
                    currentPosition.X--;
                }
                else if (currentPosition.Y < Cols - 1 && maze[currentPosition.X, currentPosition.Y + 1])
                {
                    currentPosition.Y++; 
                }
                else if (currentPosition.X < Rows - 1 && maze[currentPosition.X + 1, currentPosition.Y])
                {
                    currentPosition.X++; 
                }
            }           
            playerPositions[playerIndex, activePiece[playerIndex]] = currentPosition;
        }
        private void ChangeActivePiece(int playerIndex)
        {
            if (playerIndex == currentPlayer)
            {
                activePiece[playerIndex]++;
                if (activePiece[playerIndex] >= 5)
                    activePiece[playerIndex] = 0;

                UpdateScore();
                DrawMaze();
            }
        }

        private bool IsValidMove(Point position)
        {
            return position.X >= 0 && position.X < Rows &&
                   position.Y >= 0 && position.Y < Cols &&
                   maze[position.X, position.Y];
        }

        private void CheckFlagCollection(int playerIndex)
        {
            for (int i = flags.Count - 1; i >= 0; i--)
            {
                if (playerPositions[playerIndex, activePiece[playerIndex]].Equals(flags[i]))
                {
                    playerScores[playerIndex]++;
                    flags.RemoveAt(i);

                    if (playerScores[playerIndex] == 4) //condicion de victoria
                    {
                        MessageBox.Show($"¡Jugador {playerIndex + 1} ha ganado!");
                        Application.Exit();
                    }
                    break;
                }
            }

            UpdateScore();
            DrawMaze();
        }

        private void UpdateScore()
        {
            lblPlayer1Score.Text = $"Jugador 1: {playerScores[0]}";
            lblPlayer2Score.Text = $"Jugador 2: {playerScores[1]}";
        }

        private void UpdateTurnLabel()
        {
            lblTurn.Text = $"Turno del Jugador {(currentPlayer + 1)}"; //actualiza lbl
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMaze_Paint(object sender, PaintEventArgs e) { }

        
    }
}

using System.Net.Http.Headers;

namespace SnakeGameReaL
{
     class Program
    {
        int Hight = 10;
        int Widht = 30;

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random rnd = new Random();

        Program()
        {
            X[0] = 5;
            Y[1] = 5;
            Console.CursorVisible = false;
             fruitX = rnd.Next(2, (Widht - 2));
             fruitY = rnd.Next(2,(Hight - 2));
        }
        public void WriteBoard()
        {
            Console.Clear();
            for (int i = 1; i <= (Widht + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (Widht + 2); i++)
            {
                Console.SetCursorPosition(i, (Hight+2));
                Console.Write("-");
            }
            for (int i = 1; i <= (Hight + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (Hight + 1); i++)
            {
                Console.SetCursorPosition((Widht+2), i);
                Console.Write("|");
            }
 
        }
        public void Input()
        {
            if(Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }
        public void WritePoint(int x,int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("I");
        }
        public void Logic()
        {
            if (X[0] == fruitX)
            {
                if (Y[0] == fruitY)
                {
                    parts++;
                        fruitX = rnd.Next(2, (Widht - 2));
                        fruitY = rnd.Next(2,(Hight - 2));
                }
            }
            for (int i = parts; i > 1; i--)
            {
                X[i-1] = X[i-2];
                Y[i-1] = Y[i-2];
            }
            switch (key)
            {
                case 'w':
                    Y[0]--;
                        break;
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
                case 'a':
                    X[0]--;
                    break;
            }
            for (int i = 0; i <= (parts - 1); i++)
            {
                WritePoint(X[i], Y[i]);
                WritePoint(fruitX, fruitY);
            }
            Thread.Sleep(100);
        }
        static void Main(string[] args)
        {

        Program snake = new Program();
            while (true)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Logic();
            }
                Console.ReadKey();
            

        }
    }
}
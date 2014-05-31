using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using WPF3D;

namespace Spheres
{
    public class Game
    {
        private List<Object3D> actualObjects = new List<Object3D>();
        private List<Object3D> baseObject = new List<Object3D>();
        private Viewport3D viewport;
        private DispatcherTimer timer = new DispatcherTimer();
        private int createTime = 0;
        private int moveTime = 0;
        private int time = 0;
        public int GameScore { get; private set; }
        public delegate void Score(object sender, EventArgs e);
        public event Score RefreshScore;
        private Random rnd = new Random();

        Vector3D v = new Vector3D();

        protected virtual void RefreshScoreEventFunction()
        {
            
            Score handler = RefreshScore;
            if (RefreshScore != null) handler(this, null);
        }

        public Game(Viewport3D v)
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 15);
            viewport = v;
            baseObject.Add(new Object3D("earth.obj"));
            baseObject.Add(new Object3D("mars.obj"));
            baseObject.Add(new Object3D("asteroid.obj"));
            //baseObject.RotateRelative(180, 0, 0);
        }

        public void Reset()
        {
            actualObjects.Clear();
        }

        public void Start()
        {
            timer.Tick+=new EventHandler(TimerFunction);
            timer.Start();
        }

        private void TimerFunction(object sender, EventArgs e)
        {
            time+=15;
            if (time - createTime > 3000)
            {
                createTime = time;
                Create();
            }
            if (time - moveTime > 15)
            {
                moveTime = time;
                Move();
            }

        }

        private void Move()
        {
            v.X = 0;
            v.Z = 0;
            v.Y = -1;
            for (int i=0; i<actualObjects.Count; i++)
            {
                actualObjects[i].Move(v);
                float angle = (float)5;
                actualObjects[i].RotateRelative(0,angle,0);
            }
            if (actualObjects.Count!=0)
            if (actualObjects[0].Center.Y < -500)
            {
                actualObjects[0].Hide(viewport);
                actualObjects.RemoveAt(0);
            }
        }

        private void Create()
        {
            actualObjects.Add(new Object3D(baseObject[rnd.Next(0,baseObject.Count)]));
            
            v.X = rnd.Next(-450, 450);
            v.Z = -200;
            v.Y = 200;
            //actualObjects[actualObjects.Count - 1].SetColor(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
            actualObjects[actualObjects.Count - 1].Draw(viewport);
            actualObjects[actualObjects.Count - 1].RotateRelative(90,0,0);
            actualObjects[actualObjects.Count - 1].Move(v);
            actualObjects[actualObjects.Count - 1].MouseDownEvent += Click;
        }

        private void Click(object sender, EventArgs e)
        {
            GameScore += 10;
            (sender as Object3D).Hide(viewport);
            for (int i = 0; i < actualObjects.Count; i++)
            {
                if (sender == actualObjects[i])
                {
                    actualObjects.RemoveAt(i);
                    break;
                }
            }
            RefreshScoreEventFunction();
        }
    }
}

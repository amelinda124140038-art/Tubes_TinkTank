using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class TemplateBot : Bot
{
    private double enemyX, enemyY;
    private bool enemyDetected = false;
    private Random rnd = new Random();

    static void Main(string[] args)
    {
        new TemplateBot().Start();
    }

    TemplateBot() : base(BotInfo.FromFile("TemplateBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.FromArgb(0x11, 0x11, 0x11);
        TurretColor = Color.FromArgb(0xFF, 0x66, 0x00);
        RadarColor = Color.FromArgb(0xFF, 0x22, 0x22);
        BulletColor = Color.FromArgb(0xFF, 0x99, 0x00);
        GunColor = Color.FromArgb(0xCC, 0x33, 0x00);
        ScanColor = Color.FromArgb(0xFF, 0x44, 0x44);
        TracksColor = Color.FromArgb(0x33, 0x33, 0x33);

        while (IsRunning)
        {
            TurnRadarRight(360);

            if (Energy > 70)
            {
                MoveToEdge();
            }
            else if (Energy > 30)
            {
                ZigZag();
            }
            else
            {
                ChaosMove();
            }
        }
    }

    private void MoveToEdge()
    {
        TurnRight(30);
        Forward(50);
    }

    private void ZigZag()
    {
        Forward(80);
        TurnRight(45);

        Forward(80);
        TurnLeft(45);
    }

    private void ChaosMove()
    {
        int move = rnd.Next(2) == 0 ? 1 : -1;
        double turn = rnd.Next(30, 90);

        TurnRight(turn * move);
        Forward(rnd.Next(50, 150) * move);
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        enemyX = evt.X;
        enemyY = evt.Y;
        enemyDetected = true;

        double distance = DistanceTo(evt.X, evt.Y);

        double gunBearing = GunBearingTo(evt.X, evt.Y);
        TurnGunRight(gunBearing);

        if (Energy > 70)
        {
            if (distance < 150)
            {
                Fire(3);
                Forward(50);
            }
            else
            {
                Fire(1);
            }
        }
        else if (Energy > 30)
        {
            if (distance < 200)
            {
                Fire(2);
            }
            else
            {
                Fire(1);
            }
        }
        else
        {
            Fire(1);

            Back(100);
            TurnRight(90);
        }
    }


    public override void OnHitWall(HitWallEvent evt)
    {
        Back(50);
        TurnRight(90);
    }

    public override void OnHitBot(HitBotEvent evt)
    {
        if (Energy > 50)
        {
            Fire(3);
        }
        else
        {
            Back(100);
            TurnRight(90);
        }
    }
}

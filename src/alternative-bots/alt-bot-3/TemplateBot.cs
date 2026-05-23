using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class TemplateBot : Bot
{
    private double enemyX, enemyY;
    private double enemySpeed, enemyDirection;
    private bool enemyDetected = false;
    private Random rnd = new Random();
    private int flankSide = 1;

    static void Main(string[] args)
    {
        new TemplateBot().Start();
    }

    TemplateBot() : base(BotInfo.FromFile("TemplateBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.FromArgb(0x66, 0x33, 0xCC);
        TurretColor = Color.FromArgb(0x99, 0xCC, 0xFF);
        RadarColor = Color.FromArgb(0xFF, 0x66, 0xCC);
        BulletColor = Color.FromArgb(0xFF, 0x99, 0xDD);
        GunColor = Color.FromArgb(0xCC, 0x99, 0xFF);
        ScanColor = Color.FromArgb(0xFF, 0xCC, 0xEE);
        TracksColor = Color.FromArgb(0x33, 0x22, 0x55);

        while (IsRunning)
        {
            if (!enemyDetected)
            {
                TurnRadarRight(360);
            }
            else
            {
                if (Energy > 30)
                {
                    FlankMode();
                }
                else
                {
                    EscapeMode();
                }
            }
        }
    }

    private void FlankMode()
    {
        double distance = DistanceTo(enemyX, enemyY);
        double bearing = BearingTo(enemyX, enemyY);

        if (distance > 250)
        {
            ApproachFromSide(bearing);
        }
        else if (distance < 100)
        {
            TurnRight(flankSide * 90);
            Back(80);
        }
        else
        {
            OrbitEnemy(bearing);
        }
    }

    private void ApproachFromSide(double bearing)
    {
        TurnRight(bearing + (flankSide * 90));
        Forward(100);
        TurnRadarRight(45);
    }

    private void OrbitEnemy(double bearing)
    {
        TurnRight(bearing + (flankSide * 90));
        Forward(50);
        TurnRadarRight(45);
    }

    private void EscapeMode()
    {
        double bearing = BearingTo(enemyX, enemyY);

        TurnRight(bearing + 180);
        Forward(150);
        TurnRadarRight(90);
    }

    private void PredictiveShoot(double firePower)
    {
        double bulletSpeed = 20 - (3 * firePower);
        double distance = DistanceTo(enemyX, enemyY);
        double time = distance / bulletSpeed;

        double futureX = enemyX + Math.Sin(enemyDirection * Math.PI / 180) * enemySpeed * time;
        double futureY = enemyY + Math.Cos(enemyDirection * Math.PI / 180) * enemySpeed * time;

        double gunBearing = GunBearingTo(futureX, futureY);

        TurnGunRight(gunBearing);
        Fire(firePower);
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        enemyX = evt.X;
        enemyY = evt.Y;
        enemySpeed = evt.Speed;
        enemyDirection = evt.Direction;
        enemyDetected = true;

        double radarBearing = RadarBearingTo(evt.X, evt.Y);
        TurnRadarRight(radarBearing * 2);

        double distance = DistanceTo(evt.X, evt.Y);

        if (Energy > 50)
        {
            if (distance < 150)
            {
                PredictiveShoot(3);
            }
            else
            {
                PredictiveShoot(2);
            }
        }
        else if (Energy > 30)
        {
            PredictiveShoot(1);
        }
        else
        {
            PredictiveShoot(1);
        }

        if (rnd.Next(10) == 0)
        {
            flankSide *= -1;
        }
    }

    public override void OnHitWall(HitWallEvent evt)
    {
        Back(50);

        flankSide *= -1;

        TurnRight(rnd.Next(45, 90) * flankSide);
    }

    public override void OnHitBot(HitBotEvent evt)
    {
        if (Energy > 30)
        {
            TurnRight(flankSide * 90);
            Back(80);
            PredictiveShoot(2);
        }
        else
        {
            Back(100);
            TurnRight(rnd.Next(90, 180));
        }
    }

    public override void OnBotDeath(BotDeathEvent evt)
    {
        enemyDetected = false;
        flankSide *= -1;
    }

    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        flankSide *= -1;

        TurnRight(flankSide * 45);
        Forward(60);
    }
}

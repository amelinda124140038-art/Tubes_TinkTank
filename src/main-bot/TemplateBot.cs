using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class TemplateBot : Bot
{
    private double enemyX;
    private double enemyY;
    private double enemySpeed;
    private double enemyDirection;
    private double enemyEnergy = 100;

    private bool enemyDetected = false;

    private int totalEnemies = 30;
    private int deadEnemies = 0;

    private Random rnd = new Random();

    static void Main(string[] args)
    {
        new TemplateBot().Start();
    }

    TemplateBot() : base(BotInfo.FromFile("TemplateBot.json")) { }

    public override void Run()
    {
       BodyColor = Color.Black;
       TurretColor = Color.HotPink;
       RadarColor = Color.DeepSkyBlue;
       BulletColor = Color.Pink;
       GunColor = Color.MediumVioletRed;
       ScanColor = Color.LightSkyBlue;
       TracksColor = Color.DarkSlateGray;

        while (IsRunning)
        {
            TurnRadarRight(360);

            if (!enemyDetected)
            {
                MoveAround();
            }
            else
            {
                int aliveEnemies = totalEnemies - deadEnemies;

                if (aliveEnemies > 5)
                {
                    WaitingMode();
                }
                else if (aliveEnemies > 1)
                {
                    PositioningMode();
                }
                else
                {
                    HunterMode();
                }
            }
        }
    }

    private void MoveAround()
    {
        Forward(80);
        TurnRight(30);

        Forward(80);
        TurnLeft(30);
    }

    private void WaitingMode()
    {
        double distance = DistanceTo(enemyX, enemyY);
        double bearing = BearingTo(enemyX, enemyY);

        if (distance < 180)
        {
            TurnRight(bearing + 180);
            Forward(100);

            ShootByDistance(distance);
        }
        else
        {
            TurnRight(25);
            Forward(70);

            if (enemyEnergy < 35 || distance < 300)
            {
                ShootByDistance(distance);
            }
        }

        TurnRadarRight(60);
    }

    private void PositioningMode()
    {
        double distance = DistanceTo(enemyX, enemyY);
        double bearing = BearingTo(enemyX, enemyY);

        if (distance > 300)
        {
            TurnRight(bearing + 45);
            Forward(90);
        }
        else if (distance < 120)
        {
            Back(80);
            TurnRight(40);
        }
        else
        {
            TurnRight(bearing + 90);
            Forward(70);
        }

        ShootByDistance(distance);
        TurnRadarRight(45);
    }

    private void HunterMode()
    {
        double distance = DistanceTo(enemyX, enemyY);
        double bearing = BearingTo(enemyX, enemyY);

        TurnLeft(bearing);
        Forward(100);

        ShootByDistance(distance);
        TurnRadarRight(45);
    }

    private void ShootByDistance(double distance)
    {
        double firePower;

        if (enemyEnergy < 20)
        {
            firePower = 2;
        }
        else if (distance < 120)
        {
            firePower = 3;
        }
        else if (distance < 300)
        {
            firePower = 2;
        }
        else
        {
            firePower = 1;
        }

        PredictiveShoot(firePower);
    }

    private void PredictiveShoot(double firePower)
    {
        if (Energy <= firePower)
        {
            return;
        }

        double distance = DistanceTo(enemyX, enemyY);
        double bulletSpeed = 20 - (3 * firePower);
        double time = distance / bulletSpeed;

        double futureX = enemyX + Math.Sin(enemyDirection * Math.PI / 180) * enemySpeed * time;
        double futureY = enemyY + Math.Cos(enemyDirection * Math.PI / 180) * enemySpeed * time;

        double gunBearing = GunBearingTo(futureX, futureY);
        TurnGunRight(gunBearing);

        if (Math.Abs(gunBearing) < 15)
        {
            Fire(firePower);
        }
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        enemyDetected = true;

        enemyX = evt.X;
        enemyY = evt.Y;
        enemySpeed = evt.Speed;
        enemyDirection = evt.Direction;
        enemyEnergy = evt.Energy;

        double radarBearing = RadarBearingTo(enemyX, enemyY);
        TurnRadarRight(radarBearing * 2);
    }

    public override void OnHitWall(HitWallEvent evt)
    {
        Back(70);
        TurnRight(90);
    }

    public override void OnHitBot(HitBotEvent evt)
    {
        if (Energy > 30)
        {
            Fire(2);
        }

        Back(80);
        TurnRight(70);
    }

    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        TurnRight(rnd.Next(45, 100));
        Forward(100);
    }

    public override void OnBotDeath(BotDeathEvent evt)
    {
        deadEnemies++;
        enemyDetected = false;
    }
}

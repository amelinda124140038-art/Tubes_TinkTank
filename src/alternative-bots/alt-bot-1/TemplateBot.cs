using System;
using System.Drawing;
using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;

public class TemplateBot : Bot
{
    private double enemyX;
    private double enemyY;
    private double enemyDistance;
    private double enemyEnergy = 100;
    private bool enemyDetected = false;

    private Random rnd = new Random();

    static void Main(string[] args)
    {
        new TemplateBot().Start();
    }

    TemplateBot() : base(BotInfo.FromFile("TemplateBot.json")) { }

    public override void Run()
    {
        BodyColor = Color.FromArgb(0x33, 0x33, 0xCC);
        TurretColor = Color.FromArgb(0x99, 0x33, 0xFF);
        RadarColor = Color.FromArgb(0xFF, 0xFF, 0x66);
        BulletColor = Color.FromArgb(0xFF, 0xCC, 0x00);
        GunColor = Color.FromArgb(0x66, 0x00, 0xCC);
        ScanColor = Color.FromArgb(0xCC, 0xCC, 0xFF);
        TracksColor = Color.FromArgb(0x22, 0x22, 0x44);

        MoveToCorner();

        while (IsRunning)
        {
            if (enemyDetected)
            {
                AttackMode();
            }
            else
            {
                SurvivalMode();
            }

            TurnRadarRight(360);
        }
    }

    private void MoveToCorner()
    {
        double targetX = 60;
        double targetY = 60;

        double bearing = BearingTo(targetX, targetY);
        double distance = DistanceTo(targetX, targetY);

        TurnRight(bearing);
        Forward(distance);
    }

    private void SurvivalMode()
    {
        Forward(80);
        TurnRight(30);

        Forward(80);
        TurnLeft(30);
    }

    private void AttackMode()
    {
        double radarBearing = RadarBearingTo(enemyX, enemyY);
        TurnRadarRight(radarBearing * 2);

        double gunBearing = GunBearingTo(enemyX, enemyY);
        TurnGunRight(gunBearing);

        double firePower = CalculateFirePower();

        if (enemyDistance < 250 || enemyEnergy < 30)
        {
            Fire(firePower);
        }

        Forward(60);
        TurnRight(25);
    }

    private double CalculateFirePower()
    {
        if (enemyEnergy < 20)
        {
            return 3;
        }
        else if (enemyDistance < 100)
        {
            return 3;
        }
        else if (enemyDistance < 250)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        enemyDetected = true;

        enemyX = evt.X;
        enemyY = evt.Y;
        enemyDistance = DistanceTo(enemyX, enemyY);
        enemyEnergy = evt.Energy;
    }

    public override void OnHitWall(HitWallEvent evt)
    {
        Back(60);
        TurnRight(90);
    }

    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        TurnRight(rnd.Next(45, 100));
        Forward(100);
    }

    public override void OnHitBot(HitBotEvent evt)
    {
        Fire(3);
        Back(50);
        TurnRight(90);
    }

    public override void OnBotDeath(BotDeathEvent evt)
    {
        enemyDetected = false;
    }
}

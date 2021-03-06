﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

partial class Level : GameObjectList
{
    /// <summary>Handle the inputof the level objects.</summary>
    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (quitButton.Pressed)
        {
            Reset();
            GameEnvironment.GameStateManager.SwitchTo("levelMenu");
        }      
    }

    /// <summary>Update the level objects.</summary>
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        TimerGameObject timer = Find("timer") as TimerGameObject;
        Player player = Find("player") as Player;

        // check if we died
        if (!player.IsAlive)
            timer.Running = false;

        // check if we ran out of time
        if (timer.GameOver)
            player.Explode();
                       
        // check if we won
        if (Completed && timer.Running)
        {
            player.LevelFinished();
            timer.Running = false;
        }

        foreach (Projectile projectile in projectiles)
            projectile.Update(gameTime, Find("tiles") as TileField);

        // clear unactive projectiles (no memory dump)
        projectiles.RemoveAll(unActiveProjectile);

    }

    /// <summary>Draw the level objects.</summary>
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);

        foreach (Projectile projectile in projectiles)
            projectile.Draw(gameTime, spriteBatch);
    }

    /// <summary>Reset the level objects.</summary>
    public override void Reset()
    {
        base.Reset();
        VisibilityTimer hintTimer = Find("hintTimer") as VisibilityTimer;
        hintTimer.StartVisible();
    }

    /// <summary>Get the number of active projectiles.</summary>
    public int ActiveProjectiles
    {
        get
        {
            int num = 0;
            foreach (Projectile projectile in projectiles)
                if (projectile.Active)
                    num++;
            return num;
        }
    }

    /// <summary>Match finder for unactive projectiles.</summary>
    private bool unActiveProjectile(Projectile obj)
    { return !obj.Active; }
}

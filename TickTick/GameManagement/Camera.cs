﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameManagement
{



    class Camera
    {
        Vector2 position;
        Rectangle cameraOutline, movingRectangle;
        bool moveVertical;
        int moveableWidth = 200, moveableHeight = 200;
        
        public Camera(int screenWidth, int screenHeight, Vector2 startingPosition, bool moveVertical = false)
        {
            this.moveVertical = moveVertical;
            position = startingPosition;
            cameraOutline = new Rectangle((int)position.X, (int)position.Y, screenWidth, screenHeight);
            movingRectangle = new Rectangle((cameraOutline.Width/2 - moveableWidth/2), (cameraOutline.Height/2 - moveableHeight/2) , moveableWidth , moveableHeight );
        }

        public Camera(int screenWidth, int screenHeight, Vector2 startingPosition, int moveableHeight, int moveableWidth, bool moveVertical = false)
        {
            this.moveVertical = moveVertical;
            position = startingPosition;
            this.moveableWidth = moveableWidth;
            this.moveableHeight = moveableHeight;
            cameraOutline = new Rectangle((int)position.X, (int)position.Y, screenWidth, screenHeight);
            movingRectangle = new Rectangle((cameraOutline.Width / 2 - this.moveableWidth / 2), (cameraOutline.Height / 2 - this.moveableHeight / 2), this.moveableWidth, this.moveableHeight);
        }
            
    }
}

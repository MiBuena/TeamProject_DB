﻿namespace LostRPG.Client.Controllers
{
    using System;
    using LostRPG.Client.Interfaces;
    using Microsoft.Xna.Framework.Input;

    public class ControllerUserInput : IUserInputInterface
    {
        private MouseState previousMouseState;

        public ControllerUserInput()
        {
            this.previousMouseState = Mouse.GetState();
        }

        public event EventHandler OnRightPressed;

        public event EventHandler OnLeftPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;

        public event EventHandler OnNumericKeyPressed;

        public event EventHandler OnLeftMouseClick;

        public void CheckForInput()
        {
            var mouseState = Mouse.GetState();
            ////if (mouseState.LeftButton == ButtonState.Pressed)
            if (mouseState.LeftButton == ButtonState.Pressed &&
                this.previousMouseState.LeftButton != ButtonState.Pressed)
            {
                this.OnLeftMouseClick?.Invoke(this, new AbilityEventArgs(mouseState.X, mouseState.Y));
            }

            this.previousMouseState = mouseState;
            this.CheckKeyboardInput();
        }

        private void CheckKeyboardInput()
        {
            var keyboardState = Keyboard.GetState();
            var keysPressed = keyboardState.GetPressedKeys();
            foreach (var pressedKey in keysPressed)
            {
                if ((int) pressedKey >= 49 && (int) pressedKey <= 57) // 1-9
                {
                    this.OnNumericKeyPressed?.Invoke(this, new NumericKeyEventArgs(((int) pressedKey - 48).ToString()));
                    continue;
                }

                switch (pressedKey)
                {
                    case Keys.W:
                        this.OnUpPressed?.Invoke(this, new EventArgs());
                        break;
                    case Keys.S:
                        this.OnDownPressed?.Invoke(this, new EventArgs());
                        break;
                    case Keys.D:
                        this.OnRightPressed?.Invoke(this, new EventArgs());
                        break;
                    case Keys.A:
                        this.OnLeftPressed?.Invoke(this, new EventArgs());
                        break;
                }
            }
        }
    }
}
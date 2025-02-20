﻿namespace SadConsole.Configuration
{
    internal static class MonoGameDebuggerExtensions
    {
        public static Input.Keys Key { get; set; }

        public static Builder KeyhookMonoGameDebugger(this Builder builder, Input.Keys key)
        {
            Key = key;
            builder.GetOrCreateConfig<MonoGameDebugger>();
            return builder;
        }

        internal static void Game_FrameUpdate(object? sender, GameHost e)
        {
            if (e.Keyboard.IsKeyPressed(Key))
            {
            }
        }
    }

    internal class MonoGameDebugger : IConfigurator
    {
        public void Run(Builder config, GameHost game) =>
            game.FrameUpdate += MonoGameDebuggerExtensions.Game_FrameUpdate;
    }
}

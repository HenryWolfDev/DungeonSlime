using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace DungeonSlime;

public class Game1 : Core
{
    private Texture2D _logo;

    public Game1()
        : base("Dungeon Slime", 1280, 720, false) { }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _logo = Content.Load<Texture2D>("images/logo");
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // prepare sprite batch for rendering
        SpriteBatch.Begin();
        // Draw the logo texture to the center
        SpriteBatch.Draw(
            _logo,
            new Vector2(Window.ClientBounds.Width, Window.ClientBounds.Height) * 0.5f,
            null,
            Color.White * 0.5f,
            0.0f,
            new Vector2(_logo.Width, _logo.Height) * 0.5f,
            1f,
            SpriteEffects.None,
            0.0f
        );
        // Draw the logo at 0.0
        SpriteBatch.Draw(_logo, Vector2.Zero, Color.White);
        // Draw the logo left bottom
        SpriteBatch.Draw(
            _logo,
            new Vector2(0, Window.ClientBounds.Height - _logo.Height),
            Color.White
        );
        // Draw the logo right bottom
        SpriteBatch.Draw(
            _logo,
            new Vector2(
                Window.ClientBounds.Width - _logo.Width,
                Window.ClientBounds.Height - _logo.Height
            ),
            Color.White
        );
        // Draw the logo right top
        SpriteBatch.Draw(
            _logo,
            new Vector2(Window.ClientBounds.Width - _logo.Width, 0),
            Color.White
        );
        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}

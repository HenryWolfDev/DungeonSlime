using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace DungeonSlime;

public class Game1 : Core
{
    // texture region that defines the slime sprite in the atlas.
    private TextureRegion _slime;

    // texture region that defines the bat sprite in the atlas.
    private TextureRegion _bat;

    public Game1()
        : base("Dungeon Slime", 1280, 720, false) { }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load the atlas texture using content manager
        Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

        // Create a TextureAtlas instance from the atlas.
        TextureAtlas atlas = new TextureAtlas(atlasTexture);

        // add the slime region to the atlas.
        atlas.AddRegion("slime", 0, 0, 20, 20);

        // add the bat region to the atlas.
        atlas.AddRegion("bat", 20, 0, 20, 20);

        // retrive the slime region from the atlas.
        _slime = atlas.GetRegion("slime");

        // retrive the bat region from the atlas.
        _bat = atlas.GetRegion("bat");
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

        // 1. startet das Sammeln (prepare for rendering).
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _slime.Draw(
            SpriteBatch,
            Vector2.Zero,
            Color.White,
            0.0f,
            Vector2.One,
            4.0f,
            SpriteEffects.None,
            0.0f
        );

        // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
        _bat.Draw(
            SpriteBatch,
            new Vector2(_slime.Width * 4.0f + 10, 0),
            Color.White,
            0.0f,
            Vector2.One,
            4.0f,
            SpriteEffects.None,
            1.0f
        );

        // 2. Diese Bilder werden im Speicher gesammelt, noch nicht gezeichnet.

        // 3. Jetzt wird alles zusammen an die GPU geschickt und auf dem Bildschirm gezeichnet.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}

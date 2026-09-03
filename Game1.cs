using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace DungeonSlime;

public class Game1 : Core
{
    // texture region that defines the slime sprite in the atlas.
    private Sprite _slime;

    // texture region that defines the bat sprite in the atlas.
    private Sprite _bat;

    public Game1()
        : base("Dungeon Slime", 1280, 720, false) { }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load the atlas texture using content manager
        TextureAtlas atlas = TextureAtlas.FromFile(
            Content,
            "images/atlas-definition/atlas-definition.xml"
        );

        // retrive the slime region from the atlas.
        _slime = atlas.CreateSprite("slime");
        _slime.Scale = new Vector2(4.0f, 4.0f);

        // retrive the bat region from the atlas.
        _bat = atlas.CreateSprite("bat");
        _bat.Scale = new Vector2(4.0f, 4.0f);
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

        // 2. Diese Bilder werden im Speicher gesammelt, noch nicht gezeichnet.

        _slime.Draw(SpriteBatch, Vector2.Zero);

        _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

        // 3. Jetzt wird alles zusammen an die GPU geschickt und auf dem Bildschirm gezeichnet.

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}

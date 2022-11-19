using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UltraLight.Libs;

namespace UltraLight
{
    public class Game1 : Game
    {
        public SpriteBatch spriteBatch;

        public static GraphicsDeviceManager graphics;
        public static ContentManager myContent;

        public static ProjectilePool projectilePool;

        public bool isFullscreen;

        private StateStack stateStack;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Resolution.Init(ref graphics);

            ControlFullScreenMode(isFullscreen);

            myContent = Content;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Settings.defaultFont = Content.Load<SpriteFont>("pico-8-mono");
            stateStack = new StateStack();
            stateStack.Push(new TitleState(stateStack));
            projectilePool = new ProjectilePool();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Press/Hold F4 to toggle borderless window.
            if (Keyboard.GetState().IsKeyDown(Keys.F4))
            {
                isFullscreen = !isFullscreen;
                ControlFullScreenMode(isFullscreen);
            }

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            stateStack.Update(dt);
            projectilePool.Update(dt);
            Input.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Resolution.BeginDraw();

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Resolution.getTransformationMatrix());

            stateStack.Draw(spriteBatch);
            projectilePool.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ControlFullScreenMode(bool becomeFullscreen)
        {
            if (!becomeFullscreen)
            {
                Resolution.SetVirtualResolution(Settings.screenWidth, Settings.screenHeight);
                Resolution.SetResolution(Settings.screenWidth * Settings.screenScale, Settings.screenHeight * Settings.screenScale, false);
            }
            else
            {
                Resolution.SetVirtualResolution(Settings.screenWidth, Settings.screenHeight);
                Resolution.SetResolution(GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.Adapter.CurrentDisplayMode.Height, true);
            }
        }
    }
}
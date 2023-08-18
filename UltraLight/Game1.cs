using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using UltraLight.Globals;
using UltraLight.Libs;
using UltraLight.Scenes;
using UltraLight.Sounds;
using UltraLight.UI;

namespace UltraLight
{
    public class Game1 : Game
    {
        public static SpriteBatch spriteBatch;

        public static GraphicsDeviceManager graphics;
        public static ContentManager myContent;

        public bool isFullscreen;

        private StateStack stateStack;
        private static bool spriteBatchActive = false;
        public static Effect colorOverlay;
        private bool drawFPS = false;
        public static Sound sound;

        public FPS fps = new FPS();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
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
            Settings.defaultFont = Content.Load<SpriteFont>("Fonts/pico-8-mono");
            stateStack = new StateStack();
            stateStack.Push(new TitleScene(stateStack));
            colorOverlay = Content.Load<Effect>("Shaders/colorOverlay");
            sound = new Sound(new List<SoundFX>
            {
                new SoundFX {
                    Key = "hit", Filename = "Sound/SE/hit", DefaultPitch = 1f, DefaultVolume = 1f
                },
                new SoundFX {
                    Key = "hurt", Filename = "Sound/SE/hurt", DefaultPitch = 1f, DefaultVolume = 1f
                }
            });
        }

        protected override void Update(GameTime gameTime)
        {
            if (Input.JustPressed(Keys.Escape))
                Exit();

            if (Input.JustPressed(Keys.F4))
            {
                isFullscreen = !isFullscreen;
                ControlFullScreenMode(isFullscreen);
            }

            if (Input.JustPressed(Keys.F1))
            {
                drawFPS = !drawFPS;
            }

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Input.GetState();
            stateStack.Update(dt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Resolution.BeginDraw();

            GraphicsDevice.Clear(Color.Black);

            RestartSpriteBatch();

            stateStack.Draw(spriteBatch);

            if (drawFPS)
            {
                fps.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                fps.Draw(spriteBatch);
            }

            EndSpriteBatch();

            base.Draw(gameTime);
        }

        public static void RestartSpriteBatch(Effect effect = null)
        {
            if (spriteBatchActive)
                EndSpriteBatch();

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, effect, Resolution.getTransformationMatrix());
            spriteBatchActive = true;
        }

        public static void EndSpriteBatch()
        {
            spriteBatch.End();
            spriteBatchActive = false;
        }

        public static void ColorOverlay(Color color)
        {
            colorOverlay.Parameters["overlayColor"].SetValue(color.ToVector4());
            RestartSpriteBatch(colorOverlay);
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
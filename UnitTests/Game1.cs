﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using SpaceIsFun;
using TestingMono.Api;
using TestingMono.Framework;
#endregion

namespace UnitTests
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TestsUi _testsUI;
        Texture2D testGridTexture;
        Texture2D testGridTextureHighlight;
        Texture2D testGridTextureNotWalkable;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _testsUI = new TestsUi((Game)this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFont font = Content.Load<SpriteFont>("Calibri");

            _testsUI.SetFont(font);
            _testsUI.RunTests(this.GetType().Assembly);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _testsUI.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _testsUI.Draw(gameTime);
            base.Draw(gameTime);
        }
    }

    public class TestGrid : TestFixture
    {
        public override void Context()
        {
        //throw new NotImplementedException();
        }
                 

        [TestMethod]
        public void TestConstruction()
        {
            
            Texture2D gridTexture = base.game.Content.Load<Texture2D>("Grid");
            Texture2D gridTextureHighlight = base.game.Content.Load<Texture2D>("GridHighlight");
            Texture2D gridTextureNotWalkable = base.game.Content.Load<Texture2D>("GridNotWalkable");

            Vector2 position = new Vector2(1.0f, 1.0f);
            Vector2 gPosition = new Vector2(1.0f, 1.0f);

            Grid testGrid = new Grid(gridTexture, gridTextureHighlight, position, gPosition);

            Assert.AreEqual<Vector2>(position, testGrid.Sprite.Position2D, "positions are equal");
            Assert.IsFalse(true, "should fail");
            
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class ParticleEmitter
    {
        float density;
        float timeSinceLastSpawn;
        float spawnInterval;
        float angle;
        float particleAge = 1;
        float particleVelocity = 50;

        bool shouldEmit;
        public bool ShouldEmit { get => shouldEmit; set => shouldEmit = value; }
        public float ParticleAge { get => particleAge; set => particleAge = value; }
        public float ParticleVelocity { get => particleVelocity; set => particleVelocity = value; }

        List<Particle> particleList = new List<Particle>();

        Vector2 direction;
        Vector2 position;
        Random random = new Random();

        emitterType currentEmitterType;
        public enum emitterType
        {
            Pulse,
            Stream,
            OnCall
        }

        public Vector2 Position { get => position; set => position = value; }

        public ParticleEmitter(emitterType currentEmitterType)
        {
            density = 200;
            position = new Vector2(200,200);
            this.currentEmitterType = currentEmitterType;

            if (currentEmitterType == emitterType.Pulse)
            {
                spawnInterval = 1f;
            }
            else if (currentEmitterType == emitterType.Stream)
            {
                spawnInterval = 1f / density;
            }
        }

        public void Update(GameTime gameTime)
        {

            //removes particles older than particle.LifeTime
            for (int i = 0; i < particleList.Count; i++)
            {
                particleList[i].Update(gameTime);

                particleList[i].Age += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (particleList[i].Age >= particleList[i].LifeTime)
                {
                    particleList.RemoveAt(i);
                }
            }


            timeSinceLastSpawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            switch (currentEmitterType)
            {
                case emitterType.Pulse:
                    if (timeSinceLastSpawn >= spawnInterval)
                    {
                        timeSinceLastSpawn = 0f;
                        for (int i = 0; i < density; i++)
                        {
                            GetDirection();
                            particleList.Add(new Particle(position, direction, particleAge, particleVelocity));
                        }
                    }
                    break;

                case emitterType.Stream:
                    if (timeSinceLastSpawn >= spawnInterval)
                    {
                        timeSinceLastSpawn = 0;
                        GetDirection();
                        particleList.Add(new Particle(position, direction, particleAge, particleVelocity));
                    }
                    break;

                case emitterType.OnCall:
                    if (shouldEmit)
                    {
                        AddParticles();
                    }
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var particle in particleList)
            {
                particle.Draw(spriteBatch);
            }
        }

        private void GetDirection()
        {
            angle = (float)random.NextDouble() * MathHelper.TwoPi; // generates an angle between 0 and 2*Pi (360 degrees)
            direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)); // creates a vector with the x and y components equal to the cos and sin of the angle
            direction.Normalize(); // normalizes vector to have a magnitude of 1
        }

        //might not work as intended, copilot autocomplete
        private void AddParticles()
        {
            for (int i = 0; i < density; i++)
            {
                GetDirection();
                particleList.Add(new Particle(position, direction, particleAge, particleVelocity));
                shouldEmit = false;
            }
        }
    }
}

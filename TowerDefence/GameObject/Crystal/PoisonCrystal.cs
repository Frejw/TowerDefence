using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    internal class PoisonCrystal : Crystal
    {
        int poisonDamage;
        int poisonDuration;
        static Color color = Color.LimeGreen;

        public static Color Color { get { return color; } }

        ParticleEmitter emitter;
        public PoisonCrystal()
        {
            texture = Assets.T1Crystal;
            hitbox = new Rectangle(300, 100, 30, 30);
            emitter = new ParticleEmitter(ParticleEmitter.emitterType.Stream);
            gameplayManager.ParticleEmitterList.Add(emitter);
        }

        public override void Update()
        {
            emitter.Position = HitboxPosition;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, null, Color.Lime, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
        }
    }
}

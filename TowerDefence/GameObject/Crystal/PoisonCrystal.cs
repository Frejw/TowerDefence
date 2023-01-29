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
        Color color = Color.LimeGreen;

        ParticleEmitter emitter;
        public PoisonCrystal()
        {
            texture = Assets.T1Crystal;
            hitbox = new Rectangle(300, 100, 40, 40);
            emitter = new ParticleEmitter(ParticleEmitter.emitterType.Stream);
            gameplayManager.ParticleEmitterList.Add(emitter);
        }

        public override void Update()
        {
            emitter.Position = HitboxPosition;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Assets.T1Crystal, Hitbox, color);
        }
    }
}

using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.debris;

internal class RefractSmoke : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = rotation;
		p.flags = Rand.GetRandomInt(41, 50);
		p.owner = owner;
		p.frame = Rand.GetRandomFloat(0.5f, 1f);
		p.rDir = Rand.GetRandomFloat(-12f, 22f);
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		if ((double)p.frame < 0.5 && (double)p.traj.Y < -50.0)
		{
			p.traj.Y += frameTime * 1500f;
		}
		p.rotation += p.rDir * frameTime;
		base.Update(p, frameTime);
	}

	public override void Draw(Particle p, float brite)
	{
		float num = (float)((0.800000011920929 - (double)p.frame) * 2.0);
		if (!((double)num < 0.0))
		{
			Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), p.flags, new Vector2(1f, 1f) * ScrollManager.cannedDepth[0] * (p.size + (float)((1.0 - (double)p.frame) * 0.100000001490116)), p.rotation, 0f, 1f, 0f, p.frame * 2f * num);
			base.Draw(p, brite);
		}
	}
}

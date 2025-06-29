using MapEdit;
using Microsoft.Xna.Framework;
using ProjectTower.texturesheet;

namespace ProjectTower.particles.particles.debris;

internal class AirWoosh : BaseParticle
{
	public override void Init(Particle p, Vector2 loc, Vector2 traj, float size, float rotation, int flags, int owner)
	{
		p.loc = loc;
		p.traj = traj;
		p.size = size;
		p.rotation = rotation;
		p.flags = Rand.GetRandomInt(41, 50);
		p.owner = owner;
		p.frame = 1f;
		p.rotation = Trig.GetAngle(default(Vector2), p.traj);
		base.Init(p, loc, traj, size, rotation, flags, owner);
	}

	public override void Update(Particle p, float frameTime)
	{
		for (int i = 0; i < 2; i++)
		{
			base.Update(p, frameTime);
			if (!p.exists)
			{
				break;
			}
		}
	}

	public override void Draw(Particle p, float brite)
	{
		float num = p.frame;
		if ((double)num > 0.5)
		{
			num = 1f - p.frame;
		}
		Textures.tex[ParticleManager.spritesTexIdx].Draw(ScrollManager.GetScreenLoc(p.loc, 0), p.flags, new Vector2(2f, 1f) * ScrollManager.cannedDepth[0] * p.size, p.rotation, 1f, 1f, 1f, num);
		base.Draw(p, brite);
	}
}

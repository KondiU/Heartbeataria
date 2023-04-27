using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace XDContentMod.Common.Players 
{
  public class HeartbeatariaPlayer : ModPlayer
	{
        public bool OtherworldCoreEffect = false;
        
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			if (OtherworldCoreEffect && (target.type == NPCID.DD2Betsy || target.type == NPCID.DD2GoblinT1 || target.type == NPCID.DD2GoblinT2 || target.type == NPCID.DD2GoblinT3 || target.type == NPCID.DD2GoblinBomberT1 || target.type == NPCID.DD2GoblinBomberT2 || target.type == NPCID.DD2GoblinBomberT3 || target.type == NPCID.DD2WyvernT1 || target.type == NPCID.DD2WyvernT2 || target.type == NPCID.DD2WyvernT3 || target.type == NPCID.DD2JavelinstT1 || target.type == NPCID.DD2JavelinstT2 || target.type == NPCID.DD2JavelinstT3 || target.type == NPCID.DD2DarkMageT1 || target.type == NPCID.DD2DarkMageT3 || target.type == NPCID.DD2SkeletonT1 || target.type == NPCID.DD2SkeletonT3 || target.type == NPCID.DD2WitherBeastT2 || target.type == NPCID.DD2WitherBeastT3 || target.type == NPCID.DD2DrakinT2 || target.type == NPCID.DD2DrakinT3 || target.type == NPCID.DD2KoboldWalkerT2 || target.type == NPCID.DD2KoboldWalkerT3 || target.type == NPCID.DD2KoboldFlyerT2 || target.type == NPCID.DD2KoboldFlyerT3 || target.type == NPCID.DD2OgreT2 || target.type == NPCID.DD2OgreT3 || target.type == NPCID.DD2LightningBugT3))
            {
                modifiers.SourceDamage += 0.2f;
            }
        }

        public override void ResetEffects()
        {
            OtherworldCoreEffect = false;
        }
    }
}
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace XDContentMod.Content.Mounts 
{
    public class TapTapMinivan : ModMount 
    {
        public override void SetStaticDefaults () 
        {
            MountData.spawnDust = 15;
		    MountData.buff = ModContent.BuffType<Buffs.TapTapMinivanBuff>();
		    MountData.heightBoost = 16;
		    MountData.flightTimeMax = 0;
		    MountData.fallDamage = 0.2f;
		    MountData.runSpeed = 8f;
		    MountData.acceleration = 0.25f;
		    MountData.jumpHeight = 20;
		    MountData.jumpSpeed = 8.01f;
		    MountData.totalFrames = 4;

            MountData.playerYOffsets = new int[MountData.totalFrames];
		    for (int num12 = 0; num12 < MountData.playerYOffsets.Length; num12++)
		    {
		    	MountData.playerYOffsets[num12] = 8;
	    	}

		    MountData.xOffset = 2;
		    MountData.bodyFrame = 3;
	    	MountData.yOffset = 17 - MountData.heightBoost;
	    	MountData.playerHeadOffset = 18;
		    MountData.standingFrameCount = 1;
		    MountData.standingFrameDelay = 12;
	    	MountData.standingFrameStart = 0;
	    	MountData.runningFrameCount = 4;
	    	MountData.runningFrameDelay = 12;
	    	MountData.runningFrameStart = 0;
	    	MountData.inAirFrameCount = 1;
	    	MountData.inAirFrameDelay = 12;
	    	MountData.inAirFrameStart = 1;
	    	MountData.idleFrameCount = 0;
	    	MountData.idleFrameDelay = 0;
	    	MountData.idleFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
	    	MountData.idleFrameLoop = false;
	    	MountData.swimFrameCount = MountData.inAirFrameCount;
	    	MountData.swimFrameDelay = MountData.inAirFrameDelay;
	    	MountData.swimFrameStart = MountData.inAirFrameStart;
	    	if (!Main.dedServ)
	        {
		    	MountData.textureWidth = MountData.backTexture.Width();
		    	MountData.textureHeight = MountData.backTexture.Height();
		    }
        }
    }
}
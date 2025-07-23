using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.L10N;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Actors.Pads;
using Yggdrasil.Util;
using Melia.Shared.Util;

namespace Melia.Zone.Skills.Handlers.Wizards.Cryomancer
{
	/// <summary>
	/// Handler for the Archer skill Ice Wall.
	/// </summary>
	[SkillHandler(SkillId.Cryomancer_IceWall)]
	public class Cryomancer_IceWall : IGroundSkillHandler, IDynamicCasted
	{
		private const int FreezeChange = 60;

		/// <summary>
		/// Called when the user starts casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void StartDynamicCast(Skill skill, ICombatEntity caster)
		{
			if (caster is not Character casterCharacter)
				return;

			Send.ZC_NORMAL.UnkDynamicCastStart(casterCharacter, skill.Id);
			Send.ZC_PLAY_SOUND_Gendered(caster, "voice_wiz_m_icewall_cast", "voice_wiz_icewall_cast");
		}

		/// <summary>
		/// Called when the user stops casting the skill.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		public void EndDynamicCast(Skill skill, ICombatEntity caster)
		{
			if (caster is not Character casterCharacter)
				return;

			Send.ZC_NORMAL.UnkDynamicCastEnd(casterCharacter, skill.Id, 2);
			Send.ZC_STOP_SOUND_Gendered(caster, "voice_wiz_m_icewall_cast", "voice_wiz_icewall_cast");
		}

		/// <summary>
		/// Handles skill, creates the ice wall.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="target"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			if (!skill.Vars.TryGet<List<SkillCell>>("Melia.ToolCellPositions", out var skillCells) || skillCells.Count <= 0)
			{
				caster.ServerMessage(Localization.Get("No position location specified."));
				return;
			}

			farPos = skillCells[0].Position;

			if (!caster.InSkillUseRange(skill, farPos))
			{
				caster.ServerMessage(Localization.Get("Too far away."));
				return;
			}

			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			originPos = caster.Position;
			skill.IncreaseOverheat();
			caster.TurnTowards(farPos);
			caster.SetAttackState(true);

			Send.ZC_SKILL_READY(caster, skill, originPos, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, farPos, caster.Position.GetDirection(farPos), Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);

			foreach (var skillCell in skillCells)
			{
				this.SpawnIceWallEntity(caster, skill, skillCell.Position, skillCell.Direction);
			}

			caster.SetCastingState(false, SkillId.None);
		}

		/// <summary>
		/// Spawns the Ice Wall entity.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		private void SpawnIceWallEntity(ICombatEntity caster, Skill skill, Position position, Direction direction)
		{
			var pad = new Pad(PadName.Cryomancer_IceWall, caster, skill, new Square(position, direction, 25, 25));
			pad.Position = position;
			pad.Direction = direction;
			pad.Trigger.LifeTime = TimeSpan.FromSeconds(15);
			pad.Trigger.MaxActorCount = 5;
			pad.Trigger.UpdateInterval = TimeSpan.FromMilliseconds(200);
			pad.Trigger.Subscribe(TriggerType.Enter, this.OnIceWallTriggerEnter);

			caster.Map.AddPad(pad);

			var iceWallEntity = new Mob(47452, MonsterType.Mob);
			iceWallEntity.Position = position;
			iceWallEntity.Faction = FactionType.IceWall;
			iceWallEntity.FromGround = true;
			iceWallEntity.Direction = direction;

			caster.Map.AddMonster(iceWallEntity);
			Send.ZC_NORMAL.Unk13E(iceWallEntity, true);

			TaskHelper.CallSafe(this.DestroyWallEntity(caster, iceWallEntity));
		}

		/// <summary>
		/// Destroy wall after a while.
		/// </summary>
		/// <param name="iceWallEntity"></param>
		private async Task DestroyWallEntity(ICombatEntity caster, Mob iceWallEntity)
		{
			var wallDuration = TimeSpan.FromSeconds(15);
			await Task.Delay(wallDuration);
			iceWallEntity.Kill(caster);
			Send.ZC_NORMAL.ClearEffects(iceWallEntity);
		}

		/// <summary>
		/// Called by the pad when anything enters.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnIceWallTriggerEnter(object sender, PadTriggerActorArgs args)
		{
			var pad = args.Trigger;
			var creator = args.Creator;
			var target = args.Initiator;
			var skill = args.Skill;

			if (pad.Trigger.AtCapacity)
				return;

			if (!creator.CanAttack(target) || target is not Mob mob)
				return;

			// Skips freezing walls itself.
			if (mob.Data.Id == 47452)
				return;

			if (RandomProvider.Get().Next(100) < FreezeChange)
				target.StartBuff(BuffId.Cryomancer_Freeze, skill.Level, 0, TimeSpan.FromSeconds(5), creator);
		}
	}
}

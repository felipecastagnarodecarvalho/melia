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
	/// <remarks>
	/// TODO: Implement the sub-attack feature - once the caster attacks the ice wall it should spread particles that damage enemies.
	/// </remarks>
	[SkillHandler(SkillId.Cryomancer_IceWall)]
	public class Cryomancer_IceWall : IGroundSkillHandler, IDynamicCasted
	{
		private const int BaseFreezeChange = 60;

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

			// [Arts] Ice Wall: Magic Igloo - Used at caster position
			if (caster.IsAbilityActive(AbilityId.Cryomancer26))
				farPos = caster.Position;
			else
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

			var duration = TimeSpan.FromSeconds(15);

			if (caster.IsAbilityActive(AbilityId.Cryomancer22))
				duration += TimeSpan.FromSeconds(10);

			// [Arts] Ice Wall: Magic Igloo - Spawns Igloo at caster position that gives freeze immunity to nearby allies.
			if (caster.IsAbilityActive(AbilityId.Cryomancer26))
			{
				var pad = new Pad(PadName.Cryomancer_Igloo, caster, skill, new Circle(caster.Position, 55));
				pad.Position = caster.Position;
				pad.Direction = caster.Direction;
				pad.Trigger.LifeTime = duration;
				pad.Trigger.MaxActorCount = 12;
				pad.Trigger.UpdateInterval = TimeSpan.FromMilliseconds(200);
				pad.Trigger.Subscribe(TriggerType.Enter, this.OnIglooTriggerEnter);
				pad.Trigger.Subscribe(TriggerType.Leave, this.OnIglooTriggerLeave);

				caster.Map.AddPad(pad);
			} else
			{
				// Default cast - Spawns Ice Walls for each cell
				foreach (var skillCell in skillCells)
				{
					this.SpawnIceWallEntity(caster, skill, skillCell.Position, skillCell.Direction, duration);
				}
			}



			caster.SetCastingState(false, SkillId.None);
		}

		/// <summary>
		/// Spawns the Ice Wall entity.
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		private void SpawnIceWallEntity(ICombatEntity caster, Skill skill, Position position, Direction direction, TimeSpan duration)
		{
			var pad = new Pad(PadName.Cryomancer_IceWall, caster, skill, new Square(position, direction, 25, 25));
			pad.Position = position;
			pad.Direction = direction;
			pad.Trigger.LifeTime = duration;
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

			TaskHelper.CallSafe(this.DestroyWallEntity(caster, iceWallEntity, duration));
		}

		/// <summary>
		/// Destroy wall after a while.
		/// </summary>
		/// <param name="iceWallEntity"></param>
		private async Task DestroyWallEntity(ICombatEntity caster, Mob iceWallEntity, TimeSpan duration)
		{
			await Task.Delay(duration);
			iceWallEntity.Kill(caster);
			Send.ZC_NORMAL.ClearEffects(iceWallEntity);
		}

		/// <summary>
		/// Called by the ice wall pad when anything enters.
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

			if (RandomProvider.Get().Next(100) < this.GetFreezingChance(creator))
				target.StartBuff(BuffId.Cryomancer_Freeze, skill.Level, 0, TimeSpan.FromSeconds(5), creator);
		}

		/// <summary>
		/// Called by the Igloo pad when anything enters.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnIglooTriggerEnter(object sender, PadTriggerActorArgs args)
		{
			var pad = args.Trigger;
			var creator = args.Creator;
			var target = args.Initiator;
			var skill = args.Skill;

			if (pad.Trigger.AtCapacity)
				return;

			if (creator.CanAttack(target))
				return;

			var duration = TimeSpan.FromSeconds(15);

			if (creator.IsAbilityActive(AbilityId.Cryomancer22))
				duration += TimeSpan.FromSeconds(10);

			if (!target.IsBuffActive(BuffId.Igloo_FreezeImmune_Buff))
				target.StartBuff(BuffId.Igloo_FreezeImmune_Buff, skill.Level, 0, duration, creator);
		}

		/// <summary>
		/// Called when an actor leaves the Igloo pad.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnIglooTriggerLeave(object sender, PadTriggerActorArgs args)
		{ 
			var pad = args.Trigger;
			var creator = args.Creator;
			var target = args.Initiator;
			var skill = args.Skill;

			if (pad.Trigger.AtCapacity)
				return;

			if (creator.CanAttack(target))
				return;

			if (target.IsBuffActive(BuffId.Igloo_FreezeImmune_Buff))
				target.StopBuff(BuffId.Igloo_FreezeImmune_Buff);
		}

		/// <summary>
		/// Returns the freezing chance.
		/// </summary>
		/// <param name="caster"></param>
		private int GetFreezingChance(ICombatEntity caster)
		{
			// Cryomancer: Freeze Speciality
			caster.TryGetAbility(AbilityId.Cryomancer9, out var ability);
			return BaseFreezeChange + (ability != null ? ability.Level * 5 : 0);
		}
	}
}

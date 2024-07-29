﻿using System;
using Melia.Shared.Game.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Pads;
using Melia.Zone.World.Actors.Monsters;
using Melia.Shared.World;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handler for the Out Of Body Experience (OOBE) Prakriti Buff
	/// which makes the character go back to original position after a while
	/// and leave a effect that damages enemies inside
	/// </summary>
	[BuffHandler(BuffId.OOBE_Prakriti_Buff)]
	public class OOBE_Prakriti_Buff : BuffHandler
	{
		public override void OnEnd(Buff buff)
		{
			var caster = buff.Caster;

			if (caster is not Character casterCharacter)
				return;

			if (caster.TryGetSkill(SkillId.Sadhu_Prakriti, out var skill)) {
				caster.SetAttackState(true);
				var pad = new Pad(PadName.Sadhu_Prakriti_Pad, caster, skill, new Circle(caster.Position, 90));
				pad.Position = new Position(pad.Trigger.Area.Center.X, caster.Position.Y, pad.Trigger.Area.Center.Y);
				pad.Trigger.MaxActorCount = 10;
				pad.Trigger.LifeTime = TimeSpan.FromSeconds(10);
				pad.Trigger.UpdateInterval = TimeSpan.FromSeconds(1);
				pad.Trigger.Subscribe(TriggerType.Update, this.OnUpdate);

				caster.Map.AddPad(pad);
				skill.IncreaseOverheat();
			}

			casterCharacter.Properties.Modify(PropertyName.MSPD_BM, -buff.NumArg1);

			Send.ZC_NORMAL.EndOutOfBodyBuff(casterCharacter, BuffId.OOBE_Prakriti_Buff);
			Send.ZC_NORMAL.UpdateModelColor(casterCharacter, 255, 255, 255, 255, 0.01f);

			Send.ZC_PLAY_SOUND(casterCharacter, "I_force0082_1");

			var dummyCharacter = casterCharacter.Map.GetDummyCharacter((int)buff.NumArg2);

			if (dummyCharacter != null)
			{
				casterCharacter.Position = dummyCharacter.Position;
				casterCharacter.Direction = dummyCharacter.Direction;
				Send.ZC_ROTATE(casterCharacter);
				Send.ZC_SET_POS(casterCharacter, dummyCharacter.Position);
				Send.ZC_OWNER(casterCharacter, dummyCharacter, 0);
				Send.ZC_LEAVE(dummyCharacter);
				casterCharacter.Map.RemoveDummyCharacter(dummyCharacter);
			}
		}

		/// <summary>
		/// Called in regular intervals while the pad is on a map.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnUpdate(object sender, PadTriggerArgs args)
		{
			var pad = args.Trigger;
			var caster = args.Creator;
			var skill = args.Skill;

			var targets = pad.Trigger.GetAttackableEntities(caster);

			foreach (var target in targets.LimitRandom(pad.Trigger.MaxActorCount))
			{
				this.Attack(skill, caster, target);
			}
		}

		/// <summary>
		/// Area of effect that ticks dealing damage on the enemies inside
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		private void Attack(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			var skillHitResult = SCR_SkillHit(caster, target, skill);

			target.TakeDamage(skillHitResult.Damage, caster);

			var hit = new HitInfo(caster, target, skill, skillHitResult);
			hit.Type = HitType.Type33;

			Send.ZC_HIT_INFO(caster, target, hit);
		}
	}
}

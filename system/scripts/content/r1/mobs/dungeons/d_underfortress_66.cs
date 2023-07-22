//--- Melia Script -----------------------------------------------------------
// Drill Ground of Confliction Spawns
//--- Description -----------------------------------------------------------
// Sets up monster spawners for 'd_underfortress_66'.
//---------------------------------------------------------------------------

using System;
using Melia.Zone.Scripting;
using Melia.Shared.Tos.Const;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderfortress66MobScript : GeneralScript
{
	public override void Load()
	{
		// Property Overrides -------------------------------

		AddPropertyOverrides("d_underfortress_66", MonsterId.Chafperor_Purple, Properties("MHP", 292988, "MINPATK", 4269, "MAXPATK", 5148, "MINMATK", 4269, "MAXMATK", 5148, "DEF", 20006, "MDEF", 20006));
		AddPropertyOverrides("d_underfortress_66", MonsterId.Chafperor_Mage_Purple, Properties("MHP", 294927, "MINPATK", 4294, "MAXPATK", 5179, "MINMATK", 4294, "MAXMATK", 5179, "DEF", 20365, "MDEF", 20365));
		AddPropertyOverrides("d_underfortress_66", MonsterId.Ticen_Mage_Blue, Properties("MHP", 296924, "MINPATK", 4319, "MAXPATK", 5210, "MINMATK", 4319, "MAXMATK", 5210, "DEF", 20735, "MDEF", 20735));
		AddPropertyOverrides("d_underfortress_66", MonsterId.Ticen_Blue, Properties("MHP", 298977, "MINPATK", 4346, "MAXPATK", 5243, "MINMATK", 4346, "MAXMATK", 5243, "DEF", 21116, "MDEF", 21116));
		AddPropertyOverrides("d_underfortress_66", MonsterId.Boss_Spector_M_Q2, Properties("MHP", 1535536, "MINPATK", 10494, "MAXPATK", 12663, "MINMATK", 10494, "MAXMATK", 12663, "DEF", 51617, "MDEF", 51617));

		// Monster Spawners ---------------------------------

		AddSpawner("d_underfortress_66.Id1", MonsterId.Chafperor_Purple, min: 75, max: 100, tendency: TendencyType.Aggressive);
		AddSpawner("d_underfortress_66.Id2", MonsterId.Chafperor_Mage_Purple, min: 12, max: 16, tendency: TendencyType.Aggressive);
		AddSpawner("d_underfortress_66.Id3", MonsterId.Ticen_Mage_Blue, min: 12, max: 15, tendency: TendencyType.Aggressive);
		AddSpawner("d_underfortress_66.Id4", MonsterId.Rootcrystal_05, min: 12, max: 15, respawn: TimeSpan.FromMilliseconds(20000), tendency: TendencyType.Peaceful);

		// Monster Spawn Points -----------------------------

		// 'Chafperor_Purple' GenType 9 Spawn Points
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-39, 281, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-668, 544, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1281, 543, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1206, -1161, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-19, -1208, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-323, -113, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(169, 42, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1009, -546, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-534, -675, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-601, -1110, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(13, -454, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-68, -7, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-212, 547, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(63, 852, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-289, 201, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1137, 747, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1096, -781, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1151, -618, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-451, -427, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(27, -971, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-872, -1169, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-422, 11, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-154, -478, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-795, 519, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(106, 160, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-753, -451, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(262, -471, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(96, -1246, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-973, 594, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-487, 188, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-121, 229, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-156, 385, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(7, 618, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(405, 165, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(642, 123, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(600, -115, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(673, -317, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(384, -128, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(102, -242, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-93, -214, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-405, -159, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-563, -874, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(52, -786, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-995, -762, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-852, -558, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1033, -393, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1102, -479, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-844, -780, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-731, -1158, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-532, -978, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(75, -1148, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(497, -392, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-227, 8, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(61, -112, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(317, -59, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(32, -1191, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-34, -1251, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-5, -1177, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(120, -1212, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(78, -1190, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(82, -1055, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(32, -1033, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(118, -1042, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(31, -927, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(75, -1021, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(109, -789, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(78, -763, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(38, -677, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(8, -692, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(7, -625, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(16, -512, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(75, -457, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-89, -500, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-127, -456, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-195, -499, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(642, -280, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(705, -240, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(627, -213, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(671, -157, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(634, -100, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(552, -97, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(550, -165, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(681, 25, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(645, 72, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(722, 29, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(282, -112, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(205, -82, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(152, -83, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(117, 29, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(59, -5, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(26, -232, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(160, -226, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(257, -204, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(328, -231, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(333, -174, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-30, -212, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-181, -229, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-257, -212, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-351, -250, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-480, -206, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-381, -111, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-459, -125, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-475, -39, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-497, 14, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-353, 29, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-273, -80, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-335, -210, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-395, -202, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-301, 19, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-296, 67, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-135, 4, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-122, 46, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(24, -5, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(79, 34, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(220, 2, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(208, -128, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(260, -76, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(118, -203, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(195, -189, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(48, -194, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-412, 229, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-488, 245, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-372, 163, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-357, 252, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-270, 243, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-120, 265, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-188, 197, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-35, 216, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-59, 262, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(19, 274, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-131, 329, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-176, 346, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-178, 383, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-162, 502, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-211, 496, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-261, 612, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-195, 594, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-582, 560, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-557, 626, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-651, 611, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-671, 497, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-711, 536, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-592, 529, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-803, 468, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-738, 506, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-764, 561, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-852, 549, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-818, 607, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-699, 594, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-752, 591, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1243, 485, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1209, 517, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1091, 501, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1125, 575, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1072, 722, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1180, 769, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1152, 806, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1058, 767, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1094, 691, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1243, 813, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1282, 477, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1312, 475, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1191, 451, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1225, 503, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1139, 478, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1084, 756, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1205, 745, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1242, 778, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1280, 782, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1221, 839, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(28, 662, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(91, 738, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(79, 793, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(113, 837, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(0, 765, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(54, 773, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(15, 859, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(50, 901, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(110, 772, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(102, 815, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(238, 160, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(298, 167, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(333, 200, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(277, 213, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(254, 191, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(53, 147, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(58, 205, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(120, 202, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-6, 166, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(12, 232, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1272, -1153, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1215, -1212, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1291, -1172, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1147, -1155, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1198, -1117, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-959, -1151, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-919, -1126, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-836, -1132, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-790, -1179, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-770, -1119, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-522, -1163, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-572, -1188, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-601, -1148, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-570, -934, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-507, -912, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-567, -793, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-514, -761, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-577, -741, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-564, -687, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-526, -622, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-877, -814, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-945, -804, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1030, -809, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1097, -742, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1185, -648, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1144, -533, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1040, -556, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-819, -659, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-853, -611, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-927, -611, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-954, -662, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1022, -643, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1059, -580, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-1026, -452, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-931, -453, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-519, -461, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-444, -490, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-472, -455, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-556, -527, 20));
		AddSpawnPoint("d_underfortress_66.Id1", "d_underfortress_66", Rectangle(-470, -516, 20));

		// 'Chafperor_Mage_Purple' GenType 38 Spawn Points
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(6, 814, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(73, -1241, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(116, -1094, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-576, -1121, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-898, -1178, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-1312, -1192, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-1081, -668, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-570, -473, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-213, 566, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(118, -106, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-603, 617, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-1171, 548, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-162, 196, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-204, 25, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-29, -465, 30));
		AddSpawnPoint("d_underfortress_66.Id2", "d_underfortress_66", Rectangle(-943, -519, 30));

		// 'Ticen_Mage_Blue' GenType 39 Spawn Points
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-128, -245, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-215, 256, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(13, 736, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-682, 555, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-1159, 539, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-1211, 829, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-1099, -671, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-941, -537, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-963, -1180, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-577, -1147, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-555, -726, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-365, -117, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(42, -1082, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-7, -1265, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(36, -85, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(18, -724, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-525, -501, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(258, -415, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(-227, 542, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(200, 203, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(673, 74, 30));
		AddSpawnPoint("d_underfortress_66.Id3", "d_underfortress_66", Rectangle(645, -233, 30));

		// 'Rootcrystal_05' GenType 57 Spawn Points
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(78, -1028, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(67, -520, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-533, -545, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-788, -1128, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-1242, -1216, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-979, -727, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(635, -121, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(919, 268, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(1993, 207, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-72, 204, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(82, 760, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-735, 605, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-1079, 625, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(-210, -103, 40));
		AddSpawnPoint("d_underfortress_66.Id4", "d_underfortress_66", Rectangle(147, -182, 40));
	}
}

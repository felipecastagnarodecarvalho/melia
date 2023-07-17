//--- Melia Script -----------------------------------------------------------
// f_remains_37_2
//
//--- Description -----------------------------------------------------------
// Sets up the f_remains_37_2 mobs.
//---------------------------------------------------------------------------

using System;
using Melia.Zone.Scripting;
using Melia.Shared.Tos.Const;
using static Melia.Zone.Scripting.Shortcuts;

public class FRemains372MobScript : GeneralScript
{
	public override void Load()
	{

		// Monster Spawners --------------------------------

		AddSpawner("f_remains_37_2.Id1", MonsterId.Rootcrystal_04, 40, TimeSpan.FromMilliseconds(60000), TendencyType.Peaceful);
		AddSpawner("f_remains_37_2.Id2", MonsterId.Lizardman_Mage, 20, TimeSpan.FromMilliseconds(0), TendencyType.Aggressive);
		AddSpawner("f_remains_37_2.Id3", MonsterId.Minos, 90, TimeSpan.FromMilliseconds(0), TendencyType.Aggressive);
		AddSpawner("f_remains_37_2.Id4", MonsterId.Minos_Bow, 15, TimeSpan.FromMilliseconds(0), TendencyType.Aggressive);
		AddSpawner("f_remains_37_2.Id5", MonsterId.Minos, 20, TimeSpan.FromMilliseconds(0), TendencyType.Aggressive);

		// Monster Spawn Points -----------------------------

		// Rootcrystal_04 Spawn Points
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(1757.25, -451.46, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(1552.89, -419.33, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(1245.13, -432.46, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(970.98, -301.81, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(868.26, -453.31, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(880.14, -1.77, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(856.66, -701.01, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(849.83, -1148.86, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(1247.08, -1202.11, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(872.18, 272.14, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(982.19, 714.22, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(685.44, 838.69, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(728.72, 1338.03, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(754.25, 1860.96, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(1126.06, 221.91, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(371.93, 257.27, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(16.44, 246.31, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-289.08, 267.96, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-603.28, 271.68, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-890.85, 269.39, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1358.19, 273.58, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1642.39, 32.75, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(80.2, -258.23, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(30.17, -659.92, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-149.47, -918.94, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-48.29, -1200.82, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(100.79, -1492.32, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-507.6, -812.06, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1059.12, -799.86, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-764.15, 555.41, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-775.88, 896.37, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-240.28, 945.53, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(84.97, 813.09, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1059.14, 994.28, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1377.82, 919.86, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1515.56, 1248.25, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1358.27, 1470.1, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-1422.72, 686.28, 40));
		AddSpawnPoint( "f_remains_37_2.Id1", "f_remains_37_2", Spot(-789.73, 1408.03, 40));

		// Lizardman_Mage Spawn Points
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-1114.6034, -926.01807, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-994.18384, -780.8258, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-871.27515, -923.85504, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-317.45, -748.06, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-111, -553.56, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(123.02698, -754.1671, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-89.59535, -779.4785, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-133.76, -1329.1, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-89.629265, -1531.9904, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(174.22467, -1421.8389, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-0.33538103, -1417.0616, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(893.482, -1222.9799, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1007.2325, -1078.6863, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1120.5808, -1353.2285, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1298.0005, -1140.5406, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1141.6584, -1197.5361, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(942.89703, -472.43158, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1088.4292, -178.47354, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(61.502434, -1290.3744, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-74.275795, -982.6258, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-789.1448, -781.382, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-1256.2532, -726.05304, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1320.8336, -1319.0687, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(1156.617, -1004.6791, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(145.03838, -568.2307, 25));
		AddSpawnPoint( "f_remains_37_2.Id2", "f_remains_37_2", Spot(-239.39851, -928.02484, 25));

		// Minos Spawn Points
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(997.5501, -227.99495, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(699.8475, -192.34624, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1134.2709, -529.3155, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1193.0975, -332.28058, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(682.1765, 804.99176, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(929.15, 904.47, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(931.2731, 695.31146, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(784.7456, 600.16364, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(609.87, 1695.07, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(786.14, 1792.27, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(823.48, 1510.34, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1500.6836, 1163.5972, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1304.36, 929.63, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-240.06, 1086.7, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(965.6, 1893.96, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1777.16, 252.05, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1508.94, 213.32, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-69.21, 414.93, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-9.787209, 242.20863, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(888.4131, -327.71246, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(582.87274, 1452.185, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(114.3951, 846.56573, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1450.205, 859.0936, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(791.8762, 1304.5039, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1036.9457, 1592.9817, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1229.1746, 564.76, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1485.421, 637.5392, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1342.4954, -58.397648, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1398.7351, 1501.6998, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1247.3771, 1238.3445, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-86.29111, 883.1289, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-256.19855, 251.3959, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1136.5656, 748.87286, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(541.8047, 1979.0254, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(793.79407, -409.4169, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-110.38949, -804.73804, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-269.68826, -977.6754, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(24.038696, -897.41943, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-273.81046, -666.7171, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-118.52915, -628.0393, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(105.61931, -753.6014, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1045.9564, -935.0731, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1098.8474, -731.5137, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-856.65375, -715.31604, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-922.9553, -916.16235, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-972.95703, -831.66986, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-160.27316, 354.22684, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(215.11081, 239.06525, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1581.1694, 987.6994, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1591.2942, 44.229725, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-82.283905, -1458.3079, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(77.62113, -1501.4999, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(100.15086, -1389.0312, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(187.88808, -1333.4623, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-30.914719, -1261.337, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-100.30334, -1219.7401, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-125.85686, -1404.9836, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-50.914955, -1349.1918, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(26.738358, -1354.8717, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(4.0428057, -1576.9987, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-159.71284, -973.8315, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-17.903294, -974.18604, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(99.05802, -945.4825, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(116.91998, -861.3248, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(178.16461, -792.28546, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(179.07195, -699.1386, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(69.2859, -607.7905, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(90.269325, -680.2926, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-7.321274, -592.58746, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-63.03624, -577.12195, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(111.26645, -512.7474, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(36.57079, -509.49646, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-51.673912, -495.6214, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-179.51588, -527.57916, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-191.87326, -641.24677, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-244.55493, -733.60223, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-251.54836, -804.9991, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-251.16391, -862.52405, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-262.87683, -1055.7561, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-45.06758, -1041.554, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-798.42194, -871.4723, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-889.56287, -850.45337, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-888.3751, -790.0249, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-953.2273, -740.87683, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1012.2278, -683.29376, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1117.5544, -669.135, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1196.6643, -693.8953, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1224.0458, -795.5678, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1155.1517, -805.5427, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1078.9304, -842.43286, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1019.7962, -1015.323, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-942.6851, -1013.6122, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-806.6652, -985.68976, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1164.2786, -749.11896, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1182.5695, -629.3856, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1703.0713, 231.07275, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1643.2327, 322.3965, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1584.2987, 263.5124, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1706.7717, 59.10101, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1653.6434, 132.43535, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1497.4463, 126.78275, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1478.1829, 41.827663, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1405.2344, -27.029652, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1388.3809, 117.10322, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1422.7812, 221.0073, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1287.6106, 184.91525, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1177.3411, 143.66512, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1212.4902, 42.67555, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1194.269, -34.258083, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1281.5782, -91.56659, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1430.0308, 718.95026, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1319.4797, 779.7045, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1353.1272, 590.53204, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1280.3936, 565.08954, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1242.0183, 684.85034, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1235.9298, 830.7091, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1456.1104, 955.939, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1353.1613, 1027.2665, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1530.3888, 865.97076, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1643.0475, 1027.3369, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1674.7242, 1123.6759, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1523.2572, 1234.2726, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1410.9214, 1283.5057, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1354.2621, 1281.9622, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1232.7898, 1360.5337, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1285.1152, 1457.7319, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1394.9507, 1596.1699, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1476.0897, 1575.7981, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1507.475, 1453.433, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-1158.6019, 1219.8927, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-316.21558, 858.31506, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-324.29257, 1045.2734, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-361.29498, 1142.0333, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-211.6277, 1009.7224, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-139.57332, 1157.4905, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-82.67676, 1088.1168, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-79.53483, 984.386, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(23.907017, 969.36053, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(137.88739, 945.222, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(209.97441, 874.83295, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-14.621775, 812.1702, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(178.92877, 713.0648, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(53.847656, 894.156, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(213.5891, 783.1711, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(90.74945, 1047.8138, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-330.55948, 262.5205, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-250.75652, 312.30963, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-393.77557, 234.75836, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-371.54446, 364.22214, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(-107.38675, 210.5629, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1213.2014, -1115.8455, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1239.7467, -1228.1334, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1313.9232, -1210.5721, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1247.8115, -1321.6904, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1167.3247, -1394.4471, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1096.2965, -1249.6221, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(982.22174, -1235.8529, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1074.0128, -1172.3425, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1052.7517, -985.28925, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(915.3549, -1109.4557, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(762.7992, -1165.8639, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(847.7457, -1153.2567, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(893.2847, -959.7853, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1247.3007, -1040.8154, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1383.8813, -1178.2834, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(969.21967, -1164.3451, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1066.645, -1394.8624, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(985.4441, -1369.4565, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1028.3297, -1307.5609, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1180.1444, -1300.3723, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(981.6073, -564.7834, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1083.5664, -588.7055, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1220.4713, -587.17633, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1235.8652, -458.5269, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1269.4257, -318.26202, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1135.9573, -447.71667, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1106.3853, -302.5924, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1049.8947, -392.5161, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1006.3359, -310.9003, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(967.2237, -394.58148, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(976.56256, -143.76804, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(850.71814, -134.61736, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(804.6487, -234.33038, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(677.8384, -434.07703, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(717.6271, -387.24994, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(636.80975, -290.17255, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(644.8295, -206.71216, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(720.683, -270.78595, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(791.44525, -168.45525, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(902.59265, -221.66728, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(726.78625, 685.38196, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(821.0551, 700.571, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1040.1729, 591.9577, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1111.9696, 515.20355, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1228.5087, 654.6786, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1075.2764, 674.3147, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1006.0273, 804.05646, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1018.8257, 942.55725, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(871.67474, 794.7023, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(783.7503, 868.04224, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(681.277, 884.97406, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(773.3961, 761.58545, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(650.4961, 687.60754, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(857.68396, 876.17725, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(701.50085, 602.54333, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(903.51587, 624.90326, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1007.7819, 704.6266, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1146.2686, 597.5116, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1205.0955, 477.69617, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1021.9064, 510.55664, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(719.82947, 1271.5911, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(644.5876, 1350.5529, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(732.4849, 1413.031, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(899.21783, 1374.793, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(953.8587, 1514.3168, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(968.0747, 1638.9718, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(920.96936, 1770.7788, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(771.07074, 1701.3755, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(676.3646, 1799.0214, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(461.56183, 1629.6152, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(506.75555, 1548.104, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(466.39078, 1721.5992, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(510.11606, 1846.8834, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(623.2035, 1985.2668, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(730.3654, 1990.294, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(758.6456, 1853.0779, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(870.00476, 1830.3623, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(1088.5096, 1862.8835, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(897.604, 1700.21, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(810.7716, 1600.9402, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(713.39685, 1566.0869, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(877.5429, 1443.1506, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(805.8907, 1384.8531, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(639.05457, 1486.2112, 40));
		AddSpawnPoint( "f_remains_37_2.Id3", "f_remains_37_2", Spot(600.25165, 1594.0752, 40));

		// Minos_Bow Spawn Points
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-203.87, 268.71, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1593.8965, 1178.7845, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1567.8344, 85.399796, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1301.33, 76.24, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-121.86, 927.91, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-407.25, 1000.79, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-7.05, 1057.26, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1373.26, 670.99, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1620.81, 923.13, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1261.2, 1243.48, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(97.15817, 250.55846, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1503.8164, 329.94235, 40));
		AddSpawnPoint( "f_remains_37_2.Id4", "f_remains_37_2", Spot(-1340.9382, 1529.2728, 40));

		// Minos Spawn Points
		AddSpawnPoint( "f_remains_37_2.Id5", "f_remains_37_2", Spot(-156.37709, 929.4145, 9999));

	}
}

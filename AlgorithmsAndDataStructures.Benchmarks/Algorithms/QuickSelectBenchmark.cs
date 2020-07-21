﻿using AlgorithmsAndDataStructures.Algorithms.Search;
using BenchmarkDotNet.Attributes;
using System;

namespace AlgorithmsAndDataStructures.Benchmarks.Algorithms
{
    [HtmlExporter]
    [RPlotExporter]
    [CsvMeasurementsExporter]
    [MarkdownExporterAttribute.GitHub]
    public class QuickSelectBenchmark
    {
        #region data
        private static int[] data = new int[] { 7179, 1869, 9650, 8719, 3056, 5077, 3122, 791, 7032, 2122, 3941, 4961, 4936, 2020, 3843, 5161, 5965, 7495, 7053, 7455, 5088, 1253, 5101, 6393, 6114, 9750, 5406, 9481, 2565, 5875, 9080, 4943, 2291, 7296, 7372, 40, 5709, 9869, 7870, 5862, 2942, 1244, 6794, 294, 1178, 1773, 4012, 1842, 7812, 8224, 1676, 7413, 1220, 9012, 9338, 5926, 6768, 3256, 2605, 3306, 9670, 3640, 8226, 1156, 3041, 8998, 2670, 7640, 4648, 3803, 9451, 6096, 9625, 1190, 4512, 3844, 4459, 4806, 5215, 4340, 5737, 3563, 1669, 4340, 4198, 1667, 3722, 3278, 7957, 1446, 3271, 2453, 7264, 4563, 6192, 9302, 3017, 5637, 7252, 2179, 9103, 6372, 7194, 4008, 8772, 5580, 7787, 29, 4499, 5493, 1467, 1961, 8041, 8264, 7568, 6106, 1970, 3885, 6957, 1374, 5275, 9391, 9683, 3202, 531, 6998, 8832, 5061, 4998, 5210, 827, 8821, 7554, 3035, 5237, 9365, 6369, 7661, 5567, 8618, 3880, 3693, 8779, 2463, 9978, 1310, 4411, 8999, 6995, 86, 7332, 9131, 8679, 5878, 6903, 9711, 6688, 3992, 3477, 1774, 6747, 2725, 5031, 9289, 4666, 2645, 4407, 5006, 3026, 8202, 9736, 4309, 8318, 8339, 7493, 1582, 612, 7219, 3223, 9221, 2586, 9832, 8066, 4912, 7878, 1695, 141, 1675, 6131, 5526, 2676, 2377, 4183, 3793, 1870, 1155, 8662, 9489, 7797, 7333, 6902, 9405, 5972, 8793, 349, 3022, 813, 340, 8384, 5321, 9098, 9469, 768, 4256, 9187, 6915, 4659, 119, 1411, 2971, 2503, 2731, 8874, 7500, 5525, 7359, 125, 4524, 6469, 6338, 2920, 1122, 9422, 5890, 2318, 3180, 3859, 9273, 4562, 4855, 882, 9801, 3290, 810, 6427, 3207, 1608, 9927, 4605, 4954, 6495, 8542, 8078, 4825, 4829, 4171, 531, 8472, 3267, 2989, 2897, 6288, 3870, 2046, 2400, 7976, 47, 4878, 1938, 6007, 3055, 5385, 5556, 6555, 2088, 2702, 9440, 8064, 1073, 2318, 5751, 198, 9919, 1514, 9842, 4377, 3043, 4596, 1060, 8147, 2649, 5387, 6005, 1573, 1957, 4593, 5930, 1244, 8409, 8450, 3160, 6729, 7989, 8598, 1899, 1110, 2986, 1522, 2736, 2127, 4730, 2466, 7399, 949, 7237, 2699, 6369, 2356, 2203, 8023, 4932, 5450, 3818, 3790, 3357, 7668, 9380, 3982, 4598, 7495, 6771, 8195, 9654, 2622, 9158, 9022, 2208, 1321, 9614, 8732, 1390, 1520, 1859, 8933, 3416, 182, 7988, 5056, 4335, 9258, 8224, 3574, 9041, 386, 3518, 7709, 2910, 4198, 5240, 4231, 1729, 9003, 6924, 5241, 5355, 6534, 2811, 4777, 1791, 8215, 490, 5048, 2741, 3470, 6632, 3411, 3590, 4884, 374, 3174, 9680, 4323, 9647, 5339, 9271, 3197, 9154, 9268, 9103, 1448, 6111, 8010, 6080, 5383, 7002, 2387, 4596, 6618, 3577, 6881, 7370, 3210, 3265, 6119, 8767, 3175, 832, 5571, 3754, 106, 4118, 8026, 3823, 2065, 4550, 7406, 9356, 1584, 5970, 2157, 7380, 3543, 5673, 342, 2104, 2480, 8967, 7358, 6467, 4245, 8815, 6972, 1306, 3492, 5804, 6469, 1057, 3527, 6572, 6095, 2365, 3583, 5514, 8997, 7329, 8085, 4186, 4014, 832, 9596, 3030, 3011, 647, 1419, 9501, 3827, 7537, 2922, 4015, 6287, 4208, 3474, 9103, 9508, 1290, 7146, 6719, 331, 6261, 8081, 6348, 5829, 5012, 9875, 9792, 3797, 8028, 6675, 3013, 4019, 8293, 4953, 6525, 6871, 1214, 5804, 6325, 9886, 3991, 1976, 8931, 8134, 9511, 284, 1887, 8891, 4479, 6005, 7707, 182, 1366, 3855, 7753, 2751, 3247, 7200, 7998, 772, 1627, 5703, 5799, 862, 9909, 9995, 7993, 9254, 6948, 2232, 8294, 5485, 821, 6832, 6339, 4285, 9149, 8214, 6317, 4727, 7988, 901, 9317, 2022, 8967, 2830, 2653, 4438, 7200, 3774, 3623, 4014, 7806, 5552, 8259, 8288, 6177, 8069, 8225, 9515, 2290, 2632, 1942, 2247, 7711, 2222, 9361, 4533, 7515, 3467, 3601, 5033, 882, 3270, 2784, 725, 6385, 3776, 1894, 7078, 7342, 3555, 2054, 3174, 8608, 4279, 7679, 5268, 8572, 8051, 8107, 1080, 9988, 6802, 2437, 5355, 8959, 7070, 4311, 6745, 3468, 8119, 6922, 3732, 172, 8590, 3131, 4535, 2768, 7533, 1902, 2401, 6175, 1147, 2173, 8735, 577, 8767, 3639, 3432, 4542, 4093, 5961, 9463, 5360, 2520, 5045, 4080, 833, 7428, 1766, 9315, 9464, 5148, 3609, 9223, 6632, 8322, 3001, 18, 1147, 3143, 2500, 1038, 6148, 5706, 4905, 8840, 4628, 3701, 4778, 192, 3430, 879, 2203, 9375, 2158, 7458, 8372, 7652, 3545, 9051, 3701, 5339, 5767, 2587, 2936, 1026, 7538, 2950, 2102, 2254, 5765, 3621, 2284, 1398, 1593, 4922, 3314, 9653, 7615, 6204, 9451, 7132, 2649, 1574, 5884, 8585, 2945, 4233, 7064, 9173, 9950, 5349, 6473, 2095, 9442, 7160, 5271, 3561, 2770, 3878, 1302, 1678, 1598, 2523, 4426, 9809, 8594, 804, 7782, 7235, 4144, 8718, 37, 7340, 9599, 6569, 2689, 4193, 6703, 4350, 8081, 3304, 5885, 2929, 2303, 415, 7148, 188, 1956, 4432, 9651, 9753, 6882, 3736, 4901, 7773, 5533, 126, 7147, 6074, 9991, 2140, 6451, 9829, 5029, 1231, 5312, 9132, 2496, 2872, 4470, 1077, 6858, 8420, 5797, 7998, 5793, 8669, 220, 4011, 2661, 8405, 8848, 3349, 7583, 4390, 1836, 6300, 2438, 1826, 1036, 2563, 7045, 628, 4359, 5940, 6852, 6056, 7899, 1071, 5103, 8015, 7692, 9083, 9962, 8573, 2895, 8461, 7938, 6903, 1980, 6864, 9905, 3136, 3413, 1585, 3292, 3102, 2245, 639, 9395, 9011, 6693, 669, 1836, 1906, 4031, 6229, 4061, 9856, 1145, 9737, 769, 9148, 8907, 4645, 713, 9764, 3386, 9010, 1495, 3374, 8362, 5535, 9846, 4171, 2657, 3909, 7215, 2773, 2648, 3750, 3810, 7260, 1676, 6091, 1322, 7023, 7247, 8055, 4541, 6665, 4400, 8082, 5758, 2242, 6094, 757, 4228, 8767, 871, 3528, 9715, 3235, 9143, 6020, 649, 1158, 822, 7664, 9249, 122, 9013, 1287, 7208, 7395, 5926, 3508, 7471, 2816, 3322, 3690, 2516, 5331, 4468, 4829, 8973, 279, 9776, 7603, 8077, 1899, 9681, 8447, 1901, 9119, 4034, 575, 8116, 5655, 5442, 163, 6200, 9582, 8806, 4419, 7652, 3112, 874, 8363, 6316, 2585, 3286, 1412, 5445, 7181, 1011, 4384, 8766, 4314, 7047, 369, 1381, 3218, 9587, 7349, 440, 566, 9385, 8088, 3360, 5350, 5391, 1816, 7373, 3159, 7489, 2933, 6525, 48, 7177, 5860, 9405, 1413, 1287, 5491, 8613, 8269, 3002, 4719, 8107, 9650, 1808, 3802, 8608, 5072, 8782, 2981, 9995, 1457, 3979, 7085, 3727, 2785, 5002, 965, 7193, 1470, 4038, 2285, 9692, 8078, 7859, 8718, 7136, 1186, 963, 9967, 1931, 4096, 8735, 2171, 7563, 4665, 9980, 3709, 3542, 1589, 3207, 2301, 4376, 4507, 2938, 5068, 6069, 91, 2133, 6620, 6410, 321, 8297, 7143, 4231, 716, 5027, 29, 1791, 3090, 6665, 7422, 4108, 8814, 1050, 5898, 2721, 1808, 9522, 9061, 2805, 1293 };
        private int[] dataPerIteration;
        #endregion

        private readonly QuickSelect quickSelect;

        public QuickSelectBenchmark()
        {
            quickSelect = new QuickSelect();
            Array.Sort(data);
        }

        [IterationSetup]
        public void SetupData()
        {
            dataPerIteration = data.Clone() as int[];
        }
        

        [Benchmark(Baseline = true)]
        public int SortAndTake()
        {
            Array.Sort(dataPerIteration);
            return dataPerIteration[10];
        }

        [Benchmark]
        public int QuickSelect()
        {            
            return quickSelect.GetLargestElement(data, 10);
        }
    }
}
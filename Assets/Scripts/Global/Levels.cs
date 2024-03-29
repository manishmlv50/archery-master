using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {	
	
//		1 : Targets.NormalTarget
//		2 : Targets.BombTarget
//		3 :	Targets.FreezeTarget 
//		4 : Targets.TimeTarget
//		5 : Targets.ProjectileTarget
//		6 : Targets.WallTarget
//		7 : Targets.StrongTarget
//		8 : Targets.DarknessTarget
//      9 : Targets.ReflectorTarget
	
	public static int[,,] _targetsLevel = {
		{// Level 1
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 7, 2, 1, 1 }, 			// 0 sec
			{ 2, 6, 0, 0 },             // 1 sec
			{ 0, 0, 4, 0 }, 
			{ 0, 9, 0, 0 }, 
			{ 5, 0, 0, 0 }, 
			{ 0, 6, 1, 0 },
			{ 0, 0, 0, 7 }, 
			{ 0, 0, 8, 1 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 1, 0, 1, 0 },	            // 10 sec
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 2, 0, 1 },				
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },				
			{ 1, 1, 1, 1 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 1, 0 },             // 20 sec
			{ 1, 1, 1, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 1, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },	            // 30 sec
			{ 1, 0, 1, 0 },
			{ 0, 1, 0, 1 },
			{ 1, 1, 1, 1 },
			{ 1, 0, 0, 1 },
			{ 0, 1, 1, 0 },
			{ 1, 0, 0, 1 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             
			{ 0, 0, 0, 0 },              // 40 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 50 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 60 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 70 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 2
			{ 0, 0, 0, 0 }, 			// 0 sec
			{ 1, 0, 0, 0 },             // 1 sec
			{ 0, 0, 1, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 1, 0, 0 }, 
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 1, 0, 0, 1 }, 
			{ 0, 1, 1, 0 }, 
			{ 1, 1, 1, 1 },	            // 10 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 1, 1, 1 },				
			{ 1, 0, 1, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 1, 1, 0 },				
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 1 },
			{ 1, 0, 0, 1 },             // 20 sec
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 1 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 1, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 1, 0, 0 },	            // 30 sec
			{ 1, 0, 0, 0 },
			{ 1, 0, 0, 1 },
			{ 0, 0, 1, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 1, 0, 0 },
			{ 1, 1, 0, 0 },
			{ 0, 0, 0, 1 },             // 40 sec
			{ 0, 0, 1, 0 },
			{ 1, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 1, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             // 50 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 60 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 70 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 3
			{ 0, 0, 0, 0 }, 			// 0 sec
			{ 0, 0, 0, 0 },             // 1 sec
			{ 0, 0, 1, 1 }, 
			{ 1, 1, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 1, 0 },
			{ 0, 1, 0, 1 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 2, 0 }, 
			{ 0, 1, 0, 1 },	            // 10 sec
			{ 0, 1, 0, 1 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },				
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 1, 0 },				
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             // 20 sec
			{ 0, 2, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 1, 0, 1, 0 },
			{ 0, 0, 1, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 1, 0 },	            // 30 sec
			{ 0, 0, 2, 0 },
			{ 0, 0, 1, 1 },
			{ 0, 1, 1, 1 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 1, 0 },
			{ 1, 0, 1, 0 },
			{ 1, 0, 1, 0 },
			{ 0, 2, 0, 0 },             // 40 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 1 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             // 50 sec
			{ 0, 1, 0, 0 },
			{ 1, 1, 2, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 1 },
			{ 0, 2, 0, 1 },
			{ 1, 1, 1, 0 },
			{ 1, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 60 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 70 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 4
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 0, 0, 0, 0 }, 			// 0 sec
			{ 0, 0, 0, 0 },             // 1 sec
			{ 0, 1, 0, 0 }, 
			{ 0, 1, 0, 0 }, 
			{ 0, 1, 1, 0 }, 
			{ 0, 0, 2, 0 },
			{ 0, 0, 1, 4 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 1, 0, 0 },	            // 10 sec
			{ 0, 1, 0, 0 },
			{ 0, 1, 1, 1 },
			{ 0, 0, 0, 2 },				
			{ 0, 0, 0, 4 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },				
			{ 1, 1, 0, 0 },
			{ 2, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 0 },             // 20 sec
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 5, 0, 1, 0 },
			{ 0, 4, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 1, 0, 1, 0 },	            // 30 sec
			{ 0, 1, 0, 1 },
			{ 1, 0, 1, 0 },
			{ 0, 2, 0, 1 },
			{ 1, 0, 2, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 0, 4, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             
			{ 1, 0, 0, 0 },              // 40 sec
			{ 2, 1, 0, 0 },
			{ 1, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 1, 1 },
			{ 0, 0, 1, 2 },
			{ 0, 0, 1, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 50 sec
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 2, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 1, 0 },              // 60 sec
			{ 0, 2, 5, 0 },
			{ 0, 0, 1, 0 },
			{ 1, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 4, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 2, 0, 0 },              // 70 sec
			{ 1, 0, 0, 1 },
			{ 0, 0, 2, 0 },
			{ 1, 0, 0, 1 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 5
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 0, 0, 0, 0 }, 			// 0 sec
			{ 0, 0, 0, 0 },             // 1 sec
			{ 7, 0, 0, 0 }, 
			{ 0, 1, 0, 0 }, 
			{ 0, 0, 1, 0 }, 
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 }, 
			{ 0, 7, 0, 4 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 1, 0 }, 
			{ 7, 0, 2, 0 },	            // 10 sec
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },				
			{ 3, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 1, 1 },				
			{ 0, 1, 2, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 4, 1, 3 },             // 20 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 2, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 3, 0, 2, 0 },
			{ 1, 0, 0, 1 },
			{ 1, 0, 0, 1 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 3 },	            // 30 sec
			{ 0, 0, 0, 0 },
			{ 7, 0, 5, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 7, 0, 4 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 1 },             
			{ 0, 1, 0, 1 },              // 40 sec
			{ 0, 7, 2, 1 },
			{ 0, 1, 0, 1 },
			{ 0, 1, 2, 1 },
			{ 0, 1, 3, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 7, 0, 0, 0 },
			{ 7, 0, 1, 0 },              // 50 sec
			{ 7, 1, 2, 0 },
			{ 0, 0, 1, 1 },
			{ 0, 0, 0, 5 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 1, 3, 0 },
			{ 0, 0, 2, 1 },              // 60 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 3, 0, 4, 0 },
			{ 0, 7, 2, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 7, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 3, 0, 7, 0 },              // 70 sec
			{ 0, 2, 1, 0 },
			{ 0, 0, 7, 0 },
			{ 0, 0, 0, 1 },
			{ 7, 1, 2, 1 },
			{ 0, 1, 1, 1 },
			{ 0, 1, 0, 1 },
			{ 0, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 6
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 6, 0, 0, 0 }, 			// 0 sec
			{ 0, 0, 0, 0 },             // 1 sec
			{ 6, 1, 0, 1 }, 
			{ 0, 1, 0, 1 }, 
			{ 6, 1, 0, 1 }, 
			{ 0, 0, 2, 0 },
			{ 6, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 6, 0, 0, 0 }, 
			{ 1, 1, 4, 1 }, 
			{ 6, 0, 0, 0 },	            // 10 sec
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 0, 1, 0, 3 },				
			{ 6, 7, 2, 1 },
			{ 0, 1, 0, 1 },
			{ 6, 1, 0, 0 },				
			{ 0, 0, 5, 1 },
			{ 6, 1, 0, 0 },
			{ 1, 2, 0, 4 },
			{ 6, 0, 0, 0 },             // 20 sec
			{ 0, 0, 0, 0 },
			{ 0, 6, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 6, 1, 6, 0 },
			{ 1, 1, 2, 1 },
			{ 0, 5, 6, 1 },
			{ 6, 0, 0, 1 },	            // 30 sec
			{ 1, 2, 1, 0 },
			{ 0, 0, 4, 0 },
			{ 6, 1, 0, 1 },
			{ 0, 0, 2, 1 },
			{ 0, 1, 0, 3 },
			{ 6, 1, 0, 1 },
			{ 7, 5, 0, 1 },
			{ 0, 0, 2, 7 },
			{ 0, 0, 0, 0 },             
			{ 6, 0, 0, 0 },              // 40 sec
			{ 0, 0, 0, 0 },
			{ 7, 0, 0, 0 },
			{ 6, 1, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 7, 1, 0, 3 },
			{ 7, 1, 2, 1 },
			{ 6, 0, 0, 1 },
			{ 0, 0, 7, 4 },
			{ 3, 0, 0, 0 },
			{ 0, 0, 3, 0 },              // 50 sec
			{ 6, 1, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 7, 0, 0, 0 },
			{ 7, 0, 1, 0 },
			{ 7, 3, 1, 0 },
			{ 0, 0, 1, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 2, 0, 0 },              // 60 sec
			{ 0, 0, 4, 0 },
			{ 7, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 3, 0, 0, 0 },
			{ 2, 0, 1, 0 },
			{ 1, 1, 0, 0 },
			{ 0, 6, 0, 0 },              // 70 sec
			{ 0, 1, 2, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 1, 0, 5 },
			{ 0, 6, 0, 1 },
			{ 0, 0, 0, 1 },
			{ 6, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 6, 1, 0, 0 },
			{ 7, 3, 2, 0 },
			{ 6, 1, 0, 0 },              // 80 sec
			{ 0, 7, 2, 0 },
			{ 6, 0, 0, 0 },
			{ 0, 7, 0, 1 },
			{ 6, 1, 0, 1 },
			{ 0, 1, 0, 1 },
			{ 6, 1, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 7
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 0, 0, 0, 0 }, 			// 0 sec
			{ 0, 0, 0, 0 },             // 1 sec
			{ 1, 1, 0, 0 }, 
			{ 2, 2, 0, 0 }, 
			{ 1, 1, 0, 0 }, 
			{ 0, 0, 0, 0 },
			{ 0, 5, 1, 0 }, 
			{ 0, 7, 2, 0 }, 
			{ 7, 0, 1, 0 }, 
			{ 0, 0, 0, 8 }, 
			{ 0, 0, 0, 0 },	            // 10 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 1, 0 },
			{ 1, 0, 5, 0 },				
			{ 1, 3, 4, 0 },
			{ 1, 2, 1, 0 },
			{ 0, 1, 0, 0 },				
			{ 0, 0, 0, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 2, 0, 0 },
			{ 0, 7, 0, 0 },             // 20 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 8, 0, 0 },
			{ 0, 1, 2, 5 },
			{ 0, 7, 1, 1 },
			{ 0, 1, 0, 1 },
			{ 0, 0, 0, 8 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },	            // 30 sec
			{ 0, 0, 0, 3 },
			{ 0, 7, 4, 0 },
			{ 1, 7, 0, 0 },
			{ 5, 0, 8, 0 },
			{ 5, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             
			{ 6, 4, 0, 1 },              // 40 sec
			{ 6, 1, 8, 1 },
			{ 0, 1, 2, 5 },
			{ 6, 0, 1, 0 },
			{ 6, 0, 0, 0 },
			{ 6, 0, 1, 0 },
			{ 0, 0, 2, 0 },
			{ 6, 0, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 6, 0, 0, 0 },              // 50 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 7, 0, 5, 0 },
			{ 0, 1, 0, 8 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 3 },
			{ 0, 0, 0, 0 },
			{ 7, 2, 0, 0 },
			{ 7, 0, 7, 0 },              // 60 sec
			{ 7, 0, 7, 8 },
			{ 0, 0, 7, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 3, 0, 0 },
			{ 1, 0, 7, 2 },
			{ 5, 1, 7, 4 },
			{ 1, 1, 7, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 70 sec
			{ 0, 0, 0, 0 },
			{ 7, 2, 4, 0 },
			{ 1, 0, 8, 0 },
			{ 7, 1, 0, 0 },
			{ 1, 2, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 3 },              // 80 sec
			{ 2, 1, 0, 0 },
			{ 7, 7, 2, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 1, 0, 0, 0 },
			{ 2, 1, 0, 1 },
			{ 1, 0, 2, 8 },
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 8
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 0, 0, 0, 0 }, 			// 0 sec
			{ 0, 0, 0, 0 },             // 1 sec
			{ 7, 0, 0, 0 }, 
			{ 7, 0, 1, 0 }, 
			{ 7, 3, 1, 0 }, 
			{ 0, 2, 1, 0 },
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 7, 0, 5, 0 }, 
			{ 0, 4, 8, 3 }, 
			{ 0, 0, 0, 2 },	            // 10 sec
			{ 0, 0, 7, 0 },
			{ 0, 0, 1, 0 },
			{ 0, 0, 7, 0 },				
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },				
			{ 6, 9, 2, 0 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 1 },
			{ 0, 1, 0, 1 },             // 20 sec
			{ 0, 0, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 9 },
			{ 7, 0, 0, 0 },          //test
			{ 6, 0, 1, 0 },
			{ 7, 1, 5, 0 },
			{ 1, 2, 2, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },	            // 30 sec
			{ 0, 0, 0, 0 },
			{ 6, 1, 2, 1 },
			{ 7, 1, 0, 1 },
			{ 7, 4, 0, 1 },
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 0, 1, 0, 8 },
			{ 7, 1, 5, 0 },
			{ 0, 0, 3, 0 },             
			{ 6, 0, 0, 0 },              // 40 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 0, 0, 0, 9 },
			{ 7, 1, 2, 1 },
			{ 6, 1, 2, 0 },
			{ 7, 7, 2, 4 },
			{ 0, 1, 7, 0 },
			{ 6, 0, 1, 1 },
			{ 0, 0, 0, 0 },              // 50 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 7, 1, 0, 0 },
			{ 7, 1, 0, 0 },              //test
			{ 0, 0, 0, 9 },
			{ 6, 0, 2, 0 },
			{ 6, 7, 1, 6 },
			{ 6, 2, 1, 7 },
			{ 0, 7, 0, 6 },              // 60 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 5, 7, 0, 0 },
			{ 1, 7, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 7, 6, 6, 2 },
			{ 7, 6, 2, 1 },
			{ 7, 6, 6, 1 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 70 sec
			{ 0, 0, 0, 0 },
			{ 1, 1, 0, 0 }, 
			{ 2, 2, 0, 0 }, 
			{ 1, 1, 0, 0 }, 
			{ 0, 0, 0, 0 },
			{ 0, 5, 1, 0 }, 
			{ 0, 7, 2, 0 }, 
			{ 4, 0, 1, 0 }, 
			{ 0, 0, 0, 8 }, 
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 6, 5, 0, 8 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 6, 0, 0, 0 },
			{ 6, 0, 1, 6 },
			{ 0, 0, 1, 6 },
			{ 0, 1, 7, 2 },              // 90 sec
			{ 0, 2, 1, 1 },
			{ 0, 1, 0, 0 },
			{ 0, 1, 0, 6 },
			{ 1, 0, 2, 1 },
			{ 7, 1, 0, 1 },
			{ 1, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
		
		{// Level 9
		 // {1st row (left), 2nd row (right), 3rd row (left), 4th row (right)}
			{ 2, 0, 0, 0 }, 			// 0 sec
			{ 6, 6, 1, 1 },             // 1 sec
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 }, 
			{ 0, 0, 0, 0 },	            // 10 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },				
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },				
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             // 20 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },	            // 30 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },             
			{ 0, 0, 0, 0 },              // 40 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 50 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 60 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 70 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 80 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },              // 90 sec
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 },
			{ 0, 0, 0, 0 }              // 100 sec
		},
	};
}
	

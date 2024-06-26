﻿using System;
using Microsoft.AspNetCore.Authorization;

namespace synnex_mvc_app_1.AutorizationRequirements
{
	public class MinimumAgeRequirement: IAuthorizationRequirement
	{
		public int MinimumAge { get; set; }
		public MinimumAgeRequirement(int minimumAge)
		{
			MinimumAge = minimumAge;
		}
	}
}


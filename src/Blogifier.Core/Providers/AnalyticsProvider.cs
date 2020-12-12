﻿using Blogifier.Core.Data;
using Blogifier.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogifier.Core.Providers
{
	public interface IAnalyticsProvider
	{
		Task<AnalyticsModel> GetAnalytics();
	}

	public class AnalyticsProvider : IAnalyticsProvider
	{
		private readonly AppDbContext _db;

		public AnalyticsProvider(AppDbContext db)
		{
			_db = db;
		}

		public async Task<AnalyticsModel> GetAnalytics()
		{
			var model = new AnalyticsModel()
			{
				TotalPosts = _db.Posts.Count(),
				TotalViews = _db.Posts.Select(v => v.PostViews).Sum(),
				TotalSubscribers = 0
			};

			return await Task.FromResult(model);
		}
	}
}

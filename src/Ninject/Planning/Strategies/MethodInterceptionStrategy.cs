﻿using System;
using System.Reflection;
using Ninject.Planning.Directives;
using Ninject.Selection;

namespace Ninject.Planning.Strategies
{
	public class MethodInterceptionStrategy : IPlanningStrategy
	{
		public ISelector Selector { get; set; }

		public MethodInterceptionStrategy(ISelector selector)
		{
			Selector = selector;
		}

		public void Execute(IPlan plan)
		{
			foreach (MethodInfo method in Selector.SelectMethodsForInterception(plan.Type))
				plan.Add(new StaticMethodInterceptionDirective(method));
		}
	}
}
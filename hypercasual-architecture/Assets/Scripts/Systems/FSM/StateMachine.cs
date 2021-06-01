﻿using System;
using System.Collections.Generic;

namespace Systems.FSM
{
	public class StateMachine
	{
		IState currentState;
		
		Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
		List<Transition> currentTransitions = new List<Transition>();
		List<Transition> anyTransitions = new List<Transition>();
		
		static List<Transition> EmptyTransitions { get; } = new List<Transition>(0);

		public void Tick()
		{
			var transition = GetTransition();
			if (transition != null)
			{
				SetState(transition.To);
			}
			
			currentState.Tick();
		}

		public void SetState(IState state)
		{
			if(state == currentState) return;
			
			currentState?.OnExit();
			currentState = state;
			
			transitions.TryGetValue(currentState.GetType(), out currentTransitions);

			if (currentTransitions == null)
			{
				currentTransitions = EmptyTransitions;
			}
			
			currentState?.OnEnter();
		}

		public void AddTransition(IState from, IState to, Func<bool> predicate)
		{
			if (transitions.TryGetValue(from.GetType(), out var foundedTransitions) == false)
			{
				foundedTransitions = new List<Transition>();
				transitions[from.GetType()] = foundedTransitions;
			}
			
			foundedTransitions.Add(new Transition(to, predicate));
		}

		public void AddAnyTransition(IState state, Func<bool> predicate)
		{
			anyTransitions.Add(new Transition(state, predicate));
		}

		class Transition
		{
			public IState To { get; }
			public Func<bool> Condition { get; }
			
			public Transition(IState to, Func<bool> condition)
			{
				To = to;
				Condition = condition;
			}
		}

		Transition GetTransition()
		{
			foreach (var transition in anyTransitions)
				if (transition.Condition())
					return transition;
			
			foreach (var transition in currentTransitions)
				if (transition.Condition())
					return transition;

			return null;
		}
	}
}
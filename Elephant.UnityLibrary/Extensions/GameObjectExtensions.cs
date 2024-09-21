﻿#nullable enable

using UnityEngine;

namespace Elephant.UnityLibrary.Extensions
{
	/// <summary>
	/// <see cref="GameObject"/> extensions.
	/// </summary>
	public static class GameObjectExtensions
	{
		/// <summary>
		/// Sets <paramref name="gameObject"/> to inactive and then destroys it.
		/// Destroy() does not immediately remove the object; it schedules the
		/// object to be destroyed at the end of the current frame.
		/// If you want the object to be removed instantly, you can use DestroyImmediate(),
		/// though this is generally discouraged unless absolutely necessary.
		/// This extension method Deactivates the object and then schedules it to be destroyed.
		/// </summary>
		/// <param name="gameObject">GameObject to deactivate and destroy.</param>
		/// <param name="t">Optional delay in seconds before destruction.</param>
		public static void DeactivateAndDestroy(this GameObject gameObject, float t = 0f)
		{
			gameObject.SetActive(false);
			Object.Destroy(gameObject, t);
		}

		/// <summary>
		/// Destroys all children of the specified <paramref name="parent"/>.
		/// The parent itself remains untouched.
		/// </summary>
		/// <param name="parent">Parent GameObject whose children will be destroyed.</param>
		/// <param name="t">Optional delay in seconds before destruction.</param>
		public static void DeactivateAndDestroyAllChildren(this GameObject parent, float t = 0f)
		{
			for (int i = parent.transform.childCount - 1; i >= 0; i--)
				parent.transform.GetChild(i).gameObject.DeactivateAndDestroy(t);
		}

		/// <summary>
		/// Destroys all children of the specified <paramref name="parent"/>.
		/// The parent itself remains untouched.
		/// </summary>
		/// <param name="parent">Parent GameObject whose children will be destroyed.</param>
		/// <param name="t">Optional delay in seconds before destruction.</param>
		public static void DestroyAllChildren(this GameObject parent, float t = 0f)
		{
			for (int i = parent.transform.childCount - 1; i >= 0; i--)
				GameObject.Destroy(parent.transform.GetChild(i), t);
		}
	}
}
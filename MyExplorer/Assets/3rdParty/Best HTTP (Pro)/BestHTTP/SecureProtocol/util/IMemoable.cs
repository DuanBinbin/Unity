/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。



daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)

using System;

namespace Org.BouncyCastle.Utilities
{
	public interface IMemoable
	{
		/// <summary>
		/// Produce a copy of this object with its configuration and in its current state.
		/// </summary>
		/// <remarks>
		/// The returned object may be used simply to store the state, or may be used as a similar object
		/// starting from the copied state.
		/// </remarks>
		IMemoable Copy();

		/// <summary>
		/// Restore a copied object state into this object.
		/// </summary>
		/// <remarks>
		/// Implementations of this method <em>should</em> try to avoid or minimise memory allocation to perform the reset.
		/// </remarks>
		/// <param name="other">an object originally {@link #copy() copied} from an object of the same type as this instance.</param>
		/// <exception cref="InvalidCastException">if the provided object is not of the correct type.</exception>
		/// <exception cref="MemoableResetException">if the <b>other</b> parameter is in some other way invalid.</exception>
		void Reset(IMemoable other);
	}

}


#endif
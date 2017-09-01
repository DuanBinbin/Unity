/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。



daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)

using System;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

namespace Org.BouncyCastle.Crypto.Paddings
{

    /// <summary> A padder that adds Null byte padding to a block.</summary>
    public class ZeroBytePadding : IBlockCipherPadding
    {
        /// <summary> Return the name of the algorithm the cipher implements.
        ///
        /// </summary>
        /// <returns> the name of the algorithm the cipher implements.
        /// </returns>
        public string PaddingName
        {
            get { return "ZeroBytePadding"; }
        }

		/// <summary> Initialise the padder.
        ///
        /// </summary>
        /// <param name="random">- a SecureRandom if available.
        /// </param>
        public void Init(SecureRandom random)
        {
            // nothing to do.
        }

        /// <summary> add the pad bytes to the passed in block, returning the
        /// number of bytes added.
        /// </summary>
        public int AddPadding(
			byte[]	input,
			int		inOff)
        {
            int added = (input.Length - inOff);

            while (inOff < input.Length)
            {
                input[inOff] = (byte) 0;
                inOff++;
            }

            return added;
        }

		/// <summary> return the number of pad bytes present in the block.</summary>
        public int PadCount(
			byte[] input)
        {
            int count = input.Length;

            while (count > 0)
            {
                if (input[count - 1] != 0)
                {
                    break;
                }

                count--;
            }

            return input.Length - count;
        }
    }
}

#endif
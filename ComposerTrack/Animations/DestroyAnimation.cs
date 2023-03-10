using AdofaiMapConverter.Types;
using ComposerTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = System.Numerics.Vector2;

#nullable disable
namespace ComposerTrack.Animations
{
    public static class DestroyAnimation
    {
        /// <summary>
        /// Creates a keyframe with effect of destroy
        /// </summary>
        /// <param name="keyFrame">KeyFrame</param>
        /// <param name="intensivity">Intensivity. Multiplies the values</param>
        /// <param name="withRotation">Animation with rotation</param>
        /// <returns>Result</returns>
        public static KeyFrame Destroy(KeyFrame keyFrame, byte intensivity = 1, bool withRotation = true)
        {
            KeyFrame _keyFrame = keyFrame;

            if (keyFrame is null) return null;

            if (_keyFrame.Rotation < 0) _keyFrame.Rotation += 360f;

            if (_keyFrame.Rotation >= 0 && _keyFrame.Rotation < 90)
            {
                Vector2 str = _keyFrame.Position;
                str.X += 2f * intensivity;
                str.Y += 2f * intensivity;
            }
            if (_keyFrame.Rotation >= 90 && _keyFrame.Rotation < 180)
            {
                Vector2 str = _keyFrame.Position;
                str.X += 2f * intensivity;
                str.Y += -2f * intensivity;
            }
            if (_keyFrame.Rotation >= 180 && _keyFrame.Rotation < 270)
            {
                Vector2 str = _keyFrame.Position;
                str.X += -2f * intensivity;
                str.Y += -2f * intensivity;
            }
            if (_keyFrame.Rotation >= 270 && _keyFrame.Rotation < 360)
            {
                Vector2 str = _keyFrame.Position;
                str.X += -2f * intensivity;
                str.Y += 2f * intensivity;
            }
            if (withRotation) _keyFrame.Rotation += 10f * intensivity;

            return _keyFrame;
        }
        /// <summary>
        /// Creates a keyframes with effect of destroy
        /// </summary>
        /// <param name="keyFrames">KeyFrames</param>
        /// <param name="intensivity">Intensivity. Multiplies the values</param>
        /// <param name="withRotation">Animation with rotation</param>
        /// <returns>Result</returns>
        public static KeyFrame[] Destroy(KeyFrame[] keyFrames, byte intensivity = 1, bool withRotation = true)
        {
            List<KeyFrame> result = new();

            foreach (KeyFrame keyFrame in keyFrames)
            {
                result.Add(Destroy(keyFrame, intensivity, withRotation));
            }
            return result.ToArray();
        }
        /// <summary>
        /// Creates a keyframes with effect of destroy
        /// </summary>
        /// <param name="tiles">Tiles for creating of keyframes</param>
        /// <param name="intensivity">Intensivity. Multiplies the values</param>
        /// <param name="withRotation">Animation with rotation</param>
        /// <returns>Result</returns>
        public static KeyFrame[] Destroy(TileData[] tiles, byte intensivity = 1, bool withRotation = true)
        {
            if (tiles.Length == 0)
            {
                return Array.Empty<KeyFrame>();
            }

            List<KeyFrame> result = new List<KeyFrame>(tiles.Length);
            KeyFrame[] keyFrames = new KeyFrame[tiles.Length];
            int index = 0;

            foreach (TileData tile in tiles)
            {
                if (tile is null) continue;
                keyFrames[index++] = new KeyFrame
                {
                    Position = tile.Position,
                    Rotation = tile.Rotation,
                };
            }

            for (int i = 0; i < index; i++)
            {
                result.Add(Destroy(keyFrames[i], intensivity, withRotation));
            }

            return result.ToArray();
        }
        /// <summary>
        /// Creates a keyframes with effect of destroy
        /// </summary>
        /// <param name="tiles">Decorations for creating of keyframes</param>
        /// <param name="intensivity">Intensivity. Multiplies the values</param>
        /// <param name="withRotation">Animation with rotation</param>
        /// <returns>Result</returns>
        public static KeyFrame[] Destroy(DecoData[] deco, byte intensivity = 1, bool withRotation = true)
        {
            List<KeyFrame> result = new();

            foreach (DecoData _deco in deco)
            {
                if (deco is null) continue;
                KeyFrame keyFrame = new()
                {
                    Position = _deco.Position,
                    Rotation = _deco.Rotation
                };
                result.Add(Destroy(keyFrame, intensivity, withRotation));
            }

            return result.ToArray();
        }
    }
}

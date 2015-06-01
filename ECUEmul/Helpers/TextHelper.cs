using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECUEmulator.Helpers
{
    static class TextHelper
    {
        /// <summary>
        /// Возвращает пакет байтов с посчитанной контрольной суммой
        /// </summary>
        /// <param name="message">Команда</param>
        /// <returns>Готовый пакет</returns>
        public static byte[] SplitMessageAndCalcCrc(string message)
        {
            var packet = message.Split(' ');
            List<byte> mass = new List<byte>();

            unchecked
            {
                byte crc = 0;
                for (int i = 0; i < packet.Length; i++)
                {
                    var oneByte = Convert.ToByte(packet.ElementAt(i), 16);
                    crc += oneByte;
                    mass.Add(oneByte);
                }
                mass.Add(crc);
            }

            return mass.ToArray();
        }


        /// <summary>
        /// Возвращает пакет байтов с посчитанной контрольной суммой
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static byte[] SplitMessageAndCalcCrc(byte[] message)
        {
            var msgList = message.ToList();

            unchecked
            {
                byte crc = 0;
                for (int i = 0; i < msgList.Count; i++)
                {
                    crc += msgList.ElementAt(i);
                }
                msgList.Add(crc);
            }

            return msgList.ToArray();
        }
    }
}

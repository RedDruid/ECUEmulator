using ECUEmulator.Classes;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace ECUEmulator.Helpers
{
    public enum Mode
    {
        Listening,
        Teaching,
        Emulation,
    }

    public class ComHelper
    {
        SerialPort _port;
        Thread th;

        private int _inputStage;
        private byte _inputCrc;
        private bool _threadEnabled = true;

        private int _packetSize;
        private List<byte> _inputMessage = new List<byte>();
        private EcuCommands _commands;
        private List<byte> _headers;

        public delegate void MessageAvialableHandler(string message);
        public event MessageAvialableHandler MesageAvialable;

        Mode _mode;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="headers"></param>
        public ComHelper(EcuCommands commands, List<byte> headers, Mode mode)
        {
            _commands = commands;
            _headers = headers;
            _mode = mode;
        }


        /// <summary>
        /// Флаг открытого порта
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return _port.IsOpen;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void SerialConnect(string portName, string baud)
        {
            _port = new SerialPort();

            _port.PortName = portName;
            _port.BaudRate = Convert.ToInt32(baud);
            _port.Parity = Parity.None;
            _port.DataBits = 8;
            _port.StopBits = StopBits.One;
            _port.Handshake = Handshake.None;
            _port.ReadTimeout = 0;
            _port.WriteTimeout = 500;
            _port.Open();

            StartThread(_commands, _headers);
        }


        /// <summary>
        /// Запуск потока чтения порта
        /// </summary>
        public void StartThread(EcuCommands commands, List<byte> headers)
        {
            _threadEnabled = true;
            th = new Thread(() => ListenPort(_port, commands, headers));
            th.Start();
        }


        /// <summary>
        /// Определение доступных портов
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAvialableComPorts()
        {
            string[] portnames = SerialPort.GetPortNames();
            return portnames.ToList();
        }


        /// <summary>
        /// Прослушка порта
        /// </summary>
        private void ListenPort(SerialPort port, EcuCommands commands, List<byte> headers)
        {
            while (_threadEnabled)
            {
                try
                {
                    var readByte = _port.ReadByte();

                    if (AnalyseBytes(Convert.ToByte(readByte), headers))
                    {
                        switch (_mode)
                        {
                            case Mode.Listening:
                                InvokeEvent("P: " + String.Join(" ", _inputMessage.Select(x => x.ToString("X2")).ToArray()));
                                break;

                            case Mode.Emulation:
                                InvokeEvent("Q: " + String.Join(" ", _inputMessage.Select(x => x.ToString("X2")).ToArray()));
                                var answer = FindCorrectAnswer(_inputMessage);
                                SendAnswer(answer);
                                InvokeEvent("A: " + String.Join(" ", answer.Select(x => x.ToString("X2")).ToArray()));
                                break;

                            case Mode.Teaching:

                                break;
                        }
                    }
                }
                catch (TimeoutException)
                {
                    
                }
            }
        }


        /// <summary>
        /// Принятие пакета побайтно
        /// </summary>
        /// <param name="newByte"></param>
        /// <returns></returns>
        private bool AnalyseBytes(byte newByte, List<byte> headers)
        {
            unchecked
            {
                switch (_inputStage)
                {
                    case 0:
                        if ((newByte & 0xC0) == 0x80)
                        {
                            _packetSize = newByte & 0x3F;

                            _inputMessage.Clear();
                            _inputMessage.Add(newByte);

                            _inputStage = 1;
                            _inputCrc = newByte;
                        }
                        break;

                    case 1:
                        if (Array.FindAll(headers.ToArray(), x => x == newByte).Length != 0)
                        {
                            _inputStage = 2;
                            _inputCrc += newByte;
                            _inputMessage.Add(newByte);
                        }
                        else
                        {
                            if ((newByte & 0xC0) == 0x80)
                            {
                                _packetSize = newByte & 0x3F;
                                _inputCrc = newByte;

                                _inputMessage.Clear();
                                _inputMessage.Add(newByte);
                            }
                            else
                            {
                                _inputStage = 0;
                            }
                        }
                        break;

                    case 2:
                        if (newByte == 0xF1)
                        {
                            if (_packetSize == 0)
                            {
                                _inputStage = 3;
                            }
                            else
                            {
                                _inputStage = 4;
                            }
                            _inputCrc += newByte;
                            _inputMessage.Add(newByte);
                        }
                        else
                        {
                            _inputStage = 0;
                        }
                        break;

                    case 3:
                        _packetSize = newByte;
                        _inputStage = 4;
                        _inputCrc += newByte;
                        _inputMessage.Add(newByte);
                        break;

                    case 4:
                        _inputCrc += newByte;
                        _inputMessage.Add(newByte);
                        _packetSize--;

                        if (_packetSize == 0)
                        {
                            _inputStage = 5;
                        }
                        break;

                    case 5:
                        if (_inputCrc == newByte)
                        {
                            return true;
                        }
                        _inputStage = 0;
                        break;
                }
            }

            return false;
        }


        /// <summary>
        /// Поиск нужного ответа в наборе сообщений для контроллера
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private byte[] FindCorrectAnswer(List<byte> message)
        {
            IEnumerable<string> strList = message.Select(x => x.ToString("X2"));

            var command = String.Join(" ", strList.Cast<string>().ToArray());

            for(int i=0; i<_commands.Commands.Count; i++)
            {
                if (String.Equals(_commands.Commands.ElementAt(i).Q.Trim().ToUpper(), command.Trim().ToUpper()))
                {
                    return TextHelper.SplitMessageAndCalcCrc(_commands.Commands.ElementAt(i).A);
                }
            }

            return null;
        }


        /// <summary>
        /// Отправка ответа
        /// </summary>
        /// <param name="message"></param>
        private void SendAnswer(byte[] message)
        {
            if (_port.IsOpen)
            {
                _port.Write(message, 0, message.Length);
            }
            else
            {
                InvokeEvent("The Port is closed!");
            }
        }


        /// <summary>
        /// Отключение порта
        /// </summary>
        public void Disconnect()
        {
            
            if(_port.IsOpen)
            {
                _threadEnabled = false;
                Thread.Sleep(100);

                _port.Close();
            }
        }


        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="text"></param>
        private void InvokeEvent(string text)
        {
            if(MesageAvialable != null)
            {
                MesageAvialable(text);
            }
        }

    }
}

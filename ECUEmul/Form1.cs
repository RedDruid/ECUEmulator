using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ECUEmulator.Classes;
using ECUEmulator.Helpers;
using System.IO.Ports;

namespace ECUEmulator
{
    public partial class Form1 : Form
    {
        #region Variables
        /// <summary>
        /// Список имен доступных контроллеров
        /// </summary>
        private List<string> _EcuList = new List<string>();

        /// <summary>
        /// Хэлпер для парсинга хмл
        /// </summary>
        private XmlParser xparser;

        /// <summary>
        /// Список названий команд для выбранного контроллера
        /// </summary>
        private List<string> _Commands = new List<string>();
        
        private string _Q = string.Empty;
        private string _A = string.Empty;

        /// <summary>
        /// Список выбранных команд для контроллера
        /// </summary>
        private EcuCommands _EcuCommands;

        /// <summary>
        /// Список портов
        /// </summary>
        private List<string> _comPorts = new List<string>();

        /// <summary>
        /// Хелпер для работы с портами
        /// </summary>
        private ComHelper _ComHelper;

        /// <summary>
        /// Разрешенные заголовки
        /// </summary>
        private List<byte> _headers;

        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка главной формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            xparser = new XmlParser("packets.xml");
            _EcuList = xparser.GetEcuList() as List<string>;
            _comPorts = ComHelper.GetAvialableComPorts();
            _headers = xparser.GetHeaderBytes();

            //Биндинги списков
            comboBoxEcu.DataSource = _EcuList;
            listBoxCommands.Items.Clear();
            foreach (var x in _Commands)
            {
                listBoxCommands.Items.Add(x);
            }
            comboBoxCom.DataSource = _comPorts;
        }


        /// <summary>
        /// Выбор типа ECU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEcu_SelectedIndexChanged(object sender, EventArgs e)
        {
            _EcuCommands = xparser.GetCurrentEcuCommands((string)comboBoxEcu.SelectedValue);
            _Commands = _EcuCommands.Commands.Select(x => x.Name).ToList();

            listBoxCommands.Items.Clear();
            foreach(var x in _Commands)
            {
                listBoxCommands.Items.Add(x);
            }
        }


        /// <summary>
        /// Выбор команды для отображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxA.Text = _EcuCommands.Commands.ElementAt(listBoxCommands.SelectedIndex).A;
            textBoxQ.Text = _EcuCommands.Commands.ElementAt(listBoxCommands.SelectedIndex).Q;
        }


        /// <summary>
        /// Подключение к порту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnecting_Click(object sender, EventArgs e)
        {
            Mode mode;
            if (rbEmulation.Checked)
                mode = Mode.Emulation;
            else if (rbListening.Checked)
                mode = Mode.Listening;
            else if (rbTeaching.Checked)
                mode = Mode.Teaching;
            else
                mode = Mode.Listening;

            _ComHelper = new ComHelper(_EcuCommands, _headers, mode);
            _ComHelper.MesageAvialable += _ComHelper_MesageAvialable;
            _ComHelper.SerialConnect(comboBoxCom.Text, textBoxBaud.Text);

            buttonConnecting.Enabled = false;
            buttonDisc.Enabled = true;
        }


        /// <summary>
        /// Событие приема сообщения с порта
        /// </summary>
        /// <param name="message"></param>
        void _ComHelper_MesageAvialable(string message)
        {
            InvokeControl(listBoxMessages,message);
        }


        /// <summary>
        /// Доступ к ListBox из другого потока
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        private void InvokeControl(ListBox control, string message)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)delegate { control.Items.Add(message); });
            }
            else
            {
                control.Items.Add(message);
            }
        }


        /// <summary>
        /// Отключение от порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisc_Click(object sender, EventArgs e)
        {
            if (_ComHelper.IsOpen)
            {
                _ComHelper.Disconnect();
            }

            buttonConnecting.Enabled = true;
            buttonDisc.Enabled = false;
        }


        /// <summary>
        /// Очистка списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxMessages.Items.Clear();
        }


        /// <summary>
        /// Закрытие формы 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ComHelper != null && _ComHelper.IsOpen)
            {
                _ComHelper.Disconnect();
            }
        }
      
    }
}

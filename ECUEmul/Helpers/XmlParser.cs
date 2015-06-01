using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ECUEmulator.Classes;

namespace ECUEmulator.Helpers
{
    class XmlParser
    {
        private string _path;

        public XmlParser(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Список контроллеров
        /// </summary>
        /// <returns>Список контроллеров</returns>
        public IEnumerable<string> GetEcuList()
        {
            List<string> ecuList = new List<string>();

            XDocument xdoc = XDocument.Load(@_path);

            var ecuCategories = xdoc.Element("root").Elements("ECU");

            foreach(var x in ecuCategories)
            {
                ecuList.Add(x.Attribute("name").Value);
            }

            return ecuList;
        }

        /// <summary>
        /// Список разрешенных байт в заголовке
        /// </summary>
        /// <returns></returns>
        public List<byte> GetHeaderBytes()
        {
            XDocument xdoc = XDocument.Load(@_path);

            var tmp = xdoc.Element("root").Element("headers").Value;
            var arr = tmp.Split(' ').Select(x => Convert.ToByte(x, 16)).ToList();

            return arr;
        }


        /// <summary>
        /// Загрузка выбранного ЭБУ
        /// </summary>
        /// <param name="ecuName"></param>
        /// <returns></returns>
        public EcuCommands GetCurrentEcuCommands(string ecuName)
        {
            EcuCommands allCommands = new EcuCommands();
            allCommands.Commands = new List<OneCommand>();

            XDocument xdoc = XDocument.Load(@_path);

            allCommands.EcuName = ecuName;
            var mainNode = xdoc.Element("root").Elements("ECU").Where(x => x.Attribute("name").Value == ecuName);

            var command = mainNode.Elements("packet");

            foreach (var x in command)
            {
                OneCommand OneCom = new OneCommand();
                OneCom.Name = x.Attribute("name").Value;
                OneCom.Q = x.Element("Q").Value;
                OneCom.A = x.Element("A").Value;

                allCommands.Commands.Add(OneCom);
            }

            return allCommands;
        }
    }
}

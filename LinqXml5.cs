using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    using System.Xml;

    public class MyTask: PT
    {
        // ��� ������� ����� ������ LinqXml �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.

        public static void Solve()
        {
            Task("LinqXml5");
            var f = new System.IO.StreamReader(GetString(), Encoding.Default);
            XmlDocument d = new XmlDocument();
            d.AppendChild(d.CreateXmlDeclaration("1.0", "windows-1251", null));
            XmlElement root = d.CreateElement("root");
            d.AppendChild(root);
            string s;
            int lines = 0;
            while ((s = f.ReadLine()) != null)
            {
                var line = d.CreateElement("line");
                var at = d.CreateAttribute("num");
                at.InnerText = (++lines).ToString();
                line.Attributes.Append(at);
                root.AppendChild(line);
                var arr = s.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    var word = d.CreateElement("word");
                    var num = d.CreateAttribute("num");
                    num.InnerText = (i + 1).ToString();
                    word.Attributes.Append(num);
                    word.InnerText = arr[i];
                    line.AppendChild(word);
                }
            }
            d.Save(GetString());

        }
    }
}

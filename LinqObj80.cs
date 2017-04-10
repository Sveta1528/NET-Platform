using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ��� ������ ������ ����� �� ��������� ���������� �����
        // � ������ a ���� string[] ����������� ��������:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // ��� ������ ������������������ s ���� IEnumerable<string>
        // � �������������� ��������� ���� ����������� ��������:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // ��� ������� ����� ������ LinqObj �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.
        class D
        {
            public int price { get; set; }
            public string name { get; set; }
            public string articul { get; set; }

            public D(int p, string n, string a)
            {
                price = p;
                name = n;
                articul = a;
            }
        }

        class E
        {
            public string articul { get; set; }
            public string name { get; set; }
            public int code { get; set; }


            public E(string a, string n, int c)
            {
                articul = a;
                name = n;
                code = c;
            }
        }

        public static void Solve()
        {
            Task("LinqObj80");

            var splD = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var splE = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();

            var arrD = splD.Select(s =>
            {
                var sp = s.Split(' ');
                return new D(int.Parse(sp[0]), sp[1], sp[2]);
            }).ToArray();

            var arrE = splE.Select(s =>
            {
                var sp = s.Split(' ');
                return new E(sp[0], sp[1], int.Parse(sp[2]));
            }).ToArray();

            var result = arrD.OrderBy(x => x.name).ThenBy(x => x.articul).Select(x =>
            {
                return String.Format("{0} {1} {2}", x.name, x.articul, x.price * arrE.Where(e => e.name == x.name).Count(e => e.articul == x.articul));
            }).ToArray();

            File.WriteAllLines(fname, result.ToArray(), Encoding.Default);

        }
    }
}

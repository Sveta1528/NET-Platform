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

        class AZS
        {
            public int petrol  { get; set; }
            public string name { get; set; }
            public string street { get; set; }
            public int price { get; set; }

            public AZS(int p, string n, string s, int pr)
            {
                petrol = p;
                name = n;
                street = s;
                price = pr;
            }
        }

        public static void Solve()
        {
            Task("LinqObj42");

            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new AZS(int.Parse(sp[0]), sp[1], sp[2], int.Parse(sp[3]));
            }).ToArray();
            var result = arr.OrderBy(x => x.street).GroupBy(x => x.street).Select(x =>
            {
                var str = x.First().street;
                var m92 = x.Where(cur => cur.petrol == 92);
                var m95 = x.Where(cur => cur.petrol == 95);
                var m98 = x.Where(cur => cur.petrol == 98);
                var nt = !m92.Any() ? 0 : m92.Min(cur => cur.price);
                var nf = !m95.Any() ? 0 : m95.Min(cur => cur.price);
                var ne = !m98.Any() ? 0 : m98.Min(cur => cur.price);
                return String.Format("{0} {1} {2} {3}", str, nt, nf, ne);
            }).ToArray();
            File.WriteAllLines(fname, result.ToArray(), Encoding.Default);
        }
    }
}

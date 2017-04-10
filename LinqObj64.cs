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

        class Mark
        {
            public int level { get; set; }
            public string subject { get; set; }
            public string name { get; set; }
            public int mark { get; set; }

            public Mark(int l, string n, string init, string sbj, int m)
            {
                level = l;
                name = n + " " + init;
                subject = sbj;
                mark = m;
            }
        }

        public static void Solve()
        {
            Task("LinqObj64");

            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var fname = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new Mark(int.Parse(sp[0]), sp[1], sp[2], sp[3], int.Parse(sp[4]));
            }).ToArray();
            var result = arr.Where(e => e.subject == "�����������").OrderBy(x => x.level).ThenBy(x => x.name).GroupBy(x => x.name).Where(x => x.Average(e => e.mark) >= 4.00).Select(x =>
            {
                return String.Format("{0} {1} {2}", x.First().level, x.First().name,
                    (Math.Round(x.Average(e => e.mark) / 1.00, 2))
                    .ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
            }).ToArray();

            File.WriteAllLines(fname, result.DefaultIfEmpty("��������� �������� �� �������").ToArray(), Encoding.Default);

        }
    }
}

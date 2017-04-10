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

        class Enrollee
        {
            public string name { get; set; }
            public int year { get; set; }
            public int school { get; set; }

            public Enrollee(string n, int y, int s)
            {
                name = n;
                year = y;
                school = s;
            }

        }


        public static void Solve()
        {
            Task("LinqObj19");
            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var filename = GetString();
            var arr = spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new Enrollee(sp[0], int.Parse(sp[1]), int.Parse(sp[2]));
            });
            arr.Show();
            var result = arr.OrderBy(x=>x.school).GroupBy(x => x.school).Select(x =>
            {
                var e = x.First();
                return e.school + " " + x.Count() + " " + e.name;
            }).ToArray();

            File.WriteAllLines(filename, result.ToArray(), Encoding.Default);
        }
    }
}

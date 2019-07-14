using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            var line = "";
            var soldiers = new List<ISoldier>();

            while ((line = Console.ReadLine()) != "End")
            {
                var data = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var type = data[0];
                var soldierId = data[1];
                var firstName = data[2];
                var lastName = data[3];
                var salary = decimal.Parse(data[4]);

                if (type == "Private")
                {
                    var privateSoldier = new Private(soldierId, firstName, lastName, salary);

                    soldiers.Add(privateSoldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    var privateIds = data.Skip(5).ToArray();
                    var privatesSoldiers = new List<IPrivate>();
                    var general = new LieutenantGeneral(soldierId, firstName, lastName, salary);

                    foreach (var id in privateIds)
                    {
                        var pSoldier = soldiers.FirstOrDefault(x => x.Id == id);

                        general.AddPrivate(pSoldier);
                    }

                    soldiers.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        var corps = data[5];
                        var repaers = data.Skip(6).ToArray();
                        var engineer = new Engineer(soldierId, firstName, lastName, salary, corps);

                        for (int i = 0; i < repaers.Length; i += 2)
                        {
                            var name = repaers[i];
                            var hourseWork = int.Parse(repaers[i + 1]);
                            engineer.AddRepair(new Repair(name, hourseWork));
                        }

                        soldiers.Add(engineer);
                    }
                    catch
                    {
                        continue;
                    }
                }
                else if (type == "Commando")
                {
                    var corps = data[5];
                    var missionStrings = data.Skip(6).ToArray();

                    try
                    {
                        var commando = new Commando(soldierId, firstName, lastName, salary, corps);

                        for (int i = 0; i < missionStrings.Length; i += 2)
                        {
                            try
                            {
                                var missionCodeName = missionStrings[i];
                                var state = missionStrings[i + 1];
                                commando.AddMission(new Mission(missionCodeName, state));
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        soldiers.Add(commando);
                    }
                    catch
                    {
                        continue;
                    }
                }
                else if (type == "Spy")
                {
                    var codeNumber = int.Parse(data[4]);
                    var spy = new Spy(soldierId, firstName, lastName, codeNumber);

                    soldiers.Add(spy);
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString().Trim());
            }
        }
    }
}
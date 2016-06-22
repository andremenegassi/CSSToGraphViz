using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSToGraphViz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            StreamReader input = new StreamReader(Environment.CurrentDirectory + "\\files\\input.csv");
            int id = 0;

            while (!input.EndOfStream)
            {
                string[] line = input.ReadLine().Split(';');
                
                for (int i = 0; i < line.Length; i++)
                {
                    for (int j = i+1; j < line.Length; j++)
                    {
                        if (!string.IsNullOrEmpty(line[i]) && !string.IsNullOrEmpty(line[j]))
                        {
                            Item item = new Item();
                            id++;
                            item.Id = id;
                            item.From = line[i];
                            item.To = line[j];

                            itens.Add(item);
                        }
                    }
                }
              
            }

            input.Close();


            #region gera arquivo no formato GraphViz
            if (File.Exists(Environment.CurrentDirectory + "\\files\\output\\output.json"))
            {
                File.Delete(Environment.CurrentDirectory + "\\files\\output\\output.json");
            }

            var elements = new
            {
                nodes = new List<object>(),
                edges = new List<object>()
            };

            var froms = itens.Select(i => i.From).Distinct().ToList();

            for (int i = 0; i < froms.Count; i++)
            {
               elements.nodes.Add(new {  id = froms[i], label = froms[i] });
            }


            var tos = itens.Select(i => i.To).Distinct().ToList();

            for (int i = 0; i < tos.Count; i++)
            {
                if (!elements.nodes.Contains(new { id = tos[i], label = tos[i] }))
                    elements.nodes.Add(new { id = tos[i], label = tos[i] });
            }


            for (int i = 0; i < itens.Count; i++)
            {
                var obj = new
                {
                    from = itens[i].From,
                    to = itens[i].To
                };

                if (!elements.edges.Contains(obj))
                {
                    elements.edges.Add(obj);

                }
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(elements);

            StreamWriter newJSON = new StreamWriter(Environment.CurrentDirectory + "\\files\\output\\output.json", true);
            newJSON.WriteLine(json);
            newJSON.Close();

            #endregion




            //#region gera arquivo no formato GraphViz
            //if (File.Exists(Environment.CurrentDirectory + "\\files\\output\\output.json"))
            //{
            //    File.Delete(Environment.CurrentDirectory + "\\files\\output\\output.json");
            //}

            //var elements = new
            //{
            //    nodes = new List<object>(),
            //    edges = new List<object>()
            //};

            //var froms = itens.Select(i => i.From).Distinct().ToList();

            //for (int i = 0; i < froms.Count; i++)
            //{
            //    elements.nodes.Add(new { data = new { id = froms[i] } });

            //    if (i == 10)
            //        break;
            //}


            //var tos = itens.Select(i => i.To).Distinct().ToList();

            //for (int i = 0; i < tos.Count; i++)
            //{
            //    if (!elements.nodes.Contains(new { data = new { id = tos[i] } }))
            //        elements.nodes.Add(new { data = new { id = tos[i] } });


            //    if (i == 10)
            //        break;
            //}


            //for (int i = 0; i < itens.Count; i++)
            //{
            //    elements.edges.Add(new
            //    {
            //        data = new
            //        {
            //            id = itens[i].From + "-" + itens[i].To,
            //            source = itens[i].From,
            //            target = itens[i].To
            //        }
            //    });

            //    if (i == 10)
            //        break;
            //}

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(elements);

            //StreamWriter newJSON = new StreamWriter(Environment.CurrentDirectory + "\\files\\output\\output.json", true);
            //newJSON.WriteLine(json);
            //newJSON.Close();

            //#endregion



            #region gera arquivo no formato GraphViz
            //if (File.Exists(Environment.CurrentDirectory + "\\files\\output\\output.txt"))
            //{
            //    File.Delete(Environment.CurrentDirectory + "\\files\\output\\output.txt");
            //}

            //StreamWriter newCSV = new StreamWriter(Environment.CurrentDirectory + "\\files\\output\\output.txt", true);
            //newCSV.WriteLine(@"digraph x {
            //                   rankdir = LR;
            //                   node[shape = none];
            //                   node[shape = circle];");


            //for (int i = 0; i < itens.Count; i++)
            //{
            //    string line = "\"" + itens[i].From + "\" -> \"" + itens[i].To + "\";";
            //    newCSV.WriteLine(line);

            //}

            //newCSV.WriteLine("}");
            //newCSV.Close();

            #endregion



            #region gera arquivo no formato GraphViz
            //if (File.Exists(Environment.CurrentDirectory + "\\files\\output\\output2.txt"))
            //{
            //    File.Delete(Environment.CurrentDirectory + "\\files\\output\\output2.txt");
            //}

            //StreamWriter newCSV = new StreamWriter(Environment.CurrentDirectory + "\\files\\output\\output2.txt", true);



            //for (int i = 0; i < itens.Count; i++)
            //{
            //    string line = "g.addEdge(\"" + itens[i].From  + "\", \"" + itens[i].To  + "\");";
            //    newCSV.WriteLine(line);

            //}


            //newCSV.Close();

            #endregion


            #region gera um novo CSV
            //if (File.Exists(Environment.CurrentDirectory + "\\files\\output\\output.csv"))
            //{
            //    File.Delete(Environment.CurrentDirectory + "\\files\\output\\output.csv");
            //}

            //StreamWriter newCSV = new StreamWriter(Environment.CurrentDirectory + "\\files\\output\\output.csv", true);
            //for (int i = 0; i < itens.Count; i++)
            //{
            //    string line = itens[i].From + ";" + itens[i].To + ";";
            //    newCSV.WriteLine(line);

            //}
            //newCSV.Close();
            #endregion
        }
    }
}
